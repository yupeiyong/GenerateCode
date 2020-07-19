using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public string InputContent;
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            InputContent = txtInput.Text;
        }

        public static string GetText()
        {
            var box=new InputBox();
            if (box.ShowDialog() == DialogResult.OK)
            {
                return box.InputContent;
            }
            return string.Empty;
        }
    }
}
