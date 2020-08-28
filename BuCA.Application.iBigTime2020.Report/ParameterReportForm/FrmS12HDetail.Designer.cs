namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS12HDetail
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboBankId = new DevExpress.XtraEditors.LookUpEdit();
            this.cboAccountNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.cboBudgetSubKindItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetChapter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSubKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Location = new System.Drawing.Point(12, 7);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(625, 157);
            this.groupboxMain.Text = "Tham số báo cáo";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(481, 173);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(562, 173);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 173);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(10, 25);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(299, 70);
            this.dateTimeRangeV1.TabIndex = 10;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.cboBankId);
            this.groupControl1.Controls.Add(this.cboAccountNumber);
            this.groupControl1.Controls.Add(this.cboBudgetSubKindItem);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboBudgetChapter);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Location = new System.Drawing.Point(315, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(300, 120);
            this.groupControl1.TabIndex = 11;
            // 
            // cboBankId
            // 
            this.cboBankId.Location = new System.Drawing.Point(108, 90);
            this.cboBankId.Name = "cboBankId";
            this.cboBankId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBankId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBankId.Properties.NullText = "";
            this.cboBankId.Properties.PopupWidth = 380;
            this.cboBankId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBankId.Size = new System.Drawing.Size(181, 20);
            this.cboBankId.TabIndex = 29;
            // 
            // cboAccountNumber
            // 
            this.cboAccountNumber.Location = new System.Drawing.Point(108, 64);
            this.cboAccountNumber.Name = "cboAccountNumber";
            this.cboAccountNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboAccountNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboAccountNumber.Properties.NullText = "";
            this.cboAccountNumber.Properties.PopupWidth = 400;
            this.cboAccountNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboAccountNumber.Size = new System.Drawing.Size(181, 20);
            this.cboAccountNumber.TabIndex = 28;
            // 
            // cboBudgetSubKindItem
            // 
            this.cboBudgetSubKindItem.Location = new System.Drawing.Point(108, 38);
            this.cboBudgetSubKindItem.Name = "cboBudgetSubKindItem";
            this.cboBudgetSubKindItem.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetSubKindItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetSubKindItem.Properties.NullText = "";
            this.cboBudgetSubKindItem.Properties.PopupWidth = 380;
            this.cboBudgetSubKindItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetSubKindItem.Size = new System.Drawing.Size(181, 20);
            this.cboBudgetSubKindItem.TabIndex = 27;
            // 
            // labelControl4
            // 
            this.labelControl4.AllowHtmlString = true;
            this.labelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.Location = new System.Drawing.Point(18, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Tài khoản NH, KB";
            // 
            // labelControl2
            // 
            this.labelControl2.AllowHtmlString = true;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Location = new System.Drawing.Point(18, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Khoản";
            // 
            // cboBudgetChapter
            // 
            this.cboBudgetChapter.Location = new System.Drawing.Point(108, 12);
            this.cboBudgetChapter.Name = "cboBudgetChapter";
            this.cboBudgetChapter.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetChapter.Properties.NullText = "";
            this.cboBudgetChapter.Properties.PopupWidth = 380;
            this.cboBudgetChapter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetChapter.Size = new System.Drawing.Size(181, 20);
            this.cboBudgetChapter.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(18, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Chương";
            // 
            // labelControl7
            // 
            this.labelControl7.AllowHtmlString = true;
            this.labelControl7.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.Location = new System.Drawing.Point(18, 68);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 13);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "Tài khoản";
            // 
            // FrmS12HDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(645, 207);
            this.Name = "FrmS12HDetail";
            this.Load += new System.EventHandler(this.FrmS12H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboBankId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSubKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cboBankId;
        private DevExpress.XtraEditors.LookUpEdit cboAccountNumber;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetSubKindItem;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetChapter;
    }
}