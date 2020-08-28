namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmCash05
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.cboProject = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboBank = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupVoucher = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkDisplayValue = new DevExpress.XtraEditors.CheckEdit();
            this.calBeginningBalance = new DevExpress.XtraEditors.CalcEdit();
            this.calIncurredIncrease = new DevExpress.XtraEditors.CalcEdit();
            this.calIncurredReduction = new DevExpress.XtraEditors.CalcEdit();
            this.calClosingBalance = new DevExpress.XtraEditors.CalcEdit();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cboSelectDesignReport = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkDisplayValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calBeginningBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calIncurredIncrease.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calIncurredReduction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calClosingBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectDesignReport.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl4);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Controls.Add(this.groupVoucher);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Size = new System.Drawing.Size(617, 318);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(468, 333);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(549, 333);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 333);
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
            this.groupControl1.Location = new System.Drawing.Point(7, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(306, 239);
            this.groupControl1.TabIndex = 51;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "Chọn kỳ báo cáo";
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 19);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(296, 73);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(125, 50);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.PopupFormMinSize = new System.Drawing.Size(400, 100);
            this.cboProject.Properties.PopupWidth = 400;
            this.cboProject.Size = new System.Drawing.Size(155, 20);
            this.cboProject.TabIndex = 86;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 53);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(63, 13);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "CTMT, Dự án";
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(125, 24);
            this.cboBank.Name = "cboBank";
            this.cboBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBank.Properties.NullText = "";
            this.cboBank.Properties.PopupFormMinSize = new System.Drawing.Size(400, 100);
            this.cboBank.Size = new System.Drawing.Size(155, 20);
            this.cboBank.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 29);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(79, 13);
            this.labelControl5.TabIndex = 65;
            this.labelControl5.Text = "Tài khoản NH,KB";
            // 
            // groupVoucher
            // 
            this.groupVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupVoucher.Controls.Add(this.cboBank);
            this.groupVoucher.Controls.Add(this.labelControl5);
            this.groupVoucher.Controls.Add(this.cboProject);
            this.groupVoucher.Controls.Add(this.labelControl6);
            this.groupVoucher.Location = new System.Drawing.Point(319, 5);
            this.groupVoucher.Name = "groupVoucher";
            this.groupVoucher.Size = new System.Drawing.Size(290, 97);
            this.groupVoucher.TabIndex = 52;
            this.groupVoucher.Text = "Số hiệu tại kho bạc";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.checkDisplayValue);
            this.groupControl2.Controls.Add(this.calBeginningBalance);
            this.groupControl2.Controls.Add(this.calIncurredIncrease);
            this.groupControl2.Controls.Add(this.calIncurredReduction);
            this.groupControl2.Controls.Add(this.calClosingBalance);
            this.groupControl2.Location = new System.Drawing.Point(319, 108);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(290, 136);
            this.groupControl2.TabIndex = 53;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 115);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(64, 13);
            this.labelControl7.TabIndex = 66;
            this.labelControl7.Text = "Số dư cuối kỳ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 13);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "Phát sinh giảm trong kỳ";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(112, 13);
            this.labelControl3.TabIndex = 67;
            this.labelControl3.Text = "Phát sinh tăng trong kỳ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 68;
            this.labelControl4.Text = "Số dư đầu kỳ";
            // 
            // checkDisplayValue
            // 
            this.checkDisplayValue.EditValue = null;
            this.checkDisplayValue.Location = new System.Drawing.Point(5, 5);
            this.checkDisplayValue.Name = "checkDisplayValue";
            this.checkDisplayValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkDisplayValue.Properties.Caption = "Hiển thị số liệu KBNN ghi";
            this.checkDisplayValue.Size = new System.Drawing.Size(168, 19);
            this.checkDisplayValue.TabIndex = 54;
            this.checkDisplayValue.EditValueChanged += new System.EventHandler(this.checkDisplayValue_EditValueChanged);
            // 
            // calBeginningBalance
            // 
            this.calBeginningBalance.Location = new System.Drawing.Point(125, 30);
            this.calBeginningBalance.Name = "calBeginningBalance";
            this.calBeginningBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calBeginningBalance.Properties.Mask.EditMask = "n";
            this.calBeginningBalance.Size = new System.Drawing.Size(155, 20);
            this.calBeginningBalance.TabIndex = 54;
            // 
            // calIncurredIncrease
            // 
            this.calIncurredIncrease.Location = new System.Drawing.Point(125, 56);
            this.calIncurredIncrease.Name = "calIncurredIncrease";
            this.calIncurredIncrease.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calIncurredIncrease.Properties.Mask.EditMask = "n";
            this.calIncurredIncrease.Size = new System.Drawing.Size(155, 20);
            this.calIncurredIncrease.TabIndex = 55;
            // 
            // calIncurredReduction
            // 
            this.calIncurredReduction.Location = new System.Drawing.Point(125, 82);
            this.calIncurredReduction.Name = "calIncurredReduction";
            this.calIncurredReduction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calIncurredReduction.Properties.Mask.EditMask = "n";
            this.calIncurredReduction.Size = new System.Drawing.Size(155, 20);
            this.calIncurredReduction.TabIndex = 56;
            // 
            // calClosingBalance
            // 
            this.calClosingBalance.Location = new System.Drawing.Point(125, 108);
            this.calClosingBalance.Name = "calClosingBalance";
            this.calClosingBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calClosingBalance.Properties.Mask.EditMask = "n";
            this.calClosingBalance.Size = new System.Drawing.Size(155, 20);
            this.calClosingBalance.TabIndex = 55;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.cboSelectDesignReport);
            this.groupControl4.Location = new System.Drawing.Point(5, 253);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(604, 60);
            this.groupControl4.TabIndex = 54;
            this.groupControl4.Text = "Mẫu báo cáo";
            // 
            // cboSelectDesignReport
            // 
            this.cboSelectDesignReport.EditValue = "";
            this.cboSelectDesignReport.Location = new System.Drawing.Point(12, 24);
            this.cboSelectDesignReport.Name = "cboSelectDesignReport";
            this.cboSelectDesignReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSelectDesignReport.Properties.Items.AddRange(new object[] {
            "Mẫu báo cáo theo QĐ 4377",
            "Mẫu theo TT 61/2014/TT-BTC"});
            this.cboSelectDesignReport.Properties.PopupFormMinSize = new System.Drawing.Size(650, 0);
            this.cboSelectDesignReport.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboSelectDesignReport.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.cboSelectDesignReport.Properties.PopupSizeable = true;
            this.cboSelectDesignReport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSelectDesignReport.Size = new System.Drawing.Size(575, 20);
            this.cboSelectDesignReport.TabIndex = 2;
            // 
            // FrmCash05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 367);
            this.Name = "FrmCash05";
            this.Text = "Bảng xác nhận số dư tài khoản tiền gửi tại KBNN";
            this.Load += new System.EventHandler(this.FrmCash05_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            this.groupVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkDisplayValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calBeginningBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calIncurredIncrease.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calIncurredReduction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calClosingBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectDesignReport.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LookUpEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit cboBank;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        protected DevExpress.XtraEditors.GroupControl groupVoucher;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit checkDisplayValue;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.CalcEdit calBeginningBalance;
        private DevExpress.XtraEditors.CalcEdit calIncurredIncrease;
        private DevExpress.XtraEditors.CalcEdit calIncurredReduction;
        private DevExpress.XtraEditors.CalcEdit calClosingBalance;
        private DevExpress.XtraEditors.ComboBoxEdit cboSelectDesignReport;
    }
}