namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmFixedAssetC56
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
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridFixedAssetControl = new DevExpress.XtraGrid.GridControl();
            this.gridFixedAssetControlView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkChooseFixedAsset = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.bindingSourceDepartments = new System.Windows.Forms.BindingSource();
            this.bindingSourceFixedAssetCategories = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControlView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChooseFixedAsset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            this.btnOk.Location = new System.Drawing.Point(306, 381);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(387, 381);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 381);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.Controls.Add(this.gridFixedAssetControl);
            this.groupControl3.Controls.Add(this.checkChooseFixedAsset);
            this.groupControl3.Location = new System.Drawing.Point(7, 106);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(455, 249);
            this.groupControl3.TabIndex = 50;
            // 
            // gridFixedAssetControl
            // 
            this.gridFixedAssetControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFixedAssetControl.DataSource = this.bindingSourceFixedAssets;
            this.gridFixedAssetControl.Location = new System.Drawing.Point(6, 40);
            this.gridFixedAssetControl.MainView = this.gridFixedAssetControlView;
            this.gridFixedAssetControl.Name = "gridFixedAssetControl";
            this.gridFixedAssetControl.Size = new System.Drawing.Size(442, 204);
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
            // checkChooseFixedAsset
            // 
            this.checkChooseFixedAsset.Location = new System.Drawing.Point(6, 5);
            this.checkChooseFixedAsset.Name = "checkChooseFixedAsset";
            this.checkChooseFixedAsset.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Loại tài sản"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Tên tài sản")});
            this.checkChooseFixedAsset.Size = new System.Drawing.Size(442, 29);
            this.checkChooseFixedAsset.TabIndex = 7;
            this.checkChooseFixedAsset.TabStop = false;
            this.checkChooseFixedAsset.SelectedIndexChanged += new System.EventHandler(this.checkChooseFixedAsset_SelectedIndexChanged);
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
            this.groupControl1.Location = new System.Drawing.Point(7, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(455, 88);
            this.groupControl1.TabIndex = 53;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 9);
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(3, 16);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(331, 71);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // FrmFixedAssetC56
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 415);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl3);
            this.Name = "FrmFixedAssetC56";
            this.Text = "C56: Bảng tính và phân bổ khấu hao TSCĐ";
            this.Load += new System.EventHandler(this.FrmFixedAssetS24H_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetControlView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChooseFixedAsset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFixedAssetCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSourceFixedAssets;
        public DevExpress.XtraEditors.GroupControl groupControl3;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraGrid.GridControl gridFixedAssetControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridFixedAssetControlView;
        private System.Windows.Forms.BindingSource bindingSourceDepartments;
        private System.Windows.Forms.BindingSource bindingSourceFixedAssetCategories;
        private DevExpress.XtraEditors.RadioGroup checkChooseFixedAsset;
    }
}