namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmC55HD
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
            this.chkIsDetailByFixedAsset = new DevExpress.XtraEditors.CheckEdit();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDetailByFixedAsset.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.chkIsDetailByFixedAsset);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Location = new System.Drawing.Point(8, 8);
            this.groupboxMain.Size = new System.Drawing.Size(324, 109);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(179, 126);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(260, 126);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 126);
            // 
            // chkIsDetailByFixedAsset
            // 
            this.chkIsDetailByFixedAsset.EditValue = true;
            this.chkIsDetailByFixedAsset.Location = new System.Drawing.Point(7, 86);
            this.chkIsDetailByFixedAsset.Name = "chkIsDetailByFixedAsset";
            this.chkIsDetailByFixedAsset.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkIsDetailByFixedAsset.Properties.Caption = "Chi tiết theo từng tài sản cố định";
            this.chkIsDetailByFixedAsset.Size = new System.Drawing.Size(303, 19);
            this.chkIsDetailByFixedAsset.TabIndex = 26;
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(9, 9);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(306, 72);
            this.dateTimeRangeV1.TabIndex = 25;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // FrmC55HD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 160);
            this.Name = "FrmC55HD";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDetailByFixedAsset.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsDetailByFixedAsset;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
    }
}