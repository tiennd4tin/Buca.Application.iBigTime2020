namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmC4_09
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
            this.chkIsShowDate = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsShowAllDetail = new DevExpress.XtraEditors.CheckEdit();
            this.txtAccountDebit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountCredit = new DevExpress.XtraEditors.TextEdit();
            this.chkIsGroup = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowAllDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCredit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.groupboxMain.Controls.Add(this.chkIsGroup);
            this.groupboxMain.Controls.Add(this.txtAccountCredit);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtAccountDebit);
            this.groupboxMain.Controls.Add(this.chkIsShowAllDetail);
            this.groupboxMain.Controls.Add(this.chkIsShowDate);
            this.groupboxMain.Size = new System.Drawing.Size(280, 110);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(133, 134);
            this.btnOk.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(214, 134);
            this.btnExit.TabIndex = 7;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 134);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Visible = false;
            // 
            // chkIsShowDate
            // 
            this.chkIsShowDate.Location = new System.Drawing.Point(149, 61);
            this.chkIsShowDate.Name = "chkIsShowDate";
            this.chkIsShowDate.Properties.Caption = "Hiển thị ngày tháng";
            this.chkIsShowDate.Size = new System.Drawing.Size(126, 19);
            this.chkIsShowDate.TabIndex = 4;
            // 
            // chkIsShowAllDetail
            // 
            this.chkIsShowAllDetail.Location = new System.Drawing.Point(17, 60);
            this.chkIsShowAllDetail.Name = "chkIsShowAllDetail";
            this.chkIsShowAllDetail.Properties.Caption = "Hiển thị chi tiết";
            this.chkIsShowAllDetail.Size = new System.Drawing.Size(126, 19);
            this.chkIsShowAllDetail.TabIndex = 3;
            // 
            // txtAccountDebit
            // 
            this.txtAccountDebit.Location = new System.Drawing.Point(66, 12);
            this.txtAccountDebit.Name = "txtAccountDebit";
            this.txtAccountDebit.Size = new System.Drawing.Size(200, 20);
            this.txtAccountDebit.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "TK Nợ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "TK Có";
            // 
            // txtAccountCredit
            // 
            this.txtAccountCredit.Location = new System.Drawing.Point(66, 36);
            this.txtAccountCredit.Name = "txtAccountCredit";
            this.txtAccountCredit.Size = new System.Drawing.Size(200, 20);
            this.txtAccountCredit.TabIndex = 2;
            // 
            // chkIsGroup
            // 
            this.chkIsGroup.Location = new System.Drawing.Point(17, 82);
            this.chkIsGroup.Name = "chkIsGroup";
            this.chkIsGroup.Properties.Caption = "Tổng hợp";
            this.chkIsGroup.Size = new System.Drawing.Size(126, 19);
            this.chkIsGroup.TabIndex = 5;
            // 
            // FrmC4_09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 168);
            this.Name = "FrmC4_09";
            this.Text = "Giấy rút tiền mặt";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowAllDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCredit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsShowDate;
        private DevExpress.XtraEditors.CheckEdit chkIsShowAllDetail;
        private DevExpress.XtraEditors.TextEdit txtAccountCredit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAccountDebit;
        private DevExpress.XtraEditors.CheckEdit chkIsGroup;
    }
}