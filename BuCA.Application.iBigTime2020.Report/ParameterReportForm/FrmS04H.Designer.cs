namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS04H
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
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cboSelectDesignReport = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.checkcboBudgetKindItem = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.checkcboBudgetChapter = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.checkcboBudgetSource = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.rndOption = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.checkAddSameEntry = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectDesignReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkAddSameEntry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Controls.Add(this.groupControl4);
            this.groupboxMain.Controls.Add(this.groupControl3);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Size = new System.Drawing.Size(339, 190);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(190, 205);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(271, 205);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 205);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 3);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(310, 124);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.cboSelectDesignReport);
            this.groupControl4.Location = new System.Drawing.Point(5, 241);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(323, 32);
            this.groupControl4.TabIndex = 21;
            this.groupControl4.Text = "Mẫu báo cáo";
            this.groupControl4.Visible = false;
            // 
            // cboSelectDesignReport
            // 
            this.cboSelectDesignReport.EditValue = "";
            this.cboSelectDesignReport.Location = new System.Drawing.Point(12, 24);
            this.cboSelectDesignReport.Name = "cboSelectDesignReport";
            this.cboSelectDesignReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSelectDesignReport.Properties.NullText = "";
            this.cboSelectDesignReport.Properties.PopupFormMinSize = new System.Drawing.Size(650, 0);
            this.cboSelectDesignReport.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.cboSelectDesignReport.Properties.PopupWidth = 500;
            this.cboSelectDesignReport.Size = new System.Drawing.Size(303, 20);
            this.cboSelectDesignReport.TabIndex = 2;
            this.cboSelectDesignReport.Visible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.checkcboBudgetKindItem);
            this.groupControl2.Controls.Add(this.checkcboBudgetChapter);
            this.groupControl2.Controls.Add(this.checkcboBudgetSource);
            this.groupControl2.Controls.Add(this.rndOption);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(317, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(11, 45);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Visible = false;
            // 
            // checkcboBudgetKindItem
            // 
            this.checkcboBudgetKindItem.EditValue = "";
            this.checkcboBudgetKindItem.Location = new System.Drawing.Point(58, 59);
            this.checkcboBudgetKindItem.Name = "checkcboBudgetKindItem";
            this.checkcboBudgetKindItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkcboBudgetKindItem.Properties.SelectAllItemVisible = false;
            this.checkcboBudgetKindItem.Size = new System.Drawing.Size(227, 20);
            this.checkcboBudgetKindItem.TabIndex = 93;
            // 
            // checkcboBudgetChapter
            // 
            this.checkcboBudgetChapter.EditValue = "";
            this.checkcboBudgetChapter.Location = new System.Drawing.Point(58, 32);
            this.checkcboBudgetChapter.Name = "checkcboBudgetChapter";
            this.checkcboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkcboBudgetChapter.Properties.SelectAllItemVisible = false;
            this.checkcboBudgetChapter.Size = new System.Drawing.Size(227, 20);
            this.checkcboBudgetChapter.TabIndex = 92;
            // 
            // checkcboBudgetSource
            // 
            this.checkcboBudgetSource.EditValue = "";
            this.checkcboBudgetSource.Location = new System.Drawing.Point(58, 7);
            this.checkcboBudgetSource.Name = "checkcboBudgetSource";
            this.checkcboBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkcboBudgetSource.Properties.SelectAllItemVisible = false;
            this.checkcboBudgetSource.Size = new System.Drawing.Size(227, 20);
            this.checkcboBudgetSource.TabIndex = 91;
            // 
            // rndOption
            // 
            this.rndOption.EditValue = "09";
            this.rndOption.Location = new System.Drawing.Point(9, 83);
            this.rndOption.Name = "rndOption";
            this.rndOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rndOption.Properties.Columns = 3;
            this.rndOption.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rndOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("03", "Tất cả"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("06", "Tổng hợp"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("09", "Tùy chọn")});
            this.rndOption.Size = new System.Drawing.Size(271, 31);
            this.rndOption.TabIndex = 90;
            this.rndOption.SelectedIndexChanged += new System.EventHandler(this.rndOption_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 89;
            this.labelControl1.Text = "Khoản";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(38, 13);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "Chương";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 13);
            this.labelControl5.TabIndex = 65;
            this.labelControl5.Text = "Nguồn";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.Controls.Add(this.checkAddSameEntry);
            this.groupControl3.Location = new System.Drawing.Point(5, 146);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(323, 39);
            this.groupControl3.TabIndex = 20;
            // 
            // checkAddSameEntry
            // 
            this.checkAddSameEntry.EditValue = null;
            this.checkAddSameEntry.Location = new System.Drawing.Point(9, 11);
            this.checkAddSameEntry.Name = "checkAddSameEntry";
            this.checkAddSameEntry.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkAddSameEntry.Properties.Caption = "Cộng gộp các bút toán giống nhau";
            this.checkAddSameEntry.Size = new System.Drawing.Size(483, 19);
            this.checkAddSameEntry.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(323, 135);
            this.groupControl1.TabIndex = 22;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "Chọn kỳ báo cáo";
            // 
            // FrmS04H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 242);
            this.Name = "FrmS04H";
            this.Text = "Số Nhật ký chung";
            this.Load += new System.EventHandler(this.FrmS04H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectDesignReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkAddSameEntry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LookUpEdit cboSelectDesignReport;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        public DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.CheckEdit checkAddSameEntry;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.RadioGroup rndOption;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkcboBudgetKindItem;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkcboBudgetChapter;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkcboBudgetSource;
    }
}