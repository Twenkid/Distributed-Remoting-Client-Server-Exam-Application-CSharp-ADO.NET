using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using System.Reflection;
using ClassLibrary1;
using Server;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//using ClassLibraryTest;

/*
 * Курсов проект по Разпределени приложения на Тодор Арнаудов, 0326037
 * Клиентско приложение
 * 18.12.2006
 *
 */

namespace WindowsApplication2
{
      
    public partial class Form1 : Form
    {
        //private TestData testData = new TestData();
        private TestData td = new TestData(), td0 = new TestData();
        private AnswersData ad = new AnswersData();
        UserInformation userInfo = new UserInformation();
        string ConnectionIPAddress = "localhost";
        string    ConnectionPort = "8001";


        string usrName;
        int    usrStatus;
        int    usrID;
        bool   usrLogged;
        uint    usrTestID;

        int ShrinkedWidth = 460, SmallWidth = 268, FullWidth = 745;

        const int MAX_TESTS = 400;
        const int MODE_NONE       = -1;
        const int MODE_AUTHOR_NEW  = 1;
        const int MODE_AUTHOR_EDIT = 2;
        const int MODE_READER_TEST = 3;
        const int MODE_READER_SELECT_TEST = 4;
        const int MODE_AUTHOR_LOGGED = 5;
        

        int iMode = MODE_NONE;
        int currentQuestion = -1;
        uint[] tempTestID;

        ServObj obj = null;

        public Form1()
        {
            InitializeComponent();
            usrName = "";
            usrStatus = -1;
            usrID = -1;
            usrLogged = false;
            tempTestID = new uint[MAX_TESTS];

            SetVisibilityAuthorMode(false);
            Smallest();
            ResetStatus();

            obj = (ServObj)Activator.GetObject(typeof(ServObj), "http://localhost:8001/Service"); //Localhost can be replaced by             
         //   obj.sendP();
        }

        private void SetVisibilityAuthorMode(bool visib)
        {
            gbAnswers.Visible = visib;
            cbA.Visible = visib;
            cbB.Visible = visib;
            cbC.Visible = visib;
            cbD.Visible = visib;
            btClear.Visible = visib;
            btDelete.Visible = false; //future improvement
            btNext.Visible = visib;
            btPrevious.Visible = visib;
            btSend.Visible = visib;
            btRecord.Visible = visib;
            tbQuestion.Visible = visib;
            tbTitle.Visible = visib;
            lbTitle.Visible = visib;
            lbQuestion.Visible = visib;
            lbQuestions.Visible = visib;
            lbNumber.Visible = visib;
            lxQuestions.Visible = visib;                        
        }

        private void SetVisibilityReaderMode(bool visib)
        {
            gbAnswers.Visible = visib;
            cbA.Visible = visib;
            cbB.Visible = visib;
            cbC.Visible = visib;
            cbD.Visible = visib;
            btDelete.Visible = false;
            btNext.Visible = visib;
            btPrevious.Visible = visib;
            btSend.Visible = visib;
            btRecord.Visible = false;
            tbQuestion.Visible = visib;            
            tbTitle.Visible = visib;
            lbTitle.Visible = visib;
            lbQuestion.Visible = visib;
            lbQuestions.Visible = visib;
            lbNumber.Visible = visib;
            lxQuestions.Visible = visib;

            /*
            tbTitle.Enabled = false;
            tbQuestion.Enabled = false;
            tbA.Enabled = false;
            tbB.Enabled = false;
            tbC.Enabled = false;
            tbD.Enabled = false;
             */            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogOut();
            /*
            try
            {
                ClassTest ct2 = obj.Test();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             */
            
    //        FieldInfo[] myFieldInfo;
            //Type myType = typeof(obj.SendData);
            //MessageBox.Show( obj.SendData());
            
            ///*
            /*
            DataSet ds = obj.SendData();
            dgView.DataSource = ds;
            dgView.DataMember = "Table1";
            int a = obj.receive("sdksods", "sdsdsdsdsfe");            

    //            PointP p2 = obj.sendP();

            
            //ds2 = obj.sendP();
  //             */

            //;// = new PointP();
            
          //     PointP p2 = obj.SendData();
         //   MessageBox.Show( p2.x.ToString() + p2.y.ToString() );

            //MessageBox.Show(obj.XP().ToString());
        }

