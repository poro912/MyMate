using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerModule
{
    class NODATAEXCEPTION : Exception
    { 
    
    }

    class NOTCLOSEEXCEPTION : Exception
    { 
    
    }

    class NOIDEXCEPTION : Exception
    { 
    
    }

    class SQL
    {
        /// <summary>
        /// DB에 접속하기 위해서 db connection 객체를 생성하는 메서드
        /// </summary>
        /// <param name="user">DB 계정</param>
        /// <param name="database">DB 이름</param>
        /// <param name="password">DB 비밀번호</param>
        /// <param name="sslmode">DB sslmode</param>
        /// <returns></returns>
        private MySqlConnection Connect(
            string user,
            string database,
            string password,
            string sslmode
        )
        {
            // DB 서버와 포트번호
            string server = "localhost";
            int port = 3306;

            // DB connection 객체를 생성하기 위한 문자열
            string conn = $"SERVER = {server};port = {port};user = {user}; DATABASE = {database}; password = {password}; SSLMODE = {sslmode}";

            // DB connection 객체 생성
            MySqlConnection Conn = new MySqlConnection(conn);

            // conn 객체를 open 상태로 만들어줌(오픈상태가 어떤 상태인지 설명해주면 좋을 것 같다)
            Conn.Open();

            return Conn;
        }

        /// <summary>
        /// DB를 admin 계정으로 접속하기 위한 db connection 객체를 생성하는 메서드
        /// </summary>
        /// <returns></returns>
		private MySqlConnection AdminConnect()
        {
            // DB admin 계정으로 connection 객체 만들기
            MySqlConnection adminConn = Connect("admin", "db_server", "12345", "none");

            return adminConn;
        }

        /// <summary>
        /// DB를 user 계정으로 접속하기 위한 db connection 객체를 생성하는 메서드
        /// </summary>
        /// <returns></returns>
        private MySqlConnection UserConnect()
        {
            // DB user 계정으로 connection 객체 만들기
            MySqlConnection adminConn = Connect("user", "db_server", "12345", "none");

            return adminConn;
        }

        /// <summary>
        /// DB connection 객체가 close 상태인지 확인하는 메서드
        /// </summary>
        /// <param name="conn">확인하려는 DB connection 객체</param>
        /// <returns></returns>
		private bool ConnClose(MySqlConnection conn)
        {
            // conn의 상태를 확인
            if (conn != null)
            {
                conn.Close();
            }

            conn = null;

            return true;
        }

        /// <summary>
        /// DB에 Insert 구문을 수행하는 메서드
        /// </summary>
        /// <param name="table">Insert하려는 테이블</param>
        /// <param name="value">Insert할때 조건절</param>
        /// <param name="conn">DB connection 객체</param>
        /// <returns></returns>
        private bool SqlInsert(
            string table,
            string value,
            MySqlConnection conn
         )
        {
            try
            {
                // Insert 문을 수행 쿼리 
                string query = $"INSERT INTO {table} VALUES ({value})";

                // command : 쿼리를 수행하는 객체
                MySqlCommand msc = new MySqlCommand(query, conn);

                // ExecuteNonQuery() 메서드는 쿼리의 영향을 받은 행의 수를 반환 하는 메서드
                if (msc.ExecuteNonQuery() == 0)
                {
                    throw new NODATAEXCEPTION();
                }
            }
            catch (NODATAEXCEPTION noDataException)
            {
                // Insert문이 수행되지 않았을 경우

                return false;
            }

            return true;
        }

        /// <summary>
        /// DB에 Select 구문을 수행하는 메서드
        /// </summary>
        /// <param name="table">Select하려는 테이블</param>
        /// <param name="condition">Select할때 조건절</param>
        /// <param name="conn">DB connection 객체</param>
        /// <returns></returns>
        private DataTable SqlSelect(
            string table,
            string condition,
            MySqlConnection conn
        )
        {
            // Select문을 반환하기 위한 데이터 테이블
            var datatable = new DataTable();

            try
            {
                // Select 문을 수행 쿼리
                string query = $"SELECT * FROM {table} WHERE {condition}";

                // command : 쿼리를 수행하는 객체
                // datareader : 쿼리 수행 결과를 가져오는 객체
                MySqlCommand msc = new MySqlCommand(query, conn);

                if (msc.ExecuteNonQuery() == 0)
                {
                    throw new NODATAEXCEPTION();
                }
                else
                {
                    // ExecuteReader() 메서드는 DataReader를 만들어줌
                    MySqlDataReader msdr = msc.ExecuteReader();

                    // Load() 메서드는 DataReader를 통해 DataTable을 채움
                    datatable.Load(msdr);
                }
            }
            catch (NODATAEXCEPTION noDataException)
            {
                // Select문이 수행되지 않았을 경우

                return null;
            }

            return datatable;
        }

        /// <summary>
        /// 회원가입을 위한 데이터들의 유효성 검사를 하여 회원가입하는 메서드
        /// </summary>
        /// <param name="id">회원 id</param>
        /// <param name="pw">회원 password</param>
        /// <param name="name">회원 이름</param>
        /// <param name="nick">회원 별명</param>
        /// <param name="phone">회원 전화번호</param>
        /// <param name="conn">DB connection 객체</param>
        /// <returns></returns>
        private bool SignIn(
            string id,
            string pw,
            string name,
            string nick,
            string phone
        )
        {
            // 예외 경우일 경우 do-while 문을 탈출하여 return 하므로 디폴트를 false로 설정
            bool okSignIn = false;

            do
            {
                // 매개변수 값들의 null 체크
                if (id == null)
                {
                    break;
                }
                if (pw == null)
                {
                    break;
                }
                if (name == null)
                {
                    break;
                }
                if (nick == null)
                {
                    break;
                }
                if (phone == null)
                {
                    break;
                }

                // 매개변수 값들의 공백을 체크
                if (id == "")
                {
                    break;
                }
                if (pw == "")
                {
                    break;
                }
                if (name == "")
                {
                    break;
                }
                if (nick == "")
                {
                    break;
                }
                if (phone == "")
                {
                    break;
                }

                // 매개변수 값들의 이상이 없다면 수행 되는 과정
                okSignIn = SignInInsert(id, pw, name, nick, phone);

            } while (true);

            return okSignIn;
        }

        /// <summary>
        /// 회원가입을 위해서 DB에 Insert 문을 통해서 사용자 정보 등록하는 메서드
        /// </summary>
        ///  <param name="id">회원 id</param>
        /// <param name="pw">회원 password</param>
        /// <param name="name">회원 이름</param>
        /// <param name="nick">회원 별명</param>
        /// <param name="phone">회원 전화번호</param>
        /// <returns></returns>
        private bool SignInInsert(
            string id,
            string pw,
            string name,
            string nick,
            string phone
        )
        {
            // 결과값을 반환하는 변수
            bool okInsert;

            // Insert values 절
            string value = $"'{id}','{pw}','{name}','{nick}','{phone}'";

            try
            {
                // DB 연결
                MySqlConnection conn = UserConnect();

                // Insert문 수행
                okInsert = SqlInsert("user_tb", value, conn);

                // DB 닫기
                if (!ConnClose(conn))
                {
                    throw new NOTCLOSEEXCEPTION();
                }
            }
            catch (NOTCLOSEEXCEPTION noDataException)
            {
                // conn close를 실패했을 때

                return false;
            }

            return okInsert;
        }

        /// <summary>
        /// DB에서 회원 id, pw를 가져와 비교 확인 후 로그인 시켜주는 메서드
        /// </summary>
        /// <param name="id">회원이 입력한 id</param>
        /// <param name="pw">회원이 입력한 pw</param>
        /// <returns></returns>
        private bool Login(string id, string pw)
        {
            bool login = true;

            try
            {
                // DB 연결
                MySqlConnection conn = UserConnect();

                // Select문 수행
                DataTable dt = SqlSelect("user_tb", $"U_id = '{id}'", conn);

                do
                {
                    // id 일치 확인
                    if (id != dt.Rows[0]["U_id"].ToString())
                    {
                        login = false;
                        break;
                    }

                    // pw 일치 확인
                    if (pw != dt.Rows[0]["U_password"].ToString())
                    {
                        login = false;
                        break;
                    }

                } while (true);

                // DB 닫기
                if (!ConnClose(conn))
                {
                    throw new NOTCLOSEEXCEPTION();
                }

            }
            catch (NOTCLOSEEXCEPTION notCloseException)
            {
                // conn close를 실패했을 때

                return login;
            }

            return login;
        }

        // 미정
        private int CheckPw(string id, string pw)
        {
            // 0	: 존재하지 않는 id
            // 1	: 성공
            // -1	: 에러 또는 예외 발생 
            int check = 0;

            try
            {
                // DB 연결
                MySqlConnection conn = UserConnect();

                // id값에 해당하는 비밀번호 가져오기
                string select_pw = SelectPw(id, conn);

                if (select_pw == null)  // id가 없을때
                {
                    check = 0;
                }
                else if (pw == select_pw)   // pw가 일치할 때
                {
                    check = 1;
                }
                else    // 그외의 예외
                {
                    check = -1;
                }

                // DB 닫기
                if (!ConnClose(conn))
                {
                    throw new NOTCLOSEEXCEPTION();
                }
            }
            catch (NOTCLOSEEXCEPTION notCloseException)
            {
                // conn close를 실패했을 때

                return -1;
            }

            return check;
        }

        private string SelectPw(string id, MySqlConnection conn)
        {
            string selectPw = null;

            try
            {
                // DB 연결
                conn = UserConnect();

                // Select문 수행
                DataTable dt = SqlSelect("user_tb", $"U_id = '{id}'", conn);

                // id 일치 확인
                if (id == dt.Rows[0]["U_id"].ToString())
                {
                    // pw를 문자열 변수에 저장 
                    selectPw = dt.Rows[0]["U_password"].ToString();
                }
                else
                {
                    throw new NOIDEXCEPTION();
                }

                // DB 닫기
                if (!ConnClose(conn))
                {
                    throw new NOTCLOSEEXCEPTION();
                }
            }
            catch (NOTCLOSEEXCEPTION notCloseException)
            {
                // conn close를 실패했을 때

                return null;
            }
            catch (NOIDEXCEPTION noIdException)
            {
                return null;
            }

            return selectPw;
        }
    }
}