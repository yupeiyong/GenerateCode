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
            this.txtTempContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExtention = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTempName
            // 
            this.txtTempName.Location = new System.Drawing.Point(81, 7);
            this.txtTempName.Name = "txtTempName";
            this.txtTempName.ReadOnly = true;
            this.txtTempName.Size = new System.Drawing.Size(264, 21);
            this.txtTempName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模板文件名：";
            // 
            // txtTempContent
            // 
            this.txtTempContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTempContent.Location = new System.Drawing.Point(81, 63);
            this.txtTempContent.Multiline = true;
            this.txtTempContent.Name = "txtTempContent";
            this.txtTempContent.Size = new System.Drawing.Size(571, 58);
            this.txtTempContent.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "内容：";
            // 
            // txtDestPath
            // 
            this.txtDestPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestPath.Location = new System.Drawing.Point(81, 34);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.Size = new System.Drawing.Size(500, 21);
            this.txtDestPath.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "目标位置：";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(576, 9);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(72, 16);
            this.chkOverwrite.TabIndex = 2;
            this.chkOverwrite.Text = "是否覆盖";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(584, 33);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(64, 23);
            this.btnOpenFolder.TabIndex = 3;
            this.btnOpenFolder.Text = "打开";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "扩展名：";
            // 
            // txtExtention
            // 
            this.txtExtention.Location = new System.Drawing.Point(423, 7);
            this.txtExtention.Name = "txtExtention";
            this.txtExtention.Size = new System.Drawing.Size(100, 21);
            this.txtExtention.TabIndex = 5;
            // 
            // TempSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtExtention);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTempContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTempName);
            this.Name = "TempSettingControl";
            this.Size = new System.Drawing.Size(655, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTempName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTempContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExtention;
    }
}