        private void LoggingIn()
        {
            string user, pass, res="";
            bool bServer = true;
            Form2 f2 = new Form2();

            if (f2.ShowDialog(this) == DialogResult.OK) //MessageBox.Show(f2.username);
            {
                user = f2.username;
                pass = f2.password;
                //MessageBox.Show(user, pass);
                //TextBox tb = ( (TextBox) f2.tbUser);
                //user = tb.Text;
                try
                {
                   res = obj.Login(user, pass);
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show(ex.Message);
                    bServer = false;
                }

                if (bServer)
                {
                    string[] parts = res.Split(',');

                    //useful
                    //MessageBox.Show(res, user + "," + pass);

                    if ((System.Convert.ToInt32(parts[0]) > 0) && (System.Convert.ToInt32(parts[1]) >= 0))
                    {
                        usrID = System.Convert.ToInt32(parts[0]);
                        usrStatus = System.Convert.ToInt32(parts[1]);
                        usrLogged = true;
                        usrName = user;
                        string t = "";
                        if (usrStatus == 1) t = "Author";
                        else if (usrStatus == 0) t = "Reader";
                        //useful
                        //MessageBox.Show("User: " + usrName + ", as: " + t + " is Logged In!");
                        ResetStatus();
                    }
                    else
                        MessageBox.Show("Invalid Login!");
                }
                else MessageBox.Show("Server not online!");
            }

            f2.Dispose();
        }

        private void Shrink()
        {
            this.Width = ShrinkedWidth;
        }

        private void Smallest()
        {
            this.Width = SmallWidth;
        }
        

        private void Enlarge()
        {
            this.Width = FullWidth;
        }

        private void ResetStatus()
        {
            StringBuilder caption = new StringBuilder(100);
            string s, s1;
            if (usrLogged)
            {
                if (usrStatus == 1)
                {
                    s1 = "Author";
                    //iMode = MODE_AUTHOR_NEW;
                    ChangeMode(MODE_AUTHOR_LOGGED);
//                    SetVisibilityAuthorMode(true);
                }
                else
                {
                    s1 = "Reader";
                    ChangeMode(MODE_READER_SELECT_TEST);
                    SetVisibilityAuthorMode(false);
                    SetVisibilityReaderMode(false);
                    Smallest();
                    //iMode = MODE_READER_TEST;
//                    SetVisibilityAuthorMode(false);
                }
                s = usrName + " is " + "Logged In as " + s1;
                logOutToolStripMenuItem.Enabled = true;
            }
            else
            {
                SetVisibilityAuthorMode(false);
                SetVisibilityReaderMode(false);
                Smallest();
                //Shrink();
                s = "Not Logged In";
                logOutToolStripMenuItem.Enabled = false;
                
            }

            lbStatusInfo.Text = s;

            if (usrStatus == 1) authorToolStripMenuItem.Enabled = true;
            else 
                authorToolStripMenuItem.Enabled = false;
            if (usrStatus == 0) readerToolStripMenuItem.Enabled = true;
            else
                readerToolStripMenuItem.Enabled = false;            
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            LoggingIn();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggingIn();
        }

        private void SetupAddress()
        {
            FormSetup fs = new FormSetup();

            fs.getIPAddress = ConnectionIPAddress;
            fs.getPort = ConnectionPort;
            
            if (fs.ShowDialog(this) == DialogResult.OK) //MessageBox.Show(f2.username);
            {                
                ConnectionIPAddress = fs.getIPAddress;
                ConnectionPort =      fs.getPort;                
                //MessageBox.Show(ConnectionIPAddress, ConnectionPort);
                //TextBox tb = ( (TextBox) f2.tbUser);
                //user = tb.Text;
            }
            fs.Dispose();

        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupAddress();
        }

        private void LogOut()
        {
            usrName = "";
            usrStatus = -1;
            usrID = -1;
            usrLogged = false;
            ResetStatus();    
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void newTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shrink();
            SetVisibilityAuthorMode(true);
            lbQuestions.Text = "Questions";
            currentQuestion = 0;
            lbNumber.Text = (currentQuestion + 1).ToString();
            td.Clear();
            ClearAuthorForm(true);
            while ( lxQuestions.Items.Count != 0) lxQuestions.Items.RemoveAt(0);
            lxQuestions.Items.Insert(0, "Unnamed yet");
            ChangeMode(MODE_AUTHOR_NEW);

            //LoadDataFromTest(td0);            
        }

