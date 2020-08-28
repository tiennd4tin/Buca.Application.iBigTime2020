namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmF0101BCQT
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.rndOption = new DevExpress.XtraEditors.RadioGroup();
            this.cboBudgetSubKindItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetChapter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetSource = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSubKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Size = new System.Drawing.Size(313, 242);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(167, 259);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(248, 259);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 259);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(9, 7);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(301, 72);
            this.dateTimeRangeV1.TabIndex = 14;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rndOption);
            this.groupControl2.Controls.Add(this.cboBudgetSubKindItem);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.cboBudgetChapter);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cboBudgetSource);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(9, 85);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(301, 155);
            this.groupControl2.TabIndex = 15;
            this.groupControl2.Text = "Điều kiện";
            // 
            // rndOption
            // 
            this.rndOption.EditValue = "06";
            this.rndOption.Location = new System.Drawing.Point(9, 105);
            this.rndOption.Name = "rndOption";
            this.rndOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rndOption.Properties.Appearance.Options.UseBackColor = true;
            this.rndOption.Properties.Columns = 3;
            this.rndOption.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rndOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("03", "Tất cả"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("06", "Tổng hợp"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("09", "Tùy chọn")});
            this.rndOption.Size = new System.Drawing.Size(284, 42);
            this.rndOption.TabIndex = 91;
            this.rndOption.SelectedIndexChanged += new System.EventHandler(this.rndOption_SelectedIndexChanged);
            // 
            // cboBudgetSubKindItem
            // 
            this.cboBudgetSubKindItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetSubKindItem.Location = new System.Drawing.Point(53, 79);
            this.cboBudgetSubKindItem.Name = "cboBudgetSubKindItem";
            this.cboBudgetSubKindItem.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetSubKindItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetSubKindItem.Properties.NullText = "";
            this.cboBudgetSubKindItem.Properties.PopupWidth = 380;
            this.cboBudgetSubKindItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetSubKindItem.Size = new System.Drawing.Size(240, 20);
            this.cboBudgetSubKindItem.TabIndex = 38;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 39;
            this.labelControl3.Text = "Khoản";
            // 
            // cboBudgetChapter
            // 
            this.cboBudgetChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetChapter.Location = new System.Drawing.Point(53, 53);
            this.cboBudgetChapter.Name = "cboBudgetChapter";
            this.cboBudgetChapter.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetChapter.Properties.NullText = "";
            this.cboBudgetChapter.Properties.PopupWidth = 380;
            this.cboBudgetChapter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetChapter.Size = new System.Drawing.Size(240, 20);
            this.cboBudgetChapter.TabIndex = 36;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "Chương";
            // 
            // cboBudgetSource
            // 
            this.cboBudgetSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetSource.Location = new System.Drawing.Point(53, 27);
            this.cboBudgetSource.Name = "cboBudgetSource";
            this.cboBudgetSource.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetSource.Properties.NullText = "";
            this.cboBudgetSource.Properties.PopupWidth = 380;
            this.cboBudgetSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetSource.Size = new System.Drawing.Size(240, 20);
            this.cboBudgetSource.TabIndex = 24;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Nguồn";
            // 
            // FrmF0101BCQT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 293);
            this.Name = "FrmF0101BCQT";
            this.Load += new System.EventHandler(this.FrmF0101BCQT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSubKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetSubKindItem;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetChapter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetSource;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup rndOption;
    }
}