using System;
using System.Collections.Generic;
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
                DataPropertyName = "Id",
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
                var objectId = dgvIncome["ColAction", e.RowIndex].Value.ToString(); // 获取所要删除关联对象的主键。
                var result = MessageBox.Show($"Id={objectId}的记录确认修改吗？", "确认", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    var frm = new frmTempEdit { FileFullName = objectId };
                    frm.ShowDialog(this);
                    frm = null;
                    BindDataGrid();
                }
            }


            //用户单击DataGridView“操作”列中的“删除”按钮。
            if (DataGridViewTwoButtonCell.IsRightButtonClick(sender, e))
            {
                var objectId = dgvIncome["ColAction", e.RowIndex].Value.ToString(); // 获取所要删除关联对象的主键。
                var result = MessageBox.Show($"确认删除Id={objectId}的记录吗？", "确认", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    long id;
                    if (long.TryParse(objectId, out id))
                    {
                        BindDataGrid();
                    }
                    else
                    {
                        throw new Exception("Id类型错误！");
                    }
                }

                //Delete.LoadDataById(objectId);                                       // 根据关联对象的主键，从数据库中获取信息。
                //FormMain.LoadNewControl(Delete.Instance);                            // 载入该模块的删除信息界面至主窗体显示。
            }
        }


        private void BindDataGrid()
        {
            pageBarIncome.DataControl = dgvIncome;
            var startIndex = pageBarIncome.CurPage <= 0
                ? 0
                : (pageBarIncome.CurPage - 1) * pageBarIncome.PageSize;

            //var searchDto = new IncomeSearchDto
            //{
            //    IsGetTotalCount = true,
            //    Start = dtpStart.Value,
            //    End = dtpEnd.Value,
            //    PageSize = pageBarIncome.PageSize,
            //    StartIndex = startIndex,
            //    Keywords=txtKeywords.Text
            //};

            //if (_isIncomeingSearch)
            //{
            //    searchDto.Start = DateTime.Now.Date;
            //    searchDto.End = DateTime.Now.Date;
            //}

            //if (_leaseContractId.HasValue)
            //{
            //    searchDto.LeaseContractId = _leaseContractId.Value;
            //}

            //var informations = _incomeService.Search(searchDto);
            //pageBarIncome.DataSource = new PageData
            //{
            //    //当前页数，如果无记录，默认为1，否则按实际页面
            //    PageCount =
            //        searchDto.TotalCount > 0
            //            ? (int)Math.Ceiling((double)searchDto.TotalCount / pageBarIncome.PageSize)
            //            : 1,
            //    CurPage = pageBarIncome.CurPage,
            //    PageSize = pageBarIncome.PageSize,
            //    PageList = informations,
            //    RecordCount = searchDto.TotalCount
            //};
            pageBarIncome.DataBind();
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

        private int? _leaseContractId;

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}