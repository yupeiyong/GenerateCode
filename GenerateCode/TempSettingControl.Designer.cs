namespace Winform
{
    partial class TempSettingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTempName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.chkGenerate = new System.Windows.Forms.CheckBox();
            this.btnViewTemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTempName
            // 
            this.txtTempName.Location = new System.Drawing.Point(152, 4);
            this.txtTempName.Name = "txtTempName";
            this.txtTempName.ReadOnly = true;
            this.txtTempName.Size = new System.Drawing.Size(264, 21);
            this.txtTempName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模板文件名：";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(477, 6);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(72, 16);
            this.chkOverwrite.TabIndex = 2;
            this.chkOverwrite.Text = "是否覆盖";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // chkGenerate
            // 
            this.chkGenerate.AutoSize = true;
            this.chkGenerate.Location = new System.Drawing.Point(15, 6);
            this.chkGenerate.Name = "chkGenerate";
            this.chkGenerate.Size = new System.Drawing.Size(48, 16);
            this.chkGenerate.TabIndex = 6;
            this.chkGenerate.Text = "生成";
            this.chkGenerate.UseVisualStyleBackColor = true;
            // 
            // btnViewTemp
            // 
            this.btnViewTemp.Location = new System.Drawing.Point(426, 3);
            this.btnViewTemp.Name = "btnViewTemp";
            this.btnViewTemp.Size = new System.Drawing.Size(40, 23);
            this.btnViewTemp.TabIndex = 7;
            this.btnViewTemp.Text = "查看";
            this.btnViewTemp.UseVisualStyleBackColor = true;
            this.btnViewTemp.Click += new System.EventHandler(this.btnViewTemp_Click);
            // 
            // TempSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnViewTemp);
            this.Controls.Add(this.chkGenerate);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTempName);
            this.Name = "TempSettingControl";
            this.Size = new System.Drawing.Size(557, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTempName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkGenerate;
        private System.Windows.Forms.Button btnViewTemp;
    }
}
