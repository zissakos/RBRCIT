using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RBRCIT
{
    public partial class FormCarSettings : Form
    {
        public Car CurrentCar;
        public bool UseAudio;

        public FormCarSettings()
        {
            InitializeComponent();
        }


        private void FormCarSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = "subaru";

            if (UseAudio)
            {
                DirectoryInfo di = new DirectoryInfo("Audio\\Cars");
                FileInfo[] lists = di.GetFiles("*.eng");
                listBox1.Items.Clear();
                foreach (FileInfo fi in lists)
                {
                    listBox1.Items.Add(fi.Name.ToLower().Replace(".eng", ""));
                }


                if (CurrentCar.userSettings.engineSound != null)
                {
                    radioButton2.Checked = true;
                    int index = listBox1.FindStringExact(CurrentCar.userSettings.engineSound);
                    if (index != -1) listBox1.SelectedIndex = index;
                }
                else
                {
                    radioButton1.Checked = true;
                    radioButton2_CheckedChanged(null, null);
                }
            }
            else
            {
                groupBox1.Enabled = false;
            }
            cbHideSteeringWheel.Checked = CurrentCar.userSettings.hideSteeringWheel;
            cbHideWipers.Checked = CurrentCar.userSettings.hideWipers;
            cbHideWindShield.Checked = CurrentCar.userSettings.hideWindShield;
            cbMirrorSteeringWheel.Checked = CurrentCar.userSettings.mirrorSteeringWheel;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Enabled = radioButton2.Checked;
            if (listBox1.Enabled) listBox1.BackColor = Color.White;
            else listBox1.BackColor = Color.FromArgb(230,230,230);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) CurrentCar.userSettings.engineSound = textBox1.Text;
            else CurrentCar.userSettings.engineSound = listBox1.SelectedItem.ToString();
            CurrentCar.userSettings.hideSteeringWheel = cbHideSteeringWheel.Checked;
            CurrentCar.userSettings.hideWipers = cbHideWipers.Checked;
            CurrentCar.userSettings.hideWindShield = cbHideWindShield.Checked;
            CurrentCar.userSettings.mirrorSteeringWheel = cbMirrorSteeringWheel.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }




    }
}
