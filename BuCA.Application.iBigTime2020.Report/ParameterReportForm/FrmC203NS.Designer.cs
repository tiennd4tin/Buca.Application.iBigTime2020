namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmC203NS
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
            this.components = new System.ComponentModel.Container();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboBudgetSubKindItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetChapter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetSource = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lookupBudgetSourceKind = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cboMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboBankAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboProject = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.grdBudgetItem = new DevExpress.XtraGrid.GridControl();
            this.gridViewBudgetItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSubKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBudgetSourceKind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudgetItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBudgetItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Location = new System.Drawing.Point(660, 9);
            this.groupboxMain.Size = new System.Drawing.Size(62, 388);
            this.groupboxMain.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(457, 403);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(537, 403);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 403);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboBudgetSubKindItem);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.cboBudgetChapter);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cboBudgetSource);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(12, 10);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(294, 135);
            this.groupControl2.TabIndex = 17;
            this.groupControl2.Text = "Điều kiện";
            // 
            // cboBudgetSubKindItem
            // 
            this.cboBudgetSubKindItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetSubKindItem.Location = new System.Drawing.Point(65, 79);
            this.cboBudgetSubKindItem.Name = "cboBudgetSubKindItem";
            this.cboBudgetSubKindItem.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetSubKindItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetSubKindItem.Properties.NullText = "";
            this.cboBudgetSubKindItem.Properties.PopupWidth = 380;
            this.cboBudgetSubKindItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetSubKindItem.Size = new System.Drawing.Size(221, 20);
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
            this.cboBudgetChapter.Location = new System.Drawing.Point(65, 53);
            this.cboBudgetChapter.Name = "cboBudgetChapter";
            this.cboBudgetChapter.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetChapter.Properties.NullText = "";
            this.cboBudgetChapter.Properties.PopupWidth = 380;
            this.cboBudgetChapter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetChapter.Size = new System.Drawing.Size(221, 20);
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
            this.cboBudgetSource.Location = new System.Drawing.Point(65, 27);
            this.cboBudgetSource.Name = "cboBudgetSource";
            this.cboBudgetSource.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBudgetSource.Properties.NullText = "";
            this.cboBudgetSource.Properties.PopupWidth = 380;
            this.cboBudgetSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBudgetSource.Size = new System.Drawing.Size(221, 20);
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 17);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(313, 70);
            this.dateTimeRangeV1.TabIndex = 13;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(49, 291);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(319, 94);
            this.groupControl1.TabIndex = 92;
            this.groupControl1.Text = "Ngày tháng";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lookupBudgetSourceKind);
            this.groupControl3.Controls.Add(this.cboMethod);
            this.groupControl3.Controls.Add(this.cboBankAccount);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.cboProject);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(312, 10);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(294, 135);
            this.groupControl3.TabIndex = 42;
            this.groupControl3.Text = "Điều kiện";
            // 
            // lookupBudgetSourceKind
            // 
            this.lookupBudgetSourceKind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupBudgetSourceKind.Location = new System.Drawing.Point(76, 53);
            this.lookupBudgetSourceKind.Name = "lookupBudgetSourceKind";
            this.lookupBudgetSourceKind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupBudgetSourceKind.Size = new System.Drawing.Size(213, 20);
            this.lookupBudgetSourceKind.TabIndex = 40;
            // 
            // cboMethod
            // 
            this.cboMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMethod.EditValue = "";
            this.cboMethod.Location = new System.Drawing.Point(76, 27);
            this.cboMethod.Name = "cboMethod";
            this.cboMethod.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboMethod.Properties.Items.AddRange(new object[] {
            "<<Tất cả>>",
            "Dự toán",
            "Lệnh chi",
            "Hiện vật",
            "Ghi thu - ghi chi",
            "Khác"});
            this.cboMethod.Properties.PopupFormSize = new System.Drawing.Size(380, 0);
            this.cboMethod.Properties.PopupSizeable = true;
            this.cboMethod.Size = new System.Drawing.Size(213, 20);
            this.cboMethod.TabIndex = 98;
            // 
            // cboBankAccount
            // 
            this.cboBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBankAccount.Location = new System.Drawing.Point(76, 105);
            this.cboBankAccount.Name = "cboBankAccount";
            this.cboBankAccount.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboBankAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboBankAccount.Properties.NullText = "";
            this.cboBankAccount.Properties.PopupWidth = 380;
            this.cboBankAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBankAccount.Size = new System.Drawing.Size(213, 20);
            this.cboBankAccount.TabIndex = 46;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 108);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 13);
            this.labelControl7.TabIndex = 47;
            this.labelControl7.Text = "Ngân hàng";
            // 
            // cboProject
            // 
            this.cboProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProject.Location = new System.Drawing.Point(76, 79);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.PopupWidth = 380;
            this.cboProject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProject.Size = new System.Drawing.Size(213, 20);
            this.cboProject.TabIndex = 44;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 82);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 13);
            this.labelControl6.TabIndex = 45;
            this.labelControl6.Text = "CTMT, dự án";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 43;
            this.labelControl4.Text = "Kinh phí";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 30);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 13);
            this.labelControl5.TabIndex = 41;
            this.labelControl5.Text = "Cấp phát";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.grdBudgetItem);
            this.groupControl4.Location = new System.Drawing.Point(12, 151);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(594, 192);
            this.groupControl4.TabIndex = 94;
            this.groupControl4.Text = "Chọn Mục lục ngân sách";
            // 
            // grdBudgetItem
            // 
            this.grdBudgetItem.DataSource = this.bindingSource;
            this.grdBudgetItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBudgetItem.Location = new System.Drawing.Point(2, 21);
            this.grdBudgetItem.MainView = this.gridViewBudgetItem;
            this.grdBudgetItem.Name = "grdBudgetItem";
            this.grdBudgetItem.Size = new System.Drawing.Size(590, 169);
            this.grdBudgetItem.TabIndex = 0;
            this.grdBudgetItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBudgetItem});
            // 
            // gridViewBudgetItem
            // 
            this.gridViewBudgetItem.GridControl = this.grdBudgetItem;
            this.gridViewBudgetItem.Name = "gridViewBudgetItem";
            this.gridViewBudgetItem.OptionsSelection.InvertSelection = true;
            this.gridViewBudgetItem.OptionsSelection.MultiSelect = true;
            this.gridViewBudgetItem.OptionsView.ColumnAutoWidth = false;
            this.gridViewBudgetItem.OptionsView.ShowAutoFilterRow = true;
            this.gridViewBudgetItem.OptionsView.ShowGroupPanel = false;
            this.gridViewBudgetItem.OptionsView.ShowIndicator = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(88, 403);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 95;
            this.btnExport.Text = "Xuất XML";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(6, 20);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(134, 17);
            this.rb1.TabIndex = 96;
            this.rb1.TabStop = true;
            this.rb1.Text = "Tạm ứng sang thực chi";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(300, 20);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(217, 17);
            this.rb2.TabIndex = 97;
            this.rb2.Text = "Ứng trước chưa đủ điều kiện thanh toán";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Location = new System.Drawing.Point(12, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 45);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại chứng từ";
            // 
            // FrmC203NS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Name = "FrmC203NS";
            this.Text = "Tham số báo cáo - C203NS";
            this.Load += new System.EventHandler(this.FrmC203NS_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl4, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSubKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBudgetSourceKind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBudgetItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBudgetItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetSubKindItem;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetChapter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetSource;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LookUpEdit cboProject;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl grdBudgetItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBudgetItem;
        private DevExpress.XtraEditors.LookUpEdit cboBankAccount;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cboMethod;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lookupBudgetSourceKind;
        public DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}