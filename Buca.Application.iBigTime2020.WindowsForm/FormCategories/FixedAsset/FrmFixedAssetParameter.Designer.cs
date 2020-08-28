namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset
{
    partial class FrmFixedAssetParameter
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
            this.cboSource = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Controls.Add(this.cboSource);
            this.groupboxMain.Size = new System.Drawing.Size(492, 34);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(343, 51);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(424, 51);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 51);
            // 
            // cboSource
            // 
            this.cboSource.Location = new System.Drawing.Point(120, 6);
            this.cboSource.Name = "cboSource";
            this.cboSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSource.Properties.Items.AddRange(new object[] {
            "TS hình thành từ nguồn NSNN thường xuyên",
            "TS hình thành từ nguồn NSNN không thường xuyên",
            "TS hình thành từ nguồn thu hoạt động khác",
            "TS hình thành từ nguồn phí, lệ phí",
            "TS hình thành từ nguồn viện trợ",
            "TS hình thành từ nguồn vay nợ nước ngoài",
            "TS hình thành từ  quỹ phát triển hoạt động sự nghiệp",
            "TS hình thành từ  quỹ phúc lợi",
            "TS hình thành từ các nguồn, quỹ khác"});
            this.cboSource.Size = new System.Drawing.Size(368, 20);
            this.cboSource.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nguồn hình thành TS";
            // 
            // FrmFixedAssetParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 85);
            this.Name = "FrmFixedAssetParameter";
            this.Text = "Nguồn hình thành tài sản";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboSource;
        private System.Windows.Forms.Label label1;
    }
}