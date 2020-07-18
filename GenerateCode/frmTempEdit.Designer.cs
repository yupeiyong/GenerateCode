namespace Winform
{
    partial class frmTempEdit
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
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtAmount = new Winform.UserControls.TextBox();
            this.SuspendLayout();
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTelephone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtTelephone.ForeColor = System.Drawing.Color.Crimson;
            this.txtTelephone.Location = new System.Drawing.Point(309, 13);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.ReadOnly = true;
            this.txtTelephone.Size = new System.Drawing.Size(144, 23);
            this.txtTelephone.TabIndex = 0;
            this.txtTelephone.TabStop = false;
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtNumber.ForeColor = System.Drawing.Color.Crimson;
            this.txtNumber.Location = new System.Drawing.Point(517, 11);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(144, 23);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "电话：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(460, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "房间号：";
            // 
            // txtTenantName
            // 
            this.txtTenantName.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTenantName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTenantName.ForeColor = System.Drawing.Color.Crimson;
            this.txtTenantName.Location = new System.Drawing.Point(93, 13);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.ReadOnly = true;
            this.txtTenantName.Size = new System.Drawing.Size(144, 23);
            this.txtTenantName.TabIndex = 0;
            this.txtTenantName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "租户姓名：";
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarForeColor = System.Drawing.Color.Blue;
            this.dtpStart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStart.Location = new System.Drawing.Point(93, 50);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(144, 23);
            this.dtpStart.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "收款日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "收款金额：";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Winform.Properties.Resources.Save32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(504, 47);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 115;
            this.btnSave.Text = "保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Winform.Properties.Resources.Close;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(585, 47);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 35);
            this.btnExit.TabIndex = 115;
            this.btnExit.Text = "取消";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAmount.Location = new System.Drawing.Point(309, 47);
            this.txtAmount.Multiline = false;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Padding = new System.Windows.Forms.Padding(1);
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmount.Size = new System.Drawing.Size(144, 27);
            this.txtAmount.TabIndex = 2;
            // 
            // frmIncomeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 87);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTenantName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIncomeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收款编辑";
            this.Load += new System.EventHandler(this.frmIncomeEdit_Load);
            this.Shown += new System.EventHandler(this.frmIncomeEdit_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTenantName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label17;
        private UserControls.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
    }
}