        private void LoadDataFromTest(TestData tdIn)
        {
          int i;
          tdIn.Copy(td);
        /*
          tbTitle.Text    = td.sTitle;
          tbQuestion.Text = td.sQuestions[0];
            //for (i=0; i<td.maxAnswers; i++)
          tbA.Text = td.sAnswers[0, 0];
          tbB.Text = td.sAnswers[0, 1];
          tbC.Text = td.sAnswers[0, 2];
          tbD.Text = td.sAnswers[0, 3];
          SetCheckBoxRadio(td.iAnswers[0]);

          for (i = 0; i < td.iQuestions; i++)
          {
              lxQuestions.Items.Add(td.sQuestions[i]);
          }
         */

          tbTitle.Text = td.sTitle;
          tbQuestion.Text = td.sQuestions[0];
          //for (i=0; i<td.maxAnswers; i++)
          tbA.Text = td.sAnswers[0, 0];
          tbB.Text = td.sAnswers[0, 1];
          tbC.Text = td.sAnswers[0, 2];
          tbD.Text = td.sAnswers[0, 3];
          SetCheckBoxRadio(td.iAnswers[0]);

          for (i = 0; i < td.iQuestions; i++)
          {
              lxQuestions.Items.Add(td.sQuestions[i]);
          }

          
        }

        private void SetCheckBoxRadio(int which)
        {
            switch (which)
            {
                case -1: cbA.Checked = false;
                         cbB.Checked = false;
                         cbC.Checked = false;
                         cbD.Checked = false;
                         break;

                case 0: cbA.Checked = true;
                        cbB.Checked = false;
                        cbC.Checked = false;
                        cbD.Checked = false;
                        break;
                case 1: cbA.Checked = false;
                        cbB.Checked = true;
                        cbC.Checked = false;
                        cbD.Checked = false;
                        break;
                case 2: cbA.Checked = false;
                        cbB.Checked = false;
                        cbC.Checked = true;
                        cbD.Checked = false;
                        break;
                case 3: cbA.Checked = false;
                        cbB.Checked = false;
                        cbC.Checked = false;
                        cbD.Checked = true;
                        break;
            }


        }

        private void cbA_MouseClick(object sender, MouseEventArgs e)
        {
            cbA.Checked = true;
            cbB.Checked = false;
            cbC.Checked = false;
            cbD.Checked = false;
            if (iMode == MODE_READER_TEST)
                ad.didAnswered[currentQuestion] = 0;
        }

        private void cbB_MouseClick(object sender, MouseEventArgs e)
        {
            cbA.Checked = false;
            cbB.Checked = true;
            cbC.Checked = false;
            cbD.Checked = false;
            if (iMode == MODE_READER_TEST)
                ad.didAnswered[currentQuestion] = 1;

        }

        private void cbC_MouseClick(object sender, MouseEventArgs e)
        {
            cbA.Checked = false;
            cbB.Checked = false;
            cbC.Checked = true;
            cbD.Checked = false; if (iMode == MODE_READER_TEST)
                ad.didAnswered[currentQuestion] = 2;
        }

        private void cbD_MouseClick(object sender, MouseEventArgs e)
        {
            cbA.Checked = false;
            cbB.Checked = false;
            cbC.Checked = false;
            cbD.Checked = true;
            if (iMode == MODE_READER_TEST)
                ad.didAnswered[currentQuestion] = 3;
        }

        private void enlargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Form1.Width = 600;
            this.Width = FullWidth;
        }

