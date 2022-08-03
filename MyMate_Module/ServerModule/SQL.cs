using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerModule
{
    class SQL
    {
		// connect 메서드가 db 사용자, 관리자를 분리해서 접속하는 메서드가 맞나?

		MySqlConnection Connect()
		{ 
		
		}

		MySqlConnection AdminConnect( )
		{

			// db connection을 만들기위한 변수들
			string server = "localhost";
			int port = 3306;
				string user = "root";
				string database = "db_server";
				string password = "12345";
				string sslmode = "none";

			// db connection
			string conn = $"SERVER = {server};port = {port};user = {user}; DATABASE = {database}; password = {password}; SSLMODE = {sslmode}";

			MySqlConnection adminConn = new MySqlConnection(conn);

			adminConn.Open();

			return adminConn;
		}

		MySqlConnection UserConnect( )
		{

			// db connection을 만들기위한 변수들
			string server = "localhost";
			int port = 3306;
			string user = "user";
			string database = "db_server";
			string password = "12345";
			string sslmode = "none";

			// db connection
			string conn = $"SERVER = {server};port = {port};user = {user}; DATABASE = {database}; password = {password}; SSLMODE = {sslmode}";

			MySqlConnection userConn = new MySqlConnection(conn);

			userConn.Open();

			return userConn;
		}

		bool ConnClose(MySqlConnection conn)    // 반환형을 bool로 해야할까? -> void가 편할 것 같다는 생각?
		{
			bool closeConn = true;

			try
			{
				if (conn != null)
				{
					conn.Close();
					Console.WriteLine("DB 클로즈");
				}
			}
			catch (Exception e)
			{
				closeConn = false;

			}

			conn = null;

			return closeConn;
		}
		
		bool SqlInsert(
			string			table,		//설명
			string			value,
			MySqlConnection conn)	// 취향것
		{
			bool okQuery = false;	// 디폴트 트루

			try
			{
				string query = $"INSERT INTO {table} VALUES ({value})";
				DataSet ds = new DataSet();

				MySqlCommand msc = new MySqlCommand(query, conn);
				msc.ExecuteNonQuery();
				okQuery = true;
			}
			catch (Exception e)
			{
				// sql 예외처리
			}

			return okQuery;
		}

		// 반환형 bool이 맞는가 -> dataset을 받을 자료형이여야 할 것 같음
		bool SqlSelect(string table, string condition, MySqlConnection conn)    
		{
			//디폴트 트루
			bool okQuery = false;	

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
			}

			/*
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataTable.Load(mySqlDataReader);

				StringBuilder output = new StringBuilder();
				foreach (DataColumn col in mySqlDataTable.Columns)
				{
					output.AppendFormat("{0} ", col);
				}
				output.AppendLine();
				foreach (DataRow page in mySqlDataTable.Rows)
				{
					foreach (DataColumn col in mySqlDataTable.Columns)
					{
						output.AppendFormat("{0} ", page[col]);
					}
					output.AppendLine();

				}
				Console.WriteLine(output.ToString());

				mySqlDataReader.Close();
			}
			catch (Exception e)
			{
				// sql 예외
			}
			*/

			return okQuery;
		}

		bool SignIn(string id, string pw, string name, string nick, string phone, MySqlConnection conn)
		{
			bool okSignIn = false;
			bool okInsert = false;


			//do while문 활용
			// 회원가입 정보의 유효성 검사
			if (id != null && pw != null && name != null && nick != null && phone != null)
			{
				okSignIn = true;
			}
			else if (id != "" && pw != "" && name != "" && nick != "" && phone != "")
			{
				okSignIn = true;
			}

			if (okSignIn)
			{
				okInsert = SignInInsert(id, pw, name, nick, phone, conn);
			}

			return okSignIn;
		}

		bool SignInInsert(string id, string pw, string name, string nick, string phone, MySqlConnection conn)
		{
			bool okQuery = false;

			try
			{
				// insert 메서드 호출
				string query = $"INSERT INTO user_tb VALUES ('{id}','{pw}','{name}','{nick}','{phone}')";
				DataSet ds = new DataSet();

				MySqlCommand msc = new MySqlCommand(query, conn);
				msc.ExecuteNonQuery();
				okQuery = true;
			}
			catch (Exception e)
			{
				// sql 예외 처리
			}
			return okQuery;
		}

		bool Login(string id, string pw)
		{
			// 프로그램 관리자, 사용자 분류
			bool login = false;

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

			return login;
		}

		int CheckPw(string id, string pw)
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

		DataTable SelectPw(string id, MySqlConnection conn)
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