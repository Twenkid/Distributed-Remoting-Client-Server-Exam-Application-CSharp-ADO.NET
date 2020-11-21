using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
//using System.Windows.Forms;

using System.Data;
using System.Data.OleDb;

//using ClassLibrary1;
//using ClassLibraryTest;

/*
 * Курсов проект по Разпределени приложения на Тодор Арнаудов, 0326037
 * Клиентско приложение
 * 18.12.2006
 *
 */

    
namespace Server
{
    [Serializable]
    class ServObj : MarshalByRefObject
    {

        private OleDbConnection conn;
        private DataTable dTable;
        TestDataS tds;
        const int MAX_TITLES = 400;

        int cUsrID, cQuestionsCount, cAnswersCount;
        string cTitle;
        uint testIDMax, UsrIDMax, QuestionsIDMax, AnswersIDMax, TruesIDMax;
        uint QuestionsIDMin = 0, QuestionIDMaxRead = 0;
        string[] testTitles;
       // int[] testIDs;
                
        public ServObj()
        {
            testTitles = new string[MAX_TITLES];
            //testIDs = new int[MAX_TITLES];

            tds = new TestDataS();
            conn = new OleDbConnection();
            dTable = new DataTable();
            string connString = "Data Source=data.mdb;Provider=Microsoft.Jet.OLEDB.4.0;";
            //За инстанцията conn се създава нов обект от тип OleDbConnection
            conn = new OleDbConnection();
            /*
                На полето ConnectionString на новосъздадения обект се присвоява
                стойността на connString
            */
            conn.ConnectionString = connString;
        }
        public string strTemp = "Test A";