        private int GetChecked()
        {
            if (cbA.Checked) return 0;
            if (cbB.Checked) return 1;
            if (cbC.Checked) return 2;
            if (cbD.Checked) return 3;
            return -1;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = ShrinkedWidth;            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearAuthorForm(bool doTitle)
        {
            if (doTitle)
            {
             tbTitle.Text = " ";
            }
            tbQuestion.Text = " ";
            tbA.Text = " ";
            tbB.Text = " ";
            tbC.Text = " ";
            tbD.Text = " ";

            cbA.Checked = false;
            cbB.Checked = false;
            cbC.Checked = false;
            cbD.Checked = false;

            SetCheckBoxRadio(0);   
       }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (iMode == MODE_AUTHOR_NEW)
            {
              //if ( currentQuestion >= (td.iQuestions-1) )
              //{
                /*
                td.sTitle = tbTitle.Text;
                td.sQuestions[currentQuestion] = tbQuestion.Text;
                td.sAnswers[currentQuestion, 0] = tbA.Text;
                td.sAnswers[currentQuestion, 1] = tbB.Text;
                td.sAnswers[currentQuestion, 2] = tbC.Text;
                td.sAnswers[currentQuestion, 3] = tbD.Text;
                td.iAnswers[currentQuestion]    = GetChecked();

                */
                            
                if (currentQuestion == td.iQuestions)
                {
                    td.iQuestions++;
                    Record();
                    currentQuestion++;                    
                    lxQuestions.Items.Insert(currentQuestion, "Unnamed Yet");                                        
                    ClearAuthorForm(false);
                    lbNumber.Text = (currentQuestion + 1).ToString();
                }
                else
                       {
                           currentQuestion++;
                           tbTitle.Text = td.sTitle;
                           tbQuestion.Text = td.sQuestions[currentQuestion];
                           tbA.Text = td.sAnswers[currentQuestion, 0];
                           tbB.Text = td.sAnswers[currentQuestion, 1];
                           tbC.Text = td.sAnswers[currentQuestion, 2];
                           tbD.Text = td.sAnswers[currentQuestion, 3];
                           lbNumber.Text = (currentQuestion + 1).ToString();
                           SetCheckBoxRadio(td.iAnswers[currentQuestion]);                           
                       }
             }

             if (iMode == MODE_READER_TEST)
             {
                 //if (currentQuestion > ad.iAnswers) return;
//                 if (currentQuestion > td.iQuestions) return;
                 if (currentQuestion >= (td.iQuestions-1)) return;
                 currentQuestion++;
                 lbNumber.Text = (currentQuestion + 1).ToString();
                 tbTitle.Text = td.sTitle;
                 tbQuestion.Text = td.sQuestions[currentQuestion];
                 tbA.Text = td.sAnswers[currentQuestion, 0];
                 tbB.Text = td.sAnswers[currentQuestion, 1];
                 tbC.Text = td.sAnswers[currentQuestion, 2];
                 tbD.Text = td.sAnswers[currentQuestion, 3];
                 SetCheckBoxRadio(ad.didAnswered[currentQuestion]);
             }
                              
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            //if (currentQuestion == 0) { btPrevious.Enabled = false; return; }
            //else btPrevious.Enabled = true;

            if (iMode == MODE_AUTHOR_NEW)
            {
                if (currentQuestion==0) return;
                Record();
                currentQuestion--;
                tbTitle.Text = td.sTitle;
                tbQuestion.Text = td.sQuestions[currentQuestion];
                tbA.Text = td.sAnswers[currentQuestion,0];
                tbB.Text = td.sAnswers[currentQuestion,1];
                tbC.Text = td.sAnswers[currentQuestion,2];
                tbD.Text = td.sAnswers[currentQuestion,3];
                SetCheckBoxRadio(td.iAnswers[currentQuestion]);
                lbNumber.Text = (currentQuestion+1).ToString();
            }

            if (iMode == MODE_READER_TEST)
            {
                if (currentQuestion == 0) return;
                currentQuestion--;
                //tbTitle.Text = td.sTitle;
                tbQuestion.Text = td.sQuestions[currentQuestion];
                tbA.Text = td.sAnswers[currentQuestion, 0];
                tbB.Text = td.sAnswers[currentQuestion, 1];
                tbC.Text = td.sAnswers[currentQuestion, 2];
                tbD.Text = td.sAnswers[currentQuestion, 3];
                SetCheckBoxRadio(ad.didAnswered[currentQuestion]);
                lbNumber.Text = (currentQuestion + 1).ToString();
            }



        }

