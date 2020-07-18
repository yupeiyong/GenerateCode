using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Models;

namespace Winform
{
    public partial class TempSettingControl : UserControl
    {
        public TempSettingControl()
        {
            InitializeComponent();
        }

        public TempSettingControl(string tempName):this()
        {
            txtTempName.Text = tempName;
        }

        public GenerateSettings GetSettings()
        {
            var settings = new GenerateSettings
            {
                TemplateFileName=txtTempName.Text,
                DestPath=txtDestPath.Text,
                Extention=txtExtention.Text,
                OverWrite=chkOverwrite.Checked
            };

            return settings;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            var f=new FolderBrowserDialog();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                txtDestPath.Text= f.SelectedPath;
            }
        }
    }
}
