using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RBRCIT
{
    public partial class FormAbout : Form
    {
        public FormAbout(string v)
        {
            InitializeComponent();

            label1.Text = "RBRCIT - RichardBurnsRally Car Installation Tool" + Environment.NewLine;
            label1.Text += "Version: " + v + Environment.NewLine;
            label1.Text += "(c) 2017 by zissakos " + Environment.NewLine;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
