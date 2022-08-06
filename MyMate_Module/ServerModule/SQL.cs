using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerModule
{
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
            string          user,
            string          database,
            string          password,
            string          sslmode
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

            return conn;
        }

        /// <summary>
        /// DB를 admin 계정으로 접속하기 위한 db connection 객체를 생성하는 메서드
        /// </summary>
        /// <returns></returns>
		private MySqlConnection AdminConnect( )
		{
            // DB admin 계정으로 connection 객체 만들기
            adminConn = Connect("admin","db_server","12345","none");

			return adminConn;
		}

        /// <summary>
        /// DB를 user 계정으로 접속하기 위한 db connection 객체를 생성하는 메서드
        /// </summary>
        /// <returns></returns>
        private MySqlConnection UserConnect( )
		{
            // DB user 계정으로 connection 객체 만들기
            adminConn = Connect("user", "db_server", "12345", "none");

            return adminConn;
		}

        /// <summary>
        /// DB connection 객체가 close 상태인지 확인하는 메서드
        /// </summary>
        /// <param name="conn">확인하려는 DB connection 객체</param>
        /// <returns></returns>
		private bool ConnClose(MySqlConnection conn)
		{
			try
			{
				if (conn != null)
				{
					conn.Close();
				}
			}
			catch (Exception e)
			{
                return false;
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
			string			table,
			string			value,
			MySqlConnection conn
         )
		{
			try
			{
				string query = $"INSERT INTO {table} VALUES ({value})";
				DataSet ds = new DataSet();

				MySqlCommand msc = new MySqlCommand(query, conn);
				msc.ExecuteNonQuery();
			}
			catch (Exception e)
			{
                // sql 예외처리
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
            string          table,
            string          condition,
            MySqlConnection conn
        )    
		{
			try
			{
				string query = $"SELECT * FROM {table} WHERE {condition}";
				DataSet ds = new DataSet();

				MySqlDataAdapter adpt = new MySqlDataAdapter(query, conn);
				adpt.Fill(ds, "~");
				okQuery = true;
			}
			catch (Exception e)
			{
                // sql 예외처리
                return false;
			}
 
			return true;
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
            string          id,
            string          pw,
            string          name,
            string          nick,
            string          phone,
            MySqlConnection conn
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
                okSignIn = SignInInsert(id, pw, name, nick, phone, conn);

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
        /// <param name="conn">DB connection 객체</param>
        /// <returns></returns>
        private bool SignInInsert(
            string          id,
            string          pw,
            string          name,
            string          nick,
            string          phone,
            MySqlConnection conn
        )
		{
			try
			{
				// insert 메서드 호출
				string query = $"INSERT INTO user_tb VALUES ('{id}','{pw}','{name}','{nick}','{phone}')";
				DataSet ds = new DataSet();

				MySqlCommand msc = new MySqlCommand(query, conn);
				msc.ExecuteNonQuery();
			}
			catch (Exception e)
			{
                // sql 예외 처리
                return false;
			}
			return true;
		}

        /// <summary>
        /// DB에서 회원 id, pw를 가져와 비교 확인 후 로그인 시켜주는 메서드
        /// </summary>
        /// <param name="id">회원이 입력한 id</param>
        /// <param name="pw">회원이 입력한 pw</param>
        /// <returns></returns>
        private bool Login(string id, string pw)
		{
			// 프로그램 관리자, 사용자 분류
			bool login = false;

            MySqlConnection conn = UserConnect();

            try
            {
                MySqlConnection conn = UserConnect();

                // sqlSelect()

                if (!ConnClose(conn))
                {
                    Exception e;
                }

            }
            catch (Exception e)
            {
               
                return false;
            }


            /*
            //if 문 하나로 처리, 어디민 분리
            //user로그인 위주로 구성
            if (id == "admin" && pw == "1234")  // 관리자 계정 로그인
			{
				MySqlConnection conn = AdminConnect();
				try
				{
					string query = "SELECT * FROM user_tb WHERE U_id = '{ id }'";
					

					MySqlCommand sql_cmd = new MySqlCommand(query, conn);
					MySqlDataReader dbr = sql_cmd.ExecuteReader();
					while (dbr.Read())
					{
						if (id == (string)dbr["U_id"] && pw == (string)dbr["U_password"])
						{
							login = true;
						}
					}
				}
				catch (Exception e)
				{
					// sql 예외처리	
				}
				if (!ConnClose(conn))
				{
					//conn 객체 예외처리
				}
			}
			else    //일반 사용자 계정 로그인
			{
				MySqlConnection conn = UserConnect();
				try
				{
					string query = $"SELECT * FROM user_tb WHERE U_id = '{ id }'";

					MySqlCommand sql_cmd = new MySqlCommand(query, conn);
					MySqlDataReader dbr = sql_cmd.ExecuteReader();
					while (dbr.Read())
					{
						if (id == (string)dbr["U_id"] && pw == (string)dbr["U_password"])
						{
							login = true;
						}
					}
				}
				catch (Exception e)
				{
					// sql 예외처리
				}
				if (!ConnClose(conn))
				{
					//conn 객체 예외처리
				}
			}
            */

			return true;
		}

        // 미정
        private int CheckPw(string id, string pw)
		{
			int check = 0;

			MySqlConnection conn = UserConnect();
			string select_pw = SelectPw(id, conn);
			if (!ConnClose(conn))
			{
				//conn 객체 예외처리
			}

			if (select_pw == null)  // id가 없을때
			{
				check = 0;
			}
			else if (pw == select_pw)	// pw가 일치할 때
			{
				check = 1;
			}
			else            // 그외 예외
			{
				check = -1;
			}

			return check;
		}

        private DataTable SelectPw(string id, MySqlConnection conn)
		{

			//MySqlDataReader dbr;

			//try
			//{
			//	string query = $"SELECT U_password FROM user_tb WHERE U_id = '{ id }'";
				

			//	MySqlCommand sql_cmd = new MySqlCommand(query, conn);
			//	dbr = sql_cmd.ExecuteReader();


			//}
			//catch (Exception e)
			//{
			//	// sql 예외처리
			//}

			var mySqlDataTable = new DataTable();
			string query = $"SELECT U_password FROM user_tb WHERE U_id = '{ id }'";

			
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataTable.Load(mySqlDataReader);

			}
			catch (Exception e)
			{
				// sql 예외
			}

		
			
			return mySqlDataTable;

			//return dbr["U_password"].ToString();    // 비밀번호만 리턴
        }
	}
}