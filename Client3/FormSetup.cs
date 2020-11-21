using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * Distributed Access to a Database with tests for examination,
 * students (users) can take the tests etc.
 * Using OleDB and network access. Developed in C#.
 * Author: Todor Arnaudov, 12/2006. @ Github: 11/2020
 * License: MIT
 *
 * The Setup Form
*/

namespace WindowsApplication2
{
    public partial class FormSetup : Form
    {
        string ipAddress;
        string    ipPort;

        public FormSetup()
        {
            InitializeComponent();
            tbAddress.Text = ipAddress;
            tbPort.Text = ipPort;
        }

        private bool checkIPAddress(string ip)
        {
            string[] parts = ip.Split('.');
            StringBuilder result = new StringBuilder(100);
            int i, v=0;

            //if (System.Convert.ToInt32(parts[0]))
            //MessageBox.Show(parts[0] + "." + parts[1], "AAAAAAAAA???");

            
            if ((parts.Length != 4)) return false;
            for (i = 0; i < 4; i++)
            {
                try
                {
                    v = System.Convert.ToInt32(parts[i]);
                }
                catch (Exception ex)
                {
                    v = -1;
                }
              if ((v < 0) || (v > 255)) return false;
            }
                                    
           if (i < 4) return false;
            return true;                        
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            string address = tbAddress.Text, tPort = tbPort.Text;
            int iPort;
            bool numberAddress;

            if ((!address.Equals("local")) && (!address.Equals("localhost")))
            {
                numberAddress = checkIPAddress(address);
                if (!numberAddress)
                {
                    //MessageBox.Show("The format of IP Address is A.B.C.D where A, B, C, D are integer numbers between 0 and 255");
                    MessageBox.Show("Incorrect IP address!", address);
                }
                else ipAddress = address;
            }

            try
            {
                iPort = System.Convert.ToInt32(tPort);
                ipPort = tPort;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect Port!", tPort);
            }
        }
        
        public string getIPAddress
        {
            get{
                    return ipAddress;
               }
           set
               {
                   ipAddress = value;
                   tbAddress.Text = ipAddress;
               }
        }

        public string getPort
        {
            get{
                    return ipPort;
               }
            set
               {
                   ipPort = value;
                   tbPort.Text = ipPort;
               }
        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            tbAddress.Text = ipAddress = "localhost";
            tbPort.Text = ipPort = "8001";
        }                       

    }
}