using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GenerateCode.Models;
using Winform.Helpers;
using Winform.UserControls.DataGridViewColumn;

namespace Winform
{
    public partial class frmTemp : Form
    {
        public frmTemp()
        {
            InitializeComponent();

            SetIncomeDataGridViewColumns();
        }

        private void frmIncome_Shown(object sender, EventArgs e)
        {
            BindDataGrid();
        }


        private void SetIncomeDataGridViewColumns()
        {
            DataGridViewHelper.SetColumns<Template>(dgvIncome,
                new List<string>
                {
                    nameof(Template.FileName)
                });

            var actionColumn = new DataGridViewActionButtonColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "操作",
                Name = "ColAction",
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                Width = 160
            };
            dgvIncome.Columns.Add(actionColumn);
        }


        private void dgvIncome_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //用户单击DataGridView“操作”列中的“查看”按钮。
            if (DataGridViewTwoButtonCell.IsLeftButtonClick(sender, e))
            {
                var fileFullName = dgvIncome["ColAction", e.RowIndex].Value.ToString(); // 获取所要删除关联对象的主键。
                var result = MessageBox.Show($"{fileFullName}的模板文件,确认修改吗？", "确认", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    OpenFile.Open(fileFullName);
                }
            }


            //用户单击DataGridView“操作”列中的“删除”按钮。
            if (DataGridViewTwoButtonCell.IsRightButtonClick(sender, e))
            {
                var fileFullName = dgvIncome["ColAction", e.RowIndex].Value.ToString(); // 获取所要删除关联对象的主键。
                var result = MessageBox.Show($"{fileFullName}的模板文件,确认删除吗？", "确认", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    File.Delete(fileFullName);
                    BindDataGrid();
                }
            }
        }


        private void BindDataGrid()
        {
            var root = AppDomain.CurrentDomain.BaseDirectory + @"\Temps";
            var rootDir = new DirectoryInfo(root);
            if (!rootDir.Exists)
                rootDir.Create();

            var files = rootDir.GetFiles("*.temp");
            dgvIncome.DataSource = files;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void frmIncome_Activated(object sender, EventArgs e)
        {
            BindDataGrid();
        }


        private void dgvIncome_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dgvIncome.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvIncome.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        this.dgvIncome.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Bisque;
                    }
                    else
                    {
                        this.dgvIncome.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
            dgvIncome.AutoSizeColumns(new List<string>() { "ColAction" });
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}