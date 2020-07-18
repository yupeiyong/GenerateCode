using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace WinForm.UI
{
    public partial class FormSysMessage : Form
    {
        private static readonly Size detailModeSize = new Size(700, 350);


        private FormSysMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     显示异常信息，该方法为静态方法，可以直接进行调用。
        /// </summary>
        public static void ShowException(Exception exception)
        {
            var formSysMessage = new FormSysMessage();
            formSysMessage.LblMessage.Text = exception.Message;

            formSysMessage.LblDetailMessage.Visible = true;
            formSysMessage.Size = detailModeSize;
            formSysMessage.ShowDialog();
        }


        /// <summary>
        ///     显示一般类信息提示。
        /// </summary>
        public static void ShowMessage(string message)
        {
            var formSysMessage = new FormSysMessage();
            formSysMessage.LblMessage.Text = message;
            formSysMessage.ShowDialog();
        }

        /// <summary>
        ///     用户单击“确定”按钮时的事件处理方法。
        /// </summary>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}