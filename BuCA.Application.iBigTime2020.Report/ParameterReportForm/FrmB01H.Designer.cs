namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmB01H 
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboBudgetChapter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetSourceId = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cboBudgetKindItem = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboAccountGrade = new DevExpress.XtraEditors.LookUpEdit();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chkIsAddDataMonth13 = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsPrintMonth13 = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsPrintAccountDecided = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsSummarySource = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSourceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAddDataMonth13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPrintMonth13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPrintAccountDecided.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSummarySource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl3);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Size = new System.Drawing.Size(571, 156);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(420, 173);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(501, 173);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 173);
            // 
            // groupControl1
            // 
            this.groupControl1.Location = new System.Drawing.Point(10, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(301, 145);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chọn kỳ báo cáo";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboBudgetChapter);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.cboBudgetSourceId);
            this.groupControl2.Controls.Add(this.cboBudgetKindItem);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cboAccountGrade);
            this.groupControl2.Location = new System.Drawing.Point(318, 1);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(243, 145);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Điều kiện";
            // 
            // cboBudgetChapter
            // 
            this.cboBudgetChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetChapter.Location = new System.Drawing.Point(52, 59);
            this.cboBudgetChapter.Name = "cboBudgetChapter";
            this.cboBudgetChapter.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetChapter.Properties.NullText = "";
            this.cboBudgetChapter.Properties.PopupWidth = 380;
            this.cboBudgetChapter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetChapter.Size = new System.Drawing.Size(180, 20);
            this.cboBudgetChapter.TabIndex = 24;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Khoản";
            // 
            // cboBudgetSourceId
            // 
            this.cboBudgetSourceId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetSourceId.Location = new System.Drawing.Point(52, 33);
            this.cboBudgetSourceId.Name = "cboBudgetSourceId";
            this.cboBudgetSourceId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetSourceId.Size = new System.Drawing.Size(180, 20);
            this.cboBudgetSourceId.TabIndex = 34;
            // 
            // cboBudgetKindItem
            // 
            this.cboBudgetKindItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetKindItem.Location = new System.Drawing.Point(52, 87);
            this.cboBudgetKindItem.Name = "cboBudgetKindItem";
            this.cboBudgetKindItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetKindItem.Size = new System.Drawing.Size(180, 20);
            this.cboBudgetKindItem.TabIndex = 38;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Chương";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "Bậc TK";
            // 
            // cboAccountGrade
            // 
            this.cboAccountGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAccountGrade.Location = new System.Drawing.Point(52, 113);
            this.cboAccountGrade.Name = "cboAccountGrade";
            this.cboAccountGrade.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboAccountGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboAccountGrade.Properties.NullText = "";
            this.cboAccountGrade.Properties.PopupWidth = 380;
            this.cboAccountGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboAccountGrade.Size = new System.Drawing.Size(180, 20);
            this.cboAccountGrade.TabIndex = 25;
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(12, 19);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(296, 72);
            this.dateTimeRangeV1.TabIndex = 12;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(327, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Nguồn";
            // 
            // labelControl5
            // 
            this.labelControl5.AllowHtmlString = true;
            this.labelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.Location = new System.Drawing.Point(9, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(85, 13);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "Mẫu báo cáo";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit1.Location = new System.Drawing.Point(75, 24);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Properties.PopupWidth = 400;
            this.lookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit1.Size = new System.Drawing.Size(11, 20);
            this.lookUpEdit1.TabIndex = 31;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.chkIsAddDataMonth13);
            this.groupControl3.Controls.Add(this.chkIsPrintMonth13);
            this.groupControl3.Controls.Add(this.chkIsPrintAccountDecided);
            this.groupControl3.Controls.Add(this.chkIsSummarySource);
            this.groupControl3.Controls.Add(this.lookUpEdit1);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Enabled = false;
            this.groupControl3.Location = new System.Drawing.Point(466, 260);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(97, 25);
            this.groupControl3.TabIndex = 33;
            this.groupControl3.Text = "Chọn mẫu báo cáo";
            this.groupControl3.Visible = false;
            // 
            // chkIsAddDataMonth13
            // 
            this.chkIsAddDataMonth13.Enabled = false;
            this.chkIsAddDataMonth13.Location = new System.Drawing.Point(7, 110);
            this.chkIsAddDataMonth13.Name = "chkIsAddDataMonth13";
            this.chkIsAddDataMonth13.Properties.Caption = "Bao gồm chứng từ chỉnh lý quyết toán";
            this.chkIsAddDataMonth13.Size = new System.Drawing.Size(284, 19);
            this.chkIsAddDataMonth13.TabIndex = 36;
            // 
            // chkIsPrintMonth13
            // 
            this.chkIsPrintMonth13.Location = new System.Drawing.Point(7, 89);
            this.chkIsPrintMonth13.Name = "chkIsPrintMonth13";
            this.chkIsPrintMonth13.Properties.Caption = "In tháng chỉnh lý quyết toán";
            this.chkIsPrintMonth13.Size = new System.Drawing.Size(284, 19);
            this.chkIsPrintMonth13.TabIndex = 35;
            this.chkIsPrintMonth13.CheckedChanged += new System.EventHandler(this.checkEdit3_CheckedChanged);
            // 
            // chkIsPrintAccountDecided
            // 
            this.chkIsPrintAccountDecided.Location = new System.Drawing.Point(7, 68);
            this.chkIsPrintAccountDecided.Name = "chkIsPrintAccountDecided";
            this.chkIsPrintAccountDecided.Properties.Caption = "Hiển thị tài khoản theo QĐ 19/2006/QĐ-BTC";
            this.chkIsPrintAccountDecided.Size = new System.Drawing.Size(284, 19);
            this.chkIsPrintAccountDecided.TabIndex = 34;
            // 
            // chkIsSummarySource
            // 
            this.chkIsSummarySource.Location = new System.Drawing.Point(7, 48);
            this.chkIsSummarySource.Name = "chkIsSummarySource";
            this.chkIsSummarySource.Properties.Caption = "In tài khoản chi tiết theo nguồn";
            this.chkIsSummarySource.Size = new System.Drawing.Size(284, 19);
            this.chkIsSummarySource.TabIndex = 33;
            // 
            // FrmB01H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(584, 205);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmB01H";
            this.Text = "Báo cáo bảng cân đối tài khoản";
            this.Load += new System.EventHandler(this.FrmB01H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSourceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAddDataMonth13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPrintMonth13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsPrintAccountDecided.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSummarySource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboBudgetSourceId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckEdit chkIsAddDataMonth13;
        private DevExpress.XtraEditors.CheckEdit chkIsPrintMonth13;
        private DevExpress.XtraEditors.CheckEdit chkIsPrintAccountDecided;
        private DevExpress.XtraEditors.CheckEdit chkIsSummarySource;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetChapter;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboBudgetKindItem;
        private DevExpress.XtraEditors.LookUpEdit cboAccountGrade;
    }
}