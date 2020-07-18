using System;
using System.Windows.Forms;

namespace Winform
{
    public partial class frmTempEdit : Form
    {
        public frmTempEdit()
        {
            InitializeComponent();
        }

        public string FileFullName { get; set; }

        private void frmIncomeEdit_Load(object sender, System.EventArgs e)
        {

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            double amount = 0D;
            if (!double.TryParse(txtAmount.Text, out amount))
            {
                throw new Exception("请输入正确的收款金额！");
            }

            this.Close();
        }

        private void frmIncomeEdit_Shown(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FileFullName))
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}