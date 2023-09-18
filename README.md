# Library_Project
스터디 진행 중에 만들었던 라이브러리 프로젝트를 리팩토링 하는 코드

## 🖥 프로젝트 소개
콘솔에서 사용할 수 있는 도서관 서비스를 구현한 프로젝트입니다.
<br>

## ⏰ 개발 기간
- 기존 프로젝트:
- 리팩토링: 23년 09월 19일 ~

## ⚙ 개발 환경
- `C++`
- **IDE:** `Visual Studio`
- **DB:** `MySQL`

## 📌 주요 기능
- 회원 관리
  - 회원 등록
  - 회원 정보 수정
  - 회원 삭제
  - 회원 검색
- 도서 관리
  - 도서 등록
  - 도서 수정 (수량)
  - 도서 삭제
  - 도서 검색 (도서명 / 출판사 / 저자)
    - 네이버 도서 검색 API + LOG
- 도서 대여 및 반납
  - 도서 대여 및 반납 시간
 
## :thought_balloon: 주의할 점
- 설계 먼저
- 모든 예외 처리는 스스로 해결
  - (try catch, try parse 금지)
- 객체 지향 캡슐화
  - 기능과 역할에 맞게 클래스 생성 후 사용
- 네이밍 신경 쓰기
  - 축약어 사용 금지
  - 표기법 맞춰 네이밍
- 주석 작성

## :bulb: 리팩토링 과정 중 신경 쓸 점
- 함수는 한 기능만 담고 있을 것
- 가독성 높일 것
- 클래스가 담고 있는 구성 요소들이 모두 일관성 있을 것
- 클래스의 길이가 400 줄을 넘기지 않을 것
- 예외 처리 세게 잡을 것
- 함수의 길이가 최대 50 줄이 넘지 않을 것
- 오타 없앨 것
- 주석 꼼꼼하게 달 것
- 이중 for문보다 깊이가 더 깊어지지 않도록 할 것
