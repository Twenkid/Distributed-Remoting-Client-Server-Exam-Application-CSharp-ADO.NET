using System;
using System.Collections;
using System.Text;

namespace WindowsApplication2
{

    class AnswersData
    {
      public const int MAX_QUESTIONS = 50;
      public const int MAX_ANSWERS = 4;
      public int maxQuestions;
      public int maxAnswers;
      public int[] trueAnswers;
      public int[] didAnswered;
      public int iAnswers = 0;
      public int iAnswered = 0;
      public int iDidAnswered = 0;
      
      public void Init()
      {
          maxQuestions = MAX_QUESTIONS;
            maxAnswers = MAX_ANSWERS;
            trueAnswers = new int[MAX_QUESTIONS];
            didAnswered = new int[MAX_QUESTIONS];
            iAnswers = 0;
            iDidAnswered = 0;

            iAnswers = 5;
            for (int i = 0; i < iAnswers; i++)
                trueAnswers[i] = i % 4;            
      }
      public AnswersData()
        {
            Init();
        }

        public AnswersData(int n, int[] an)
        {
            Init();
            for (int i = 0; i < n; i++)
                trueAnswers[i] = an[i];            
        }

      public void Clear()
      {
          int i;
          for (i = 0; i < maxQuestions; i++)
          {
              trueAnswers[i] = -1;
              didAnswered[i] = -1;
          }
          iDidAnswered = 0;
      }

        public void SetAnswer(int i, int an)
        {
            didAnswered[i] = an;
        }

        public void SetTrueAnswers(int n, int[] an)
        {
            for(int i=0; i<n; i++)
               trueAnswers[i] = an[i];
        }

        public float GetTotalResult()
        {
            int i, tr = 0;
            for (i = 0; i < iAnswers; i++)
                if (trueAnswers[i] == didAnswered[i]) tr++;
            return (float)tr / (float) iAnswers;
        }
    }


    class TestData : Object
    {

        public const int MAX_QUESTIONS = 100;
        public const int MAX_ANSWERS   = 4;
        public string sTitle;
        public int iQuestions;
        //List    list = new List<
        public string[] sQuestions;
        public string[,] sAnswers; // = new string[MAX_QUESTIONS, MAX_ANSWERS];
        public int[] iAnswers;
        public int maxQuestions = MAX_QUESTIONS;
        public int maxAnswers = MAX_ANSWERS;

        //ArrayList Stuff = new ArrayList(50);
        
        public TestData()
        {
            maxQuestions = MAX_QUESTIONS;
            maxAnswers = MAX_ANSWERS;
            sQuestions = new string[MAX_QUESTIONS];
            sAnswers   = new string[MAX_QUESTIONS, MAX_ANSWERS];
            iAnswers = new int[MAX_QUESTIONS];
            Clear();
            //Test1();
        }

        public void Clear()
        {
            int i,j;

            iQuestions = 1;
            for (i = 0; i < MAX_QUESTIONS; i++)
            {
                sQuestions[i] = "";
                iAnswers[i] = -1;
            }
                    
            
            for (i = 0; i < MAX_QUESTIONS; i++)
               for (j = 0; j < MAX_ANSWERS; j++)
            {
                sAnswers[i,j] = "";
            }

        sTitle = "Nonamed";

        iQuestions = 0; 

        maxQuestions = MAX_QUESTIONS;
        maxAnswers = MAX_ANSWERS;
        }

        public void Test1()
        {
            iQuestions = 0;
            sTitle = "Математика";
            sQuestions[0] = "Кое е най-голямото число?";
            sAnswers[0,0] = "2";
            sAnswers[0,1] = "10101011011";
            sAnswers[0,2] = "4534995353";
            sAnswers[0,3] = "АНЦДкцодддф";
            iAnswers[0] = 3;                        
        }

        public void AddQuestion(string question, string[] answers, int trueAnswer)
        {

        }

        public void Copy(TestData dst)
        {
            int i,j;

            dst.sTitle = this.sTitle;
            dst.iQuestions = this.iQuestions;

            for (i = 0; i < this.iQuestions; i++)
            {
                dst.sQuestions[i] = this.sQuestions[i];
                dst.iAnswers[i] = this.iAnswers[i];
            }

            for (i = 0; i < this.iQuestions; i++)
                for (j = 0; i < this.maxQuestions; i++)
                    dst.sAnswers[i, j] = this.sAnswers[i, j];

        }

        public void SetTitle(string t)
        {
            sTitle = t;
        }

        public string GetTitle(string t)
        {
            return sTitle;
        }

        public void SetQuestionText(int n, string text)
        {
            sQuestions[n] = text;
        }

        public string GetQuestionText(int n)
        {
            return sQuestions[n];
        }

        //Question q, answer n, true is tr
        public void SetAnswerText(int q, int n, string answ, int tr)
        {
            sAnswers[q, n] = answ;
            iAnswers[q]    = tr;
        }

        public string GetAnswerText(int q, int n)   
        {
            return sAnswers[q, n];
        }

        public int GetAnswerTrue(int q)
        {
            return iAnswers[q];
        }

        public void SetFourAnswersText(int q, string a0, string a1, string a2, string a3, int tr)
        {
            sAnswers[q, 0] = a0;
            sAnswers[q, 1] = a1;
            sAnswers[q, 2] = a2;
            sAnswers[q, 3] = a3;
            iAnswers[q]    = tr;
        }        

    }
}
