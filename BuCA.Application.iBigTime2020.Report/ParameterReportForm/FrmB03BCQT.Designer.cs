﻿namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmB03BCQT
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
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.cboBudgetChapter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Location = new System.Drawing.Point(8, 10);
            this.groupboxMain.Size = new System.Drawing.Size(322, 156);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(109, 173);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(190, 173);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 173);
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(2, 2);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(301, 72);
            this.dateTimeRangeV1.TabIndex = 13;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // cboBudgetChapter
            // 
            this.cboBudgetChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetChapter.Location = new System.Drawing.Point(49, 27);
            this.cboBudgetChapter.Name = "cboBudgetChapter";
            this.cboBudgetChapter.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetChapter.Properties.NullText = "";
            this.cboBudgetChapter.Properties.PopupWidth = 380;
            this.cboBudgetChapter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetChapter.Size = new System.Drawing.Size(248, 20);
            this.cboBudgetChapter.TabIndex = 24;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Chương";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboBudgetChapter);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(18, 101);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(305, 56);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Điều kiện";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(17, 19);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(305, 76);
            this.groupControl1.TabIndex = 10;
            // 
            // FrmB03BCQT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 210);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmB03BCQT";
            this.Text = "FrmB03BCQT";
            this.Load += new System.EventHandler(this.FrmB03BCQT_Load);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetChapter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;

    }
}