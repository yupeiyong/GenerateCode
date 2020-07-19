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
using System.IO;
using Winform.Helpers;

namespace Winform
{
    public partial class TempSettingControl : UserControl
    {
        public TempSettingControl()
        {
            InitializeComponent();
        }

        public TempSettingControl(string tempName) : this()
        {
            txtTempName.Text = tempName;
        }

        public GenerateSettings GetSettings()
        {
            var settings = new GenerateSettings
            {
                TemplateFileName = txtTempName.Text,
                DestPath = txtDestPath.Text,
                Extention = txtExtention.Text,
                OverWrite = chkOverwrite.Checked,
                IsGenerate = chkGenerate.Checked
            };

            return settings;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            var f = new FolderBrowserDialog();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                txtDestPath.Text = f.SelectedPath;
            }
        }

        private void btnViewTemp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTempName.Text))
                throw new Exception("模板文件名为空！");

            var root = AppDomain.CurrentDomain.BaseDirectory + @"\Temps";
            var fileFullName = Path.Combine(root, txtTempName.Text);
            if (!File.Exists(fileFullName))
                throw new Exception("模板文件不存在！");

            OpenFile.Open(fileFullName);
        }
    }
}
