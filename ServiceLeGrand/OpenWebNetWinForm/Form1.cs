﻿using ServiceLegrand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenWebNetDataContract.Model;
using ServiceLegrand;

namespace OpenWebNetWinForm
{
    public partial class Form1 : Form
    {
        private ServiceHost host;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            host.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(ServiceLegrand.ServiceLegrand));
            host.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            ServiceLegrand.ServiceLegrand o = new ServiceLegrand.ServiceLegrand();

            //Test AddUser
            /*User user = new User();
            user = o.addUser("test", "test", "mail@mail.mail", "password");*/

            OpenWebNetDataContract.Model.Program program = new OpenWebNetDataContract.Model.Program();
            program = o.
            program = o.addProgram("name", DateTime.Now, null, null);

            Console.WriteLine("STOP");
            


        }
    }
}
