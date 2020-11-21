using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {           
            Point p1 = new Point();
            p1.X = 20;
            p1.Y = 30;
            this.PointToClient(p1);
        }

        public string username
        {
            get
            {
                return tbUsername.Text;
            }
        }

        public string password
        {
            get
            {
                return tbPassword.Text;
            }
        }
    }
}