        public DataSet SendData()
        //public PointP SendData()
        {
            try
            {

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Table1";
                ds.Tables.Add(dt);

                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("EGN", typeof(string));

                DataRow dr = dt.NewRow();

                dr["Name"] = "sdfsdfs";
                dr["EGN"] = "34234234234";

                dt.Rows.Add(dr);

                //PointP p = new PointP();
                //p.x = 1;
                //p.y = 2;
                
                return ds;
               // return p;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }



        /* Type:         
         *  2 -> by usrName
         *  4 -> by testName
         *  8 -> by usrName and testName
         */

        public DataSet GetResultInfo(string usrName, string testName, int type)
        {

            GetTestTitlesAndIDsArray(cUsrID);

            OleDbCommand cmd = new OleDbCommand();

            OleDbParameter par;

            OleDbDataReader reader;
            string s = " ";

            uint userID=0, testID=0;
            int error = 0;

            //cmd.CommandText = query;
            //string s = "select userID, testID, result from results where ";

            /*
           if (type == 2) s+="where usrName=@usrName";
           else
           if (type == 4) s+="where testName=@testName";
           else
           if (type == 8) s+="where usrName=@usrName and testName=@testName";
             * */

            //if (type == 2)

            s = "select userID from users where username=@usrN";
            cmd.CommandText = s;
            cmd.Connection = conn;
            //cmd.Parameters.Clear();
            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.Char;
            par.ParameterName = "usrN";
            par.Value = usrName;
            cmd.Parameters.Add(par);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    object obValue = reader.GetValue(0);
                    userID = Convert.ToUInt32(obValue.ToString());
                    System.Console.WriteLine("UserID = " + userID.ToString());
                    reader.Close();
                }
                else error = 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            //   if (type == 4)
            /*
            s = "select testID from tests where testName=@testN";
            cmd.CommandText = s;
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.Char;
            par.ParameterName = "testN";
            par.Value = testName;
            cmd.Parameters.Add(par);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    object obValue = reader.GetValue(0);
                    testID = Convert.ToUInt32(obValue.ToString());
                    System.Console.WriteLine("TestName = " + testName);
                    reader.Close();
                }
                else error = 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            */

            DataSet dSet = new DataSet();
            dTable = new DataTable();
            dTable.TableName = "Results";                    
            dSet.Tables.Add(dTable);
            DataRow dRow;
            DataColumn dCol;

            dCol = new DataColumn();
            dCol.DataType = System.Type.GetType("System.String");
            dCol.ColumnName = "Username";
            dCol.ReadOnly = true;
            dCol.Unique = true;
            dTable.Columns.Add(dCol);

            dCol = new DataColumn();
            dCol.DataType = System.Type.GetType("System.String");
            dCol.ColumnName = "Test";
            dCol.ReadOnly = true;
            dCol.Unique = true;
            dTable.Columns.Add(dCol);

            dCol = new DataColumn();
            dCol.DataType = System.Type.GetType("System.String");
            dCol.ColumnName = "Result";
            dCol.ReadOnly = true;
            dCol.Unique = false;
            dTable.Columns.Add(dCol);

            int ius, itest, ires;
            if (type == 2)
            {
                s = "select userID, testID, result from results where userID = @userID";

                cmd.CommandText = s;
                cmd.Connection = conn;
                cmd.Parameters.Clear();

                par = cmd.CreateParameter();
                par.OleDbType = OleDbType.Char;
                par.ParameterName = "userID";
                par.Value = userID;
                cmd.Parameters.Add(par);

                int i = 1;
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    //Взимаме поредните номера в асоциативния масив reader
                    ius = reader.GetOrdinal("userID");
                    itest = reader.GetOrdinal("testID");
                    ires = reader.GetOrdinal("result");

                    while (reader.Read())
                    {
                        //Създава се нов ред в таблицата dTable и се попълва с данни
                        dRow = dTable.NewRow();
                        dRow["Username"] = usrName + "(" + i.ToString() + ")"; //reader[ius];
                        dRow["Test"] =  testTitles[ System.Convert.ToUInt32(reader[itest].ToString())] + " (" + i.ToString() + " )";
                        dRow["Result"] = (reader[ires]).ToString() + "/100";
                        dTable.Rows.Add(dRow);
                        i++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    //връзката с базата данни се затваря
                    conn.Close();
                }
            }

            return dSet;
        }
    

        public string  Login(string user, string pass)        
        {
        
            string commandText = "select * from users where username ='" + user + "'and password ='" + pass + "';";
            dTable = new DataTable();
            dTable.TableName = "users";
            DataColumn dCol;
            DataRow dRow;

            /*
            dCol = new DataColumn();
            dCol.DataType = System.Type.GetType("System.Int32");
            dCol.ColumnName = "userid";
            dCol.ReadOnly = true;
            dCol.Unique = true;
            dTable.Columns.Add(dCol);
             */

            dCol = new DataColumn("userID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("username", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("password", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("status", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);            

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //На елемента от масива се присвоява колоната "Faculty Number" от
            //таблицата dTable
            PrimaryKeyColumns[0] = dTable.Columns["userID"];
            //На полето първични ключове от таблицата dTable се присвоява
            //новосъздадения масив
            dTable.PrimaryKey = PrimaryKeyColumns;

            //Създай нов DataSet и добави новата таблица в него
            DataSet dSet = new DataSet();
            dSet.Tables.Add(dTable);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = commandText;
            cmd.Connection = conn;

           
            int UserID = -1;
            int Status = -1;            
            int iuserid, iusername, ipassword, istatus;            

            //Създавй нов OleDbDataReader обект
            OleDbDataReader reader;
            try
            {
                //Отвори връзката към базата
                conn.Open();
                //Изпълни заявката и вземи върнатия OleDbDataReader обект
                reader = cmd.ExecuteReader();

                //Взимаме поредните номера в асоциативния масив reader
                iuserid = reader.GetOrdinal("userID");
                iusername = reader.GetOrdinal("username");
                ipassword = reader.GetOrdinal("password");
                istatus = reader.GetOrdinal("status");
                
                while (reader.Read())
                {
                    //Създава се нов ред в таблицата dTable и се попълва с данни
                    dRow = dTable.NewRow();
                    dRow["userID"] = reader[iuserid];
                    dRow["username"] = reader[iusername];
                    //label2.Text += reader[itestName].ToString() + ", ";
                    dRow["status"] = reader[istatus];

                    Status = System.Convert.ToInt32(reader[istatus]);
                    UserID = System.Convert.ToInt32(reader[iuserid]);
                    //Новия ред се добавя в таблицата dTable
                    dTable.Rows.Add(dRow);
                }
                //Когато се приключи с четенето обекта reader се затваря
                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                //връзката с базата данни се затваря
                conn.Close();
            }

            return UserID.ToString() + "," + Status.ToString();


        }

        /*
        public string SubHeader(int userID, string title, int questionsCount, int answersCount)
        {
            Console.WriteLine(questionsCount);
            cUsrID = userID;
            cTitle = title;
            cQuestionsCount = questionsCount;
            cAnswersCount = answersCount;

            tds.SetTitle(cTitle);
            tds.maxAnswers = cAnswersCount;
            tds.iQuestions = cQuestionsCount;

            return " ";
        }
        */

        public string FillTestData(uint usrID, uint testID)
        {
            StringBuilder result = new StringBuilder();
            string commandText = "SELECT testTitle FROM tests where testID=@testid";

            dTable = new DataTable();
            dTable.TableName = "Tests";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.Parameters.Add(new OleDbParameter("testid", testID));
            
            DataColumn dCol;
            
            dCol = new DataColumn("testTitle", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);

            OleDbDataReader reader;

            int ititle;            
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

//              itestID = reader.GetOrdinal("testID");
                ititle = reader.GetOrdinal("testTitle");

                while (reader.Read())
                {
                    /*
                    sID = reader[itestID].ToString();
                    sTitle = reader[ititle].ToString();
                    result.Append(sTitle + "~" + sID + "~");
                     */
                    tds.sTitle = reader[ititle].ToString();
                }

                System.Console.WriteLine("Title: ", tds.sTitle);
                reader.Close();
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

           //#read questions

            commandText = "SELECT MIN(questionID) FROM questions where testID=@testid"; // +testID.ToString();
            //cmd.Parameters.Clear();                        
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            
            //            OleDbDataReader reader;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                object obValue = reader.GetValue(0);
                QuestionsIDMin = Convert.ToUInt32(obValue.ToString());
                System.Console.WriteLine("QuestionsIDMin = " + QuestionsIDMin.ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {                
                conn.Close();
            }

            
            commandText = "SELECT MAX(questionID) FROM questions where testID=@testid"; // +testID.ToString();                        
            cmd.Connection = conn;
            cmd.CommandText = commandText;                        
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                object obValue = reader.GetValue(0);
                QuestionIDMaxRead = Convert.ToUInt32(obValue.ToString());
                System.Console.WriteLine("QuestionsIDMaxRead = " + QuestionIDMaxRead.ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {                
                conn.Close();
            }

            tds.iQuestions = (int) (QuestionIDMaxRead - QuestionsIDMin + 1);
            System.Console.WriteLine("Total Questions: " + tds.iQuestions.ToString());

            commandText = "SELECT question, questionID FROM questions where testID=@testid"; // testid вече е дефиниран като параметър
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            //cmd.Parameters.Clear();
            //cmd.Parameters.Add(new OleDbParameter("testid", testID));
            /*
            OleDbParameter par;
            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "testid";
            par.Value = testID;
            cmd.Parameters.Add(par);        
             * */

            dTable.Columns.Clear();

            dCol = new DataColumn("questionID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("testID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("question", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);            
                                    
            int iquestion, iid;
            string sQ;
            int  qID;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                
                iquestion = reader.GetOrdinal("question");
                iid = reader.GetOrdinal("questionID");

                while (reader.Read())
                {                    
                    sQ = (reader[iquestion]).ToString();
                    qID = System.Convert.ToInt32(reader[iid].ToString());                                        
                    tds.sQuestions[qID - QuestionsIDMin] = sQ;
                    System.Console.WriteLine("QuestionRead: " + sQ);
                }                
                reader.Close();
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            //#read answers

            commandText = "SELECT questionID, answer, text FROM answersTexts where testID=@testid and ((questionID>=@qmin) AND (questionID<=@qmax))"; //@qmax and questionID>@qmin"; // testid вече е дефиниран като параметър
            cmd.Connection = conn;
            cmd.CommandText = commandText;

            OleDbParameter par;

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "qmin";
            par.Value = QuestionsIDMin;
            cmd.Parameters.Add(par);

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "qmax";
            par.Value = QuestionIDMaxRead; //fiktivno
            cmd.Parameters.Add(par);  
            
            dTable.Columns.Clear();

            dCol = new DataColumn("questionID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("answer", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("text", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);

            int ianswer, itext;
            string sText;
            int an;
            
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                iquestion = reader.GetOrdinal("questionID");
                ianswer = reader.GetOrdinal("answer");
                itext = reader.GetOrdinal("text");

                while (reader.Read())
                {
                    sText = (reader[itext]).ToString();
                    qID = System.Convert.ToInt32(reader[iquestion].ToString());
                    an  = System.Convert.ToInt32(reader[ianswer].ToString());
                    tds.sAnswers[qID - QuestionsIDMin, an] = sText;
                    System.Console.WriteLine("AnswerRead: " + sText + " " + qID.ToString() + ", " + an.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            //read trues
            commandText = "SELECT questionID, answer FROM answersTrue where ((questionID>=@qmin) AND (questionID<=@qmax))";
            cmd.Connection = conn;
            cmd.CommandText = commandText;

            cmd.Parameters.Clear();

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "qmin";
            par.Value = QuestionsIDMin;
            cmd.Parameters.Add(par);

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "qmax";
            par.Value = QuestionIDMaxRead; //fiktivno
            cmd.Parameters.Add(par);

            dTable.Columns.Clear();

            dCol = new DataColumn("questionID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("answer", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);

            int itrue, trueAns;
            
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                iquestion = reader.GetOrdinal("questionID");
                itrue = reader.GetOrdinal("answer");                

                while (reader.Read())
                {                    
                    qID = System.Convert.ToInt32(reader[iquestion].ToString());
                    trueAns = System.Convert.ToInt32(reader[itrue].ToString());
                    tds.iAnswers[qID - QuestionsIDMin] = trueAns;
                    System.Console.WriteLine("TrueAnswer: " + qID.ToString() + " --> " + trueAns.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            return "asasa";
        }

        public string SubmitHeader(int userID, string title, int questionsCount, int answersCount)
        {
            Console.WriteLine(questionsCount);
            cUsrID = userID;
            cTitle = title;
            cQuestionsCount = questionsCount;
            cAnswersCount = answersCount;

            tds.SetTitle(cTitle);
            tds.maxAnswers = cAnswersCount;
            tds.iQuestions = cQuestionsCount;
                                    
            return " ";
        }

        //Call after FillTestData !
        public string GetTestHeader(int userID)
        {            
            string s = tds.sTitle + "~" + tds.iQuestions.ToString() + "~" + tds.maxAnswers.ToString();
            return s;
        }

        //Call after FillTestData !
        public string GetQuestionLine(int userID, int qu)
        {
            string s = tds.sQuestions[qu] + "~" + tds.sAnswers[qu, 0] + "~" + tds.sAnswers[qu, 1] + "~" + tds.sAnswers[qu, 2] + "~" + tds.sAnswers[qu, 3] + "~" + tds.iAnswers[qu].ToString();          
            return s;
        }

        //Call after FillTestData !
        public string SubmitResult(int userID, uint testID, int result)
        {            
            string commandText = "insert into results values(@userid, @testid, @res )";

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = commandText;
            cmd.Connection = conn;

            OleDbParameter par;

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "userid";
            par.Value = userID;
            cmd.Parameters.Add(par);

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "testid";
            par.Value = testID; //fiktivno
            cmd.Parameters.Add(par);

            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "res";
            par.Value = result;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Data Successifully added");
                Console.WriteLine("Results: " + result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return "true";
        }

        public string SubmitLineToServer(int userID, int index, int trueAnswer, string qTitle, string A1, string A2, string A3, string A4)
        {
            //Console.WriteLine(questionsCount);            

            if (userID != cUsrID)
            {
                return "Invalid user!";
                Console.WriteLine("Invalid user");
            }
            
                tds.SetQuestionText(index, qTitle);
                tds.SetFourAnswersText(index, A1, A2, A3, A4, trueAnswer);
                tds.iAnswers[index] = trueAnswer;
                Console.WriteLine("Success for line" + index.ToString());
                                        
            return "Success for line " + index.ToString();
            //Console.WriteLine("Success for line" + index.ToString());
        }


        public string AddToDataBase(int userID)
        {
            if (userID != cUsrID)
            {
                return "Invalid user!";
                Console.WriteLine("Invalid user");
            }

            //string commandText = "SELECT MAX(testID) FROM tests";
            string commandText = "SELECT MAX(testID) FROM tests";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = commandText;
                                  
     	    int idMax = 0;

            dTable = new DataTable();
            dTable.TableName = "Tests";
            DataColumn dCol;
            DataRow dRow;

            dCol = new DataColumn("testID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
	            
            OleDbDataReader reader;

	     try
            {                             
                conn.Open();                
                reader = cmd.ExecuteReader();
                reader.Read();                
                object obValue = reader.GetValue(0);  //взимаме MAX
                idMax = Convert.ToInt32(obValue.ToString());

                testIDMax = System.Convert.ToUInt32(idMax) + 1;

                System.Console.WriteLine("idMAX = " + idMax.ToString());
                reader.Close();
            }

            catch(Exception ex)
		    {
                System.Console.WriteLine(ex.Message);
                }

	finally
            {
		       System.Console.WriteLine(idMax.ToString());
                conn.Close();
            }

            commandText = "insert into Tests values(@testid, @testauthorid, @testname )";

            //OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = commandText;
            cmd.Connection = conn;

            OleDbParameter par;
                                    
            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "testid";
            par.Value = testIDMax; //fiktivno
            cmd.Parameters.Add(par);             
            
            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.UnsignedInt;
            par.ParameterName = "testauthorid";
            par.Value = cUsrID;
            cmd.Parameters.Add(par);
                                   
            par = cmd.CreateParameter();
            par.OleDbType = OleDbType.Char;
            par.ParameterName = "testname";
            par.Value = cTitle;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Data Successifully added");
                Console.WriteLine("Testname: Data Successifully added");                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                                
            }
            finally
            {
                conn.Close();
            }


            /*
               #addq
               Addding questions 
            */

            commandText = "SELECT MAX(questionID) FROM questions";
            OleDbCommand cmd2 = new OleDbCommand();


            
            cmd2.Connection = conn;
            cmd2.CommandText = commandText;            

            //dTable = new DataTable();
            //dTable.TableName = "Tests";
            //DataColumn dCol;            

            //dCol = new DataColumn("questionID", System.Type.GetType("System.Int32"));
            //dTable.Columns.Add(dCol);

            QuestionsIDMax = 0;
//            OleDbDataReader reader;
            try
            {
                conn.Open();
                reader = cmd2.ExecuteReader();
                reader.Read();
                object obValue = reader.GetValue(0);  //взимаме MAX
                QuestionsIDMax = Convert.ToUInt32(obValue.ToString()) + 1;                
                System.Console.WriteLine("QuestionsIDMax = " + QuestionsIDMax.ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.WriteLine(QuestionsIDMax.ToString());
                conn.Close();
            }

            //====
            AnswersIDMax = QuestionsIDMax;
            TruesIDMax   = QuestionsIDMax;
            
            //====

            OleDbCommand cmd3 = new OleDbCommand();

            commandText = "insert into Questions values(@questionid, @testid, @question )";
            cmd3.CommandText = commandText;
            cmd3.Connection = conn;

            OleDbParameter par3;

            int line;
            for(line=0; line<tds.iQuestions; line++)
         {
            cmd3.Parameters.Clear();

            par3 = cmd3.CreateParameter();
            par3.OleDbType = OleDbType.UnsignedInt;
            par3.ParameterName = "questionid";
            par3.Value = QuestionsIDMax;
            cmd3.Parameters.Add(par3);
            
            par3 = cmd3.CreateParameter();
            par3.OleDbType = OleDbType.UnsignedInt;
            par3.ParameterName = "testid";
            par3.Value = testIDMax;
            cmd3.Parameters.Add(par3);

            par3 = cmd3.CreateParameter();
            par3.OleDbType = OleDbType.Char;
            par3.ParameterName = "question";
            par3.Value = tds.sQuestions[line];
            cmd3.Parameters.Add(par3);
            
            Console.WriteLine("Question: "+ tds.sQuestions[line]);

            try
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                //MessageBox.Show("Data Successifully added");
                Console.WriteLine("TestQuestions line " + line.ToString() + " Data Successifully added");
                QuestionsIDMax++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(QuestionsIDMax.ToString());
                Console.WriteLine(ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }
        

        commandText = "insert into numberQuestions values(@testID, @numberQuestions )";
        cmd3.CommandText = commandText;
        cmd3.Connection = conn;
        cmd3.Parameters.Clear();
                
            par3 = cmd3.CreateParameter();
            par3.OleDbType = OleDbType.UnsignedInt;
            par3.ParameterName = "testid";
            par3.Value = testIDMax;
            cmd3.Parameters.Add(par3);

            par3 = cmd3.CreateParameter();
            par3.OleDbType = OleDbType.UnsignedInt;
            par3.ParameterName = "numberQuestions";
            par3.Value = tds.iQuestions;
            cmd3.Parameters.Add(par3);
            
            Console.WriteLine("Adding Number of Questions: " + tds.sQuestions[line]);
            try
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                //MessageBox.Show("Data Successifully added");
                Console.WriteLine("numberQuestions" + (tds.iQuestions).ToString() + " Data Successifully added");
                QuestionsIDMax++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(QuestionsIDMax.ToString());
                Console.WriteLine(ex.Message);
            }

            finally
            {
                conn.Close();
            }
                

       //#addanswers
                                   
            commandText = "insert into answersTexts values(@questionID, @answer, @text )";
            cmd3.CommandText = commandText;
            cmd3.Connection = conn;


            for (int qu = 0; qu < tds.iQuestions; qu++)
            {                
                for (int an = 0; an < tds.maxAnswers; an++)
                {
                    cmd3.Parameters.Clear();
                    par3 = cmd3.CreateParameter();
                    par3.OleDbType = OleDbType.UnsignedInt;
                    par3.ParameterName = "questionID";
                    par3.Value = AnswersIDMax;
                    cmd3.Parameters.Add(par3);

                    par3 = cmd3.CreateParameter();
                    par3.OleDbType = OleDbType.UnsignedInt;
                    par3.ParameterName = "@answer";
                    par3.Value = an;
                    cmd3.Parameters.Add(par3);

                    par3 = cmd3.CreateParameter();
                    par3.OleDbType = OleDbType.Char;
                    par3.ParameterName = "@text";
                    par3.Value = tds.sAnswers[qu, an];
                    cmd3.Parameters.Add(par3);

                    Console.WriteLine("Adding Answers of Questions: " + tds.sAnswers[qu, an]);

                    try
                    {
                        conn.Open();
                        cmd3.ExecuteNonQuery();
                        //MessageBox.Show("Data Successifully added");
                        Console.WriteLine("Answers line " + AnswersIDMax.ToString() + " " + an.ToString() + " Data Successifully added");                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(QuestionsIDMax.ToString());
                        Console.WriteLine(ex.Message);
                    }

                    finally
                    {
                        conn.Close();
                    }
                }
                AnswersIDMax++;
            }

            //#addtrues

            commandText = "insert into answersTrue values(@questionID, @answer)";
            cmd3.CommandText = commandText;
            cmd3.Connection = conn;

            for (int qu = 0; qu < tds.iQuestions; qu++)
            {             
                    cmd3.Parameters.Clear();
                    par3 = cmd3.CreateParameter();
                    par3.OleDbType = OleDbType.UnsignedInt;
                    par3.ParameterName = "questionID";
                    par3.Value = TruesIDMax;
                    cmd3.Parameters.Add(par3);

                    par3 = cmd3.CreateParameter();
                    par3.OleDbType = OleDbType.UnsignedInt;
                    par3.ParameterName = "@answer";
                    par3.Value = tds.iAnswers[qu];
                    cmd3.Parameters.Add(par3);

                    Console.WriteLine("Adding Answers of Questions: " + tds.iAnswers[qu]);

                    try
                    {
                        conn.Open();
                        cmd3.ExecuteNonQuery();
                        //MessageBox.Show("Data Successifully added");
                        Console.WriteLine("Trues Line " + TruesIDMax.ToString() + " Data Successifully added");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(TruesIDMax.ToString());
                        Console.WriteLine(ex.Message);
                    }

                    finally
                    {
                        conn.Close();
                    }
                 TruesIDMax++;
           }
                                                   

            return "";
        }

        public string GetTestTitlesAndIDs(int usrID)
        {
            StringBuilder result = new StringBuilder();
            string commandText = "SELECT testID, testTitle FROM tests";            

            dTable = new DataTable();
            dTable.TableName = "Tests";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = commandText;


            DataColumn dCol;

            dCol = new DataColumn("testID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("testTitle", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);
                                                         
            OleDbDataReader reader;

            int itestID, ititle;
            string sID, sTitle;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                
                itestID = reader.GetOrdinal("testID");
                ititle = reader.GetOrdinal("testTitle");

                while (reader.Read())
                {                   
                    sID = reader[itestID].ToString();
                    sTitle = reader[ititle].ToString();
                    result.Append(sTitle + "~" + sID + "~");                    
                }
                                
                System.Console.WriteLine("RESULT = " + result);
                reader.Close();
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            finally
            {                
                conn.Close();
            }

            return result.ToString();

        }

        

        
        public void GetTestTitlesAndIDsArray(int usrID)
        {            
            string commandText = "SELECT testID, testTitle FROM tests";

            dTable = new DataTable();
            dTable.TableName = "Tests";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = commandText;

            /*
            DataColumn dCol;
            dCol = new DataColumn("testID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("testTitle", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);
            */

            OleDbDataReader reader;

            int itestID, ititle;
            string sID, sTitle;
            uint ID;
            
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                itestID = reader.GetOrdinal("testID");
                ititle = reader.GetOrdinal("testTitle");

                while (reader.Read())
                {
                    ID = System.Convert.ToUInt32(reader[itestID].ToString());
                    sTitle = reader[ititle].ToString();
                    testTitles[ID] = sTitle;                                        
                }
                //System.Console.WriteLine("RESULT = " + result);
                reader.Close();
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            finally
            {
                conn.Close();
            }
            
        }

        
        public void ConnectToDatabase()
        {            
            string commandText = "select * from Tests";

            dTable = new DataTable();
            dTable.TableName = "Tests";
            DataColumn dCol;
            DataRow dRow;

            dCol = new DataColumn();
            dCol.DataType = System.Type.GetType("System.Int32");
            dCol.ColumnName = "testID";
            dCol.ReadOnly = true;
            dCol.Unique = true;
            dTable.Columns.Add(dCol);

            dCol = new DataColumn("testName", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("testAuthorID", System.Type.GetType("System.Int32"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("dateOfCreation", System.Type.GetType("System.DateTime"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("dateOfChange", System.Type.GetType("System.DateTime"));
            dTable.Columns.Add(dCol);
            dCol = new DataColumn("questionsCount", System.Type.GetType("System.String"));
            dTable.Columns.Add(dCol);


            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //На елемента от масива се присвоява колоната "Faculty Number" от
            //таблицата dTable
            PrimaryKeyColumns[0] = dTable.Columns["testID"];
            //На полето първични ключове от таблицата dTable се присвоява
            //новосъздадения масив
            dTable.PrimaryKey = PrimaryKeyColumns;

            //Създай нов DataSet и добави новата таблица в него
            DataSet dSet = new DataSet();
            dSet.Tables.Add(dTable);


            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = commandText;
            cmd.Connection = conn;

            int itestID, iauthorID, iquestionsCount, itestName, idateCreation, idateChange;
            //int testID, authorID, questionsCount;
            //string testName;
            //DateTime dateCreation, dateChange;

            //Създавй нов OleDbDataReader обект
            OleDbDataReader reader;
            try
            {
                //Отвори връзката към базата
                conn.Open();
                //Изпълни заявката и вземи върнатия OleDbDataReader обект
                reader = cmd.ExecuteReader();

                //Взимаме поредните номера в асоциативния масив reader
                itestID = reader.GetOrdinal("testID");
                itestName = reader.GetOrdinal("testName");
                //#                
                iauthorID = reader.GetOrdinal("testAuthorID");
                idateCreation = reader.GetOrdinal("dateOfCreation");
                idateChange = reader.GetOrdinal("dateOfChange");
                iquestionsCount = reader.GetOrdinal("questionsCount");

                /*
                facNo = reader.GetOrdinal("facNo");
                name = reader.GetOrdinal("name");
                surname = reader.GetOrdinal("surname");
                family = reader.GetOrdinal("family");
                */

                while (reader.Read())
                {
                    //Създава се нов ред в таблицата dTable и се попълва с данни
                    dRow = dTable.NewRow();
                    dRow["testID"] = reader[itestID];
                    dRow["testName"] = reader[itestName];
                    //label2.Text += reader[itestName].ToString() + ", ";
                    dRow["testAuthorID"] = reader[iauthorID];
                    dRow["dateOfCreation"] = reader[idateCreation];
                    dRow["dateOfChange"] = reader[idateChange];
                    dRow["questionsCount"] = reader[iquestionsCount];
                    //Новия ред се добавя в таблицата dTable
                    dTable.Rows.Add(dRow);
                }
                //Когато се приключи с четенето обекта reader се затваря
                reader.Close();
            }
            catch (Exception ex)
            {
//                MessageBox.Show(ex.Message);
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                //връзката с базата данни се затваря
                conn.Close();
            }


        }
        /*
        public PointP sendP()
        {
         PointP p = new PointP();
            p.x = 1;
            //p.y = 3;
            return p;
        }
         */

        public int receive(string s1, string s2)
        {
            Console.WriteLine("Strings: " + s1 + ", " + s2);
            return 3;
        }        

        public string str()
        {
            try
            {
                return strTemp;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        /*
        public ClassTest Test()
        {
            ClassTest ct = new ClassTest();
            return ct;
        }
         */

        
        private void Init()
        {
            conn = new OleDbConnection();
            dTable = new DataTable();
        }

        static void Main(string[] args)
        {
                        
            
            HttpChannel channel = new HttpChannel(8001); //Create a new channel
            ChannelServices.RegisterChannel(channel); //Register channel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServObj), "Service", WellKnownObjectMode.Singleton);
                        
            Console.WriteLine("Server ON at port number:8001");
            Console.WriteLine("Please press enter to stop the server.");
            Console.ReadLine();
        }
    }
}
