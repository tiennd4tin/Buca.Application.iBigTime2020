namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmFixedAssetS24H
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
            this.bindingSourceFixedAssets = new System.Windows.Forms.BindingSource();
            this.gridFixedAssetControl = new DevExpress.XtraGrid.GridControl();
            this.gridFixedAssetControlView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cboShowQuantity = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboFixedAssetCategoryGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.cboDepartments = new DevExpress.XtraEditors.LookUpEdit();
            this.cboInventoryCategories = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupPrintByCondition = new DevExpress.XtraEditors.GroupControl();
            this.checkFixedAssetNoIncrease = new DevExpress.XtraEditors.CheckEdit();
            this.checkFixedAssetOpenning = new DevExpress.XtraEditors.CheckEdit();
            this.checkFixedAssetIncrease = new DevExpress.XtraEditors.CheckEdit();
            this.checkPrintByCondition = new DevExpress.XtraEditors.CheckEdit();
            this.bindingSourceDepartments = new System.Windows.Forms.BindingSource();
            this.bindingSourceFixedAssetCategories = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControlView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboShowQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFixedAssetCategoryGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryCategories.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupPrintByCondition)).BeginInit();
            this.groupPrintByCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkFixedAssetNoIncrease.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFixedAssetOpenning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFixedAssetIncrease.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPrintByCondition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssetCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.groupboxMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupboxMain.Location = new System.Drawing.Point(622, 471);
            this.groupboxMain.Size = new System.Drawing.Size(10, 10);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(454, 392);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(535, 392);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 392);
            // 
            // gridFixedAssetControl
            // 
            this.gridFixedAssetControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFixedAssetControl.DataSource = this.bindingSourceFixedAssets;
            this.gridFixedAssetControl.Location = new System.Drawing.Point(8, 115);
            this.gridFixedAssetControl.MainView = this.gridFixedAssetControlView;
            this.gridFixedAssetControl.Name = "gridFixedAssetControl";
            this.gridFixedAssetControl.Size = new System.Drawing.Size(602, 268);
            this.gridFixedAssetControl.TabIndex = 53;
            this.gridFixedAssetControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridFixedAssetControlView});
            // 
            // gridFixedAssetControlView
            // 
            this.gridFixedAssetControlView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridFixedAssetControlView.GridControl = this.gridFixedAssetControl;
            this.gridFixedAssetControlView.Name = "gridFixedAssetControlView";
            this.gridFixedAssetControlView.OptionsDetail.EnableMasterViewMode = false;
            this.gridFixedAssetControlView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridFixedAssetControlView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridFixedAssetControlView.OptionsView.ColumnAutoWidth = false;
            this.gridFixedAssetControlView.OptionsView.ShowAutoFilterRow = true;
            this.gridFixedAssetControlView.OptionsView.ShowGroupPanel = false;
            this.gridFixedAssetControlView.OptionsView.ShowIndicator = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(300, 97);
            this.groupControl1.TabIndex = 53;
            this.groupControl1.Text = "Chọn kỳ báo cáo";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(2, 22);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(297, 70);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.cboShowQuantity);
            this.groupControl4.Controls.Add(this.labelControl4);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Controls.Add(this.cboFixedAssetCategoryGrade);
            this.groupControl4.Location = new System.Drawing.Point(200, 510);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(24, 24);
            this.groupControl4.TabIndex = 54;
            this.groupControl4.Text = "Tùy chọn mẫu hiển thị";
            this.groupControl4.Visible = false;
            // 
            // cboShowQuantity
            // 
            this.cboShowQuantity.Location = new System.Drawing.Point(158, 64);
            this.cboShowQuantity.Name = "cboShowQuantity";
            this.cboShowQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboShowQuantity.Properties.Items.AddRange(new object[] {
            "Hiển thị số lượng trên Sổ",
            "Không hiển thị số lượng trên Sổ"});
            this.cboShowQuantity.Size = new System.Drawing.Size(222, 20);
            this.cboShowQuantity.TabIndex = 69;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 67;
            this.labelControl4.Text = "Thể hiện số lượng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(124, 13);
            this.labelControl3.TabIndex = 66;
            this.labelControl3.Text = "Thể hiện loại tài sản ở cấp";
            // 
            // cboFixedAssetCategoryGrade
            // 
            this.cboFixedAssetCategoryGrade.Location = new System.Drawing.Point(158, 35);
            this.cboFixedAssetCategoryGrade.Name = "cboFixedAssetCategoryGrade";
            this.cboFixedAssetCategoryGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFixedAssetCategoryGrade.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "Chi tiết nhất"});
            this.cboFixedAssetCategoryGrade.Size = new System.Drawing.Size(92, 20);
            this.cboFixedAssetCategoryGrade.TabIndex = 68;
            // 
            // groupControl5
            // 
            this.groupControl5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupControl5.Controls.Add(this.cboDepartments);
            this.groupControl5.Controls.Add(this.cboInventoryCategories);
            this.groupControl5.Controls.Add(this.labelControl1);
            this.groupControl5.Controls.Add(this.labelControl6);
            this.groupControl5.Location = new System.Drawing.Point(317, 8);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(293, 97);
            this.groupControl5.TabIndex = 55;
            this.groupControl5.Text = "Tùy chọn lọc tài sản";
            // 
            // cboDepartments
            // 
            this.cboDepartments.Location = new System.Drawing.Point(67, 34);
            this.cboDepartments.Name = "cboDepartments";
            this.cboDepartments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartments.Properties.NullText = "";
            this.cboDepartments.Size = new System.Drawing.Size(218, 20);
            this.cboDepartments.TabIndex = 96;
            // 
            // cboInventoryCategories
            // 
            this.cboInventoryCategories.Location = new System.Drawing.Point(67, 60);
            this.cboInventoryCategories.Name = "cboInventoryCategories";
            this.cboInventoryCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboInventoryCategories.Properties.NullText = "";
            this.cboInventoryCategories.Size = new System.Drawing.Size(218, 20);
            this.cboInventoryCategories.TabIndex = 94;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 95;
            this.labelControl1.Text = "Loại TSCĐ";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 38);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 13);
            this.labelControl6.TabIndex = 93;
            this.labelControl6.Text = "Phòng ban";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.groupPrintByCondition);
            this.groupControl2.Location = new System.Drawing.Point(573, 115);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(0, 0);
            this.groupControl2.TabIndex = 56;
            this.groupControl2.Visible = false;
            // 
            // groupPrintByCondition
            // 
            this.groupPrintByCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPrintByCondition.Appearance.BackColor = System.Drawing.Color.White;
            this.groupPrintByCondition.Appearance.Options.UseBackColor = true;
            this.groupPrintByCondition.Controls.Add(this.checkFixedAssetNoIncrease);
            this.groupPrintByCondition.Controls.Add(this.checkFixedAssetOpenning);
            this.groupPrintByCondition.Controls.Add(this.checkFixedAssetIncrease);
            this.groupPrintByCondition.Location = new System.Drawing.Point(35, 28);
            this.groupPrintByCondition.Name = "groupPrintByCondition";
            this.groupPrintByCondition.ShowCaption = false;
            this.groupPrintByCondition.Size = new System.Drawing.Size(2, 0);
            this.groupPrintByCondition.TabIndex = 57;
            // 
            // checkFixedAssetNoIncrease
            // 
            this.checkFixedAssetNoIncrease.EditValue = null;
            this.checkFixedAssetNoIncrease.Location = new System.Drawing.Point(20, 59);
            this.checkFixedAssetNoIncrease.Name = "checkFixedAssetNoIncrease";
            this.checkFixedAssetNoIncrease.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkFixedAssetNoIncrease.Properties.Caption = "TSCĐ chưa ghi tăng";
            this.checkFixedAssetNoIncrease.Size = new System.Drawing.Size(318, 19);
            this.checkFixedAssetNoIncrease.TabIndex = 10;
            // 
            // checkFixedAssetOpenning
            // 
            this.checkFixedAssetOpenning.EditValue = null;
            this.checkFixedAssetOpenning.Location = new System.Drawing.Point(20, 7);
            this.checkFixedAssetOpenning.Name = "checkFixedAssetOpenning";
            this.checkFixedAssetOpenning.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkFixedAssetOpenning.Properties.Caption = "TSCĐ đầu năm";
            this.checkFixedAssetOpenning.Size = new System.Drawing.Size(318, 19);
            this.checkFixedAssetOpenning.TabIndex = 8;
            // 
            // checkFixedAssetIncrease
            // 
            this.checkFixedAssetIncrease.EditValue = null;
            this.checkFixedAssetIncrease.Location = new System.Drawing.Point(20, 34);
            this.checkFixedAssetIncrease.Name = "checkFixedAssetIncrease";
            this.checkFixedAssetIncrease.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkFixedAssetIncrease.Properties.Caption = "TSCĐ tăng trong năm";
            this.checkFixedAssetIncrease.Size = new System.Drawing.Size(318, 19);
            this.checkFixedAssetIncrease.TabIndex = 9;
            // 
            // checkPrintByCondition
            // 
            this.checkPrintByCondition.EditValue = null;
            this.checkPrintByCondition.Location = new System.Drawing.Point(230, 512);
            this.checkPrintByCondition.Name = "checkPrintByCondition";
            this.checkPrintByCondition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkPrintByCondition.Properties.Caption = "In danh sách theo điều kiện";
            this.checkPrintByCondition.Size = new System.Drawing.Size(22, 19);
            this.checkPrintByCondition.TabIndex = 7;
            this.checkPrintByCondition.EditValueChanged += new System.EventHandler(this.checkPrintByCondition_EditValueChanged);
            // 
            // FrmFixedAssetS24H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 426);
            this.Controls.Add(this.gridFixedAssetControl);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.checkPrintByCondition);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmFixedAssetS24H";
            this.Text = "S24-H: Sổ tài sản cố định";
            this.Load += new System.EventHandler(this.FrmFixedAssetS24H_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl4, 0);
            this.Controls.SetChildIndex(this.groupControl5, 0);
            this.Controls.SetChildIndex(this.checkPrintByCondition, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.gridFixedAssetControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControlView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboShowQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFixedAssetCategoryGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryCategories.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupPrintByCondition)).EndInit();
            this.groupPrintByCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkFixedAssetNoIncrease.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFixedAssetOpenning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFixedAssetIncrease.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPrintByCondition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssetCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSourceFixedAssets;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LookUpEdit cboInventoryCategories;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit checkPrintByCondition;
        private DevExpress.XtraEditors.CheckEdit checkFixedAssetNoIncrease;
        private DevExpress.XtraEditors.CheckEdit checkFixedAssetIncrease;
        private DevExpress.XtraEditors.CheckEdit checkFixedAssetOpenning;
        private DevExpress.XtraGrid.GridControl gridFixedAssetControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridFixedAssetControlView;
        private DevExpress.XtraEditors.ComboBoxEdit cboShowQuantity;
        private DevExpress.XtraEditors.ComboBoxEdit cboFixedAssetCategoryGrade;
        public DevExpress.XtraEditors.GroupControl groupPrintByCondition;
        private System.Windows.Forms.BindingSource bindingSourceDepartments;
        private System.Windows.Forms.BindingSource bindingSourceFixedAssetCategories;
        private DevExpress.XtraEditors.LookUpEdit cboDepartments;
    }
}