        private void Record()
        {
            if (iMode == MODE_AUTHOR_NEW)
            {

                td.sTitle = tbTitle.Text;
                td.sQuestions[currentQuestion] = tbQuestion.Text;
                td.sAnswers[currentQuestion, 0] = tbA.Text;
                td.sAnswers[currentQuestion, 1] = tbB.Text;
                td.sAnswers[currentQuestion, 2] = tbC.Text;
                td.sAnswers[currentQuestion, 3] = tbD.Text;
                td.iAnswers[currentQuestion] = GetChecked();

                try
                {                    
                    lxQuestions.Items.RemoveAt(currentQuestion);
                    lxQuestions.Items.Insert(currentQuestion, tbQuestion.Text);
                }
                catch(Exception ex)
                {
                }
                //currentQuestion++;
                //if (currentQuestion > td.iQuestions)
                //   td.iQuestions++;
            }
        }

        private void btRecord_Click(object sender, EventArgs e)
        {
            Record();            
        }

        //send data
        private void btOver_Click(object sender, EventArgs e)
        {
            int i, j;
            //for (i=0; i<td.iQuestions; i++)

            /*
            string usrName;
            int usrStatus;
            int usrID;
            bool usrLogged;
             */
            if (iMode == MODE_AUTHOR_NEW)
            {
                try
                {

                    for (i = 0; i < td.iQuestions; i++)
                    {
                        if (td.sQuestions[i] == "") break;
                    }
                    //obj.SubmitHeader(usrID, td.sTitle, td.iQuestions, td.maxAnswers);
                    string s;

                    obj.SubmitHeader(usrID, td.sTitle, i, td.maxAnswers);

                    //public string SubmitLineToServer(int userID, int index, int trueAnswer, string qTitle, string A1, string A2, string A3, string A4)
                    for (j = 0; j < i; j++)
                    {
                        s = obj.SubmitLineToServer(usrID, j, td.iAnswers[j], td.sQuestions[j], td.sAnswers[j, 0], td.sAnswers[j, 1], td.sAnswers[j, 2], td.sAnswers[j, 3]);
                    }

                    obj.AddToDataBase(usrID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
                if (iMode == MODE_READER_TEST)
                {
                    //#her
                    int qu;
                    float rights = 0;
                    int result;

                    for (qu = 0; qu < ad.iAnswers; qu++)                    
                        if (ad.didAnswered[qu] == ad.trueAnswers[qu]) rights++;

                    result = (int) ( (  (float)rights / (float)ad.iAnswers) * 100.0);
                    obj.SubmitResult(usrID, usrTestID, result);
                    MessageBox.Show("You scored " + result + "%");
                    SitExam();
                    

                    /*
                    try
                    {

                        for (i = 0; i < td.iQuestions; i++)
                        {
                            if (td.sQuestions[i] == "") break;
                        }
                        //obj.SubmitHeader(usrID, td.sTitle, td.iQuestions, td.maxAnswers);
                        string s;

                        obj.SubmitHeader(usrID, td.sTitle, i, td.maxAnswers);

                        //public string SubmitLineToServer(int userID, int index, int trueAnswer, string qTitle, string A1, string A2, string A3, string A4)
                        for (j = 0; j < i; j++)
                        {
                            s = obj.SubmitLineToServer(usrID, j, td.iAnswers[j], td.sQuestions[j], td.sAnswers[j, 0], td.sAnswers[j, 1], td.sAnswers[j, 2], td.sAnswers[j, 3]);
                        }

                        obj.AddToDataBase(usrID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                     */                 
                }

                if (iMode == MODE_READER_SELECT_TEST)
                {
                   //receiveHeader from Server
                   //receiveTestData
                  //InitForms
                }
                                
                /*
                    iAnswers
int trueAnsw, string qTitle, string A1, string A2, string A3, string A4)
            }
                 * */                
        }

        private void lxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lxQuestions.SelectedIndex < 0) return;
            

            if ((iMode == MODE_AUTHOR_NEW) || (iMode == MODE_READER_TEST))
            {

                currentQuestion = lxQuestions.SelectedIndex;
                try
                {
                    tbQuestion.Text = td.sQuestions[currentQuestion];
                    tbA.Text = td.sAnswers[currentQuestion, 0];
                    tbB.Text = td.sAnswers[currentQuestion, 1];
                    tbC.Text = td.sAnswers[currentQuestion, 2];
                    tbD.Text = td.sAnswers[currentQuestion, 3];
                    if (iMode == MODE_AUTHOR_NEW)
                        SetCheckBoxRadio(td.iAnswers[currentQuestion]);
                    else
                        if (iMode == MODE_READER_TEST)
                            SetCheckBoxRadio(ad.didAnswered[currentQuestion]);
                        
                    lbNumber.Text = (currentQuestion+1).ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(currentQuestion.ToString());
                }
            }

            
        }

        private void SitExam()
        {
            Shrink();
            SetVisibilityReaderMode(false);
            string result = obj.GetTestTitlesAndIDs(usrID);
            //title1, id1, title2, id2, ...
            //MessageBox.Show(result);

            while (lxQuestions.Items.Count != 0) lxQuestions.Items.RemoveAt(0);
            ChangeMode(MODE_READER_SELECT_TEST);
            //iMode = MODE_READER_SELECT_TEST;
            lbQuestions.Visible = true;
            lxQuestions.Visible = true;

            string[] parts = result.Split('~');
            //MessageBox.Show((parts.Length).ToString());
            try
            {
                for (int i = 0; i < (parts.Length - 1); i += 2)
                {
                    lxQuestions.Items.Insert((int)(i / 2), parts[i]);
                    //lxQuestions.Items.Add(parts[i]);
                    tempTestID[i / 2] = System.Convert.ToUInt32(parts[i + 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sitExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SitExam();                          
       }

        private void RefreshTestView(int qu)
        {
            if (qu >= td.iQuestions) return;
            if (qu < 0) return;

            tbTitle.Text = td.sTitle;
            tbQuestion.Text = td.sQuestions[currentQuestion];
            tbA.Text = td.sAnswers[qu,0];
            tbB.Text = td.sAnswers[qu,1];
            tbC.Text = td.sAnswers[qu,2];
            tbD.Text = td.sAnswers[qu,3];
            lbNumber.Text = (currentQuestion + 1).ToString();            
        }

        private void ChangeMode(int mode)
        {
            if (iMode == MODE_READER_SELECT_TEST) lbQuestions.Text = "Questions";
            if (iMode == MODE_READER_TEST) lbQuestions.Text = "Available Tests";

            if (mode == MODE_READER_SELECT_TEST) btSelect.Visible = true;
            else btSelect.Visible = false;

            if (mode == MODE_AUTHOR_LOGGED)
            {
                ClearAuthorForm(true);
                td.Clear();
                SetVisibilityAuthorMode(false);
                Smallest();
            }

            iMode = mode;
        }

        private void SelectTest()
        {
        
              try
              {
                    int qu=0, an=0;
                    usrTestID = tempTestID[lxQuestions.SelectedIndex];
                    obj.FillTestData((uint) usrID, (uint) usrTestID); //tempTestID[lxQuestions.SelectedIndex]);
                    string s = obj.GetTestHeader(usrID);
                    string[] parts = s.Split('~');
                    //string s = tds.sTitle + "~" + tds.iQuestions.ToString() + "~" + tds.maxAnswers.ToString();
                    td.sTitle = parts[0].ToString();
                    td.iQuestions = System.Convert.ToInt32(parts[1]);
                    //td.maxAnswers = parts[2].ToString();
                   //string s = tds.sQuestions[qu] + "~" + tds.sAnswers[qu, 0] + "~" + tds.sAnswers[qu, 1] + "~" + tds.sAnswers[qu, 2] + "~" + tds.sAnswers[qu, 3] + "~" + tds.sAnswers[qu].ToString() + "~" + tds.iAnswers[qu].ToString();          
                 for (qu = 0; qu < td.iQuestions; qu++)
                 {
                     s = obj.GetQuestionLine(usrID, qu);
                     string[] part = s.Split('~');
                     td.sQuestions[qu] = part[0];                     
                     td.sAnswers[qu, 0] = part[1];
                     td.sAnswers[qu, 1] = part[2];
                     td.sAnswers[qu, 2] = part[3];
                     td.sAnswers[qu, 3] = part[4];
                     //td.iAnswers[qu] = System.Convert.ToInt32(part[5]);
                     td.iAnswers[qu] = -1; // System.Convert.ToInt32(part[5]);
                     ad.didAnswered[qu] = -1;
                     ad.trueAnswers[qu] = System.Convert.ToInt32(part[5]);
                     ad.iAnswers = td.iQuestions;
                     td.iAnswers[qu] = -1; // System.Convert.ToInt32(part[5]); 
                 }

                 while (lxQuestions.Items.Count != 0) lxQuestions.Items.RemoveAt(0);
                 for (qu = 0; qu < td.iQuestions; qu++)
                     lxQuestions.Items.Insert(qu, td.sQuestions[qu]);

                     ChangeMode(MODE_READER_TEST);                 
                     SetVisibilityReaderMode(true);

                    currentQuestion = 0;
                    RefreshTestView(0);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
          }
     
        //private void GetTestHeader(
        private void lxQuestions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (iMode == MODE_READER_SELECT_TEST)
            {
                SelectTest();
                /*
                try
                {
                    int qu=0, an=0;
                    usrTestID = tempTestID[lxQuestions.SelectedIndex];
                    obj.FillTestData((uint) usrID, (uint) usrTestID); //tempTestID[lxQuestions.SelectedIndex]);
                    string s = obj.GetTestHeader(usrID);

                    string[] parts = s.Split('~');
                    //string s = tds.sTitle + "~" + tds.iQuestions.ToString() + "~" + tds.maxAnswers.ToString();
                    td.sTitle = parts[0].ToString();
                    td.iQuestions = System.Convert.ToInt32(parts[1]);
                    //td.maxAnswers = parts[2].ToString();

           //string s = tds.sQuestions[qu] + "~" + tds.sAnswers[qu, 0] + "~" + tds.sAnswers[qu, 1] + "~" + tds.sAnswers[qu, 2] + "~" + tds.sAnswers[qu, 3] + "~" + tds.sAnswers[qu].ToString() + "~" + tds.iAnswers[qu].ToString();          
                 for (qu = 0; qu < td.iQuestions; qu++)
                 {
                     s = obj.GetQuestionLine(usrID, qu);
                     string[] part = s.Split('~');
                     td.sQuestions[qu] = part[0];                     
                     td.sAnswers[qu, 0] = part[1];
                     td.sAnswers[qu, 1] = part[2];
                     td.sAnswers[qu, 2] = part[3];
                     td.sAnswers[qu, 3] = part[4];
                     //td.iAnswers[qu] = System.Convert.ToInt32(part[5]);
                     td.iAnswers[qu] = -1; // System.Convert.ToInt32(part[5]);
                     ad.didAnswered[qu] = -1;
                     ad.trueAnswers[qu] = System.Convert.ToInt32(part[5]);
                     ad.iAnswers = td.iQuestions;
                     td.iAnswers[qu] = -1; // System.Convert.ToInt32(part[5]); 
                 }

                 while (lxQuestions.Items.Count != 0) lxQuestions.Items.RemoveAt(0);
                 for (qu = 0; qu < td.iQuestions; qu++)
                     lxQuestions.Items.Insert(qu, td.sQuestions[qu]);

                 ChangeMode(MODE_READER_TEST);                 
                 SetVisibilityReaderMode(true);

                 currentQuestion = 0;
                 RefreshTestView(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 */
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbQuestion.Text = "";
            tbA.Text = "";
            tbB.Text = "";
            tbC.Text = "";
            tbD.Text = "";
        }

        private void btQuery_Click(object sender, EventArgs e)
        {
            //GetResultInfo(string usrName, string testName, int type)
            DataSet ds = obj.GetResultInfo(tbByUser.Text, "dffds", 2);
            try
            {
                //dgView.Fil
                dgView.DataSource = ds;
                dgView.DataMember = "Results";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btHide.Visible = true;
            }
        }

        private void viewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enlarge();
            tbByUser.Focus();
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            Shrink();
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            if (iMode == MODE_READER_SELECT_TEST) SelectTest();
        }
                                  

    }




    class UserInformation
    {
        const int USER = 0;
        const int AUTHOR = 1;
        const int NOBODY = -1;

        int userType = NOBODY;
        string userName = null;
        public UserInformation(int userT, string userN)
        {
            userType = userT;
            userName = userN;
        }
        public UserInformation()
        {

        }
    }
}