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
    public partial class FormSaveList : Form
    {

        public string ListName;

        public FormSaveList()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            ListName = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
