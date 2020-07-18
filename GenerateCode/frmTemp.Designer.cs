namespace Winform
{
    partial class frmTemp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new Winform.UserControls.Button();
            this.pageBarIncome = new Winform.UserControls.PageBar();
            this.dgvIncome = new Winform.UserControls.MyDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 27);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "新增模板";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSearch.Location = new System.Drawing.Point(672, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(1);
            this.btnSearch.Size = new System.Drawing.Size(82, 26);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "查询";
            // 
            // pageBarIncome
            // 
            this.pageBarIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pageBarIncome.BackColor = System.Drawing.Color.White;
            this.pageBarIncome.CurPage = 1;
            this.pageBarIncome.DataControl = null;
            this.pageBarIncome.DataSource = null;
            this.pageBarIncome.Location = new System.Drawing.Point(0, 462);
            this.pageBarIncome.MinimumSize = new System.Drawing.Size(350, 22);
            this.pageBarIncome.Name = "pageBarIncome";
            this.pageBarIncome.PageSize = 20;
            this.pageBarIncome.Size = new System.Drawing.Size(350, 22);
            this.pageBarIncome.TabIndex = 1;
            // 
            // dgvIncome
            // 
            this.dgvIncome.AllowUserToAddRows = false;
            this.dgvIncome.AllowUserToDeleteRows = false;
            this.dgvIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncome.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIncome.Location = new System.Drawing.Point(0, 33);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.ReadOnly = true;
            this.dgvIncome.RowTemplate.Height = 23;
            this.dgvIncome.Size = new System.Drawing.Size(1036, 423);
            this.dgvIncome.TabIndex = 0;
            this.dgvIncome.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIncome_CellMouseClick);
            this.dgvIncome.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvIncome_DataBindingComplete);
            // 
            // frmTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 487);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pageBarIncome);
            this.Controls.Add(this.dgvIncome);
            this.Name = "frmTemp";
            this.Text = "模板设置";
            this.Activated += new System.EventHandler(this.frmIncome_Activated);
            this.Shown += new System.EventHandler(this.frmIncome_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.MyDataGridView dgvIncome;
        private UserControls.PageBar pageBarIncome;
        private UserControls.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
    }
}