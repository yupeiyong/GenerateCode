using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class frmHelper : Form
    {
        public frmHelper()
        {
            InitializeComponent();
        }

        private void frmHelper_Load(object sender, EventArgs e)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data";
            var fileName = Path.Combine(root, "模板设置说明.txt");
            textBox1.Text = File.ReadAllText(fileName);
        }
    }
}
