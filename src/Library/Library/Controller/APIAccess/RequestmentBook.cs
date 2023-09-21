using Library.Model.DTO;
using Library.Model.DAO;
using Library.Utility;
using Library.View;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.Collections;
using System.Data.Common;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Formats.Asn1.AsnWriter;

namespace Library.Controller.APIAccess
{
    public class RequestmentBook
    {

        private List<BookDTO> requestedBook = new List<BookDTO>();
        private int requestBookCount = 0;
        private bool isESC = true;

        public void RequestBook(List<BookDTO> books, string userId)
        {
            requestedBook = AccessorData.GetAccessorData().SelectRequestBook();
            int column = 20;
            int row = 1;

            string bookInformation;

            while (isESC)
            {
                isESC = false;
                Console.Clear();
                PrintBookInformation.GetPrintBookInformation().PrintRequestBook();
                Console.SetCursorPosition(0, 3);
                PrintBookInformation.GetPrintBookInformation().PrintRequestBookList(books);
                bookInformation = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
                // 요청하고자 하는 책의 정보를 입력받는 메소드 호출

                ValidateDupricationRequest(bookInformation);
                // 이미 신청된 책과 신청하려는 책이 중복해서 신청될 수 없도록 예외 처리

                if (isESC)
                {
                    continue;
                }

                AddRequst(books, bookInformation);

                if (FailRequestBook())
                // 추가할 수 있는 책이 없다면
                {
                    continue;
                }

                PrintBookInformation.GetPrintBookInformation().PrintSuccessRequestBook();
                Escape();
            }
        }

        private void ValidateDupricationRequest(string bookInformation)
        {
            int column = 20;
            int row = 1;

            for (int i = 0; i < requestedBook.Count; i++)
            {
                if (requestedBook[i].Title.Contains(bookInformation))
                {   // 이미 신청되어 있는 책 중에서 내가 추가하려는 책의 제목과 일치하는 값이 있을 경우 예외 처리
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.ALREADY_REQUEST, column, row);
                    isESC = true;
                    break;
                }
            }
        }

        private void AddRequst(List<BookDTO> books, string bookInformation)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Contains(bookInformation))
                {   // 추가하고자 하는 책의 정보를 포함하고 있는 검색 결과 찾기
                    requestBookCount++;
                    AccessorData.GetAccessorData().InsertRequestBook(books[i]);
                    LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, books[i].Title, Constant.REQUEST_BOOK);
                }
            }
        }

        private bool FailRequestBook()
        {
            int column = 20;
            int row = 1;

            if (requestBookCount == 0)
            {   // 추가할 수 있는 책이 없다면
                GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, column, row);
                isESC = true;
            }

            return isESC;
        }

        private void Escape()
        {
            string enterValue = null;
            while(enterValue != Constant.ESC_STRING)
            {
                enterValue = InputFromUser.GetInputFromUser().InputEnterESC();
            }
        }
    }
}
