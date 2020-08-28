namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmMinutesInventoryFixedAsset
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
            this.cboDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEditInventory = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboFixedAssetCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdMinutesInventoryFixedAsset = new DevExpress.XtraGrid.GridControl();
            this.grdMinutesInventoryFixedAssetView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextDetailMenu = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuNewRowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeleteRowItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInventory.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInventory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFixedAssetCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMinutesInventoryFixedAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMinutesInventoryFixedAssetView)).BeginInit();
            this.contextDetailMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(313, 102);
            this.groupboxMain.Text = "Kỳ báo cáo";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(494, 444);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(575, 444);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 444);
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(9, 22);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(299, 72);
            this.dateTimeRangeV1.TabIndex = 14;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Location = new System.Drawing.Point(102, 17);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboDepartment.Properties.NullText = "";
            this.cboDepartment.Properties.PopupWidth = 380;
            this.cboDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDepartment.Size = new System.Drawing.Size(204, 20);
            this.cboDepartment.TabIndex = 27;
            // 
            // labelControl4
            // 
            this.labelControl4.AllowHtmlString = true;
            this.labelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.Location = new System.Drawing.Point(15, 24);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Phòng/Ban";
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(15, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Loại TSCĐ";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dateEditInventory);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboFixedAssetCategory);
            this.groupControl1.Controls.Add(this.cboDepartment);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(329, 9);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(321, 102);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "Tham số";
            // 
            // dateEditInventory
            // 
            this.dateEditInventory.EditValue = new System.DateTime(((long)(0)));
            this.dateEditInventory.Location = new System.Drawing.Point(102, 75);
            this.dateEditInventory.Name = "dateEditInventory";
            this.dateEditInventory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditInventory.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm";
            this.dateEditInventory.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditInventory.Properties.EditFormat.FormatString = "MM/dd/yyyy hh:mm";
            this.dateEditInventory.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditInventory.Properties.Mask.EditMask = "g";
            this.dateEditInventory.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditInventory.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditInventory.Properties.VistaTimeProperties.DisplayFormat.FormatString = "d";
            this.dateEditInventory.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditInventory.Properties.VistaTimeProperties.EditFormat.FormatString = "d";
            this.dateEditInventory.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditInventory.Size = new System.Drawing.Size(204, 20);
            this.dateEditInventory.TabIndex = 30;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "Ngày giờ kiểm kê";
            // 
            // cboFixedAssetCategory
            // 
            this.cboFixedAssetCategory.Location = new System.Drawing.Point(102, 46);
            this.cboFixedAssetCategory.Name = "cboFixedAssetCategory";
            this.cboFixedAssetCategory.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboFixedAssetCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cboFixedAssetCategory.Properties.NullText = "";
            this.cboFixedAssetCategory.Properties.PopupWidth = 380;
            this.cboFixedAssetCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboFixedAssetCategory.Size = new System.Drawing.Size(204, 20);
            this.cboFixedAssetCategory.TabIndex = 28;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.grdMinutesInventoryFixedAsset);
            this.groupControl2.Location = new System.Drawing.Point(7, 117);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(643, 321);
            this.groupControl2.TabIndex = 15;
            this.groupControl2.Text = "Ban kiểm kê";
            // 
            // grdMinutesInventoryFixedAsset
            // 
            this.grdMinutesInventoryFixedAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMinutesInventoryFixedAsset.Location = new System.Drawing.Point(2, 21);
            this.grdMinutesInventoryFixedAsset.MainView = this.grdMinutesInventoryFixedAssetView;
            this.grdMinutesInventoryFixedAsset.Name = "grdMinutesInventoryFixedAsset";
            this.grdMinutesInventoryFixedAsset.Size = new System.Drawing.Size(639, 298);
            this.grdMinutesInventoryFixedAsset.TabIndex = 6;
            this.grdMinutesInventoryFixedAsset.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdMinutesInventoryFixedAssetView});
            // 
            // grdMinutesInventoryFixedAssetView
            // 
            this.grdMinutesInventoryFixedAssetView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdMinutesInventoryFixedAssetView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdMinutesInventoryFixedAssetView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdMinutesInventoryFixedAssetView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.grdMinutesInventoryFixedAssetView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdMinutesInventoryFixedAssetView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdMinutesInventoryFixedAssetView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdMinutesInventoryFixedAssetView.FixedLineWidth = 1;
            this.grdMinutesInventoryFixedAssetView.GridControl = this.grdMinutesInventoryFixedAsset;
            this.grdMinutesInventoryFixedAssetView.Name = "grdMinutesInventoryFixedAssetView";
            this.grdMinutesInventoryFixedAssetView.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.grdMinutesInventoryFixedAssetView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdMinutesInventoryFixedAssetView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdMinutesInventoryFixedAssetView.OptionsBehavior.FocusLeaveOnTab = true;
            this.grdMinutesInventoryFixedAssetView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdMinutesInventoryFixedAssetView.OptionsView.ShowGroupPanel = false;
            this.grdMinutesInventoryFixedAssetView.OptionsView.ShowIndicator = false;
            this.grdMinutesInventoryFixedAssetView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdMinutesInventoryFixedAssetView_PopupMenuShowing);
            this.grdMinutesInventoryFixedAssetView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdMinutesInventoryFixedAssetView_InitNewRow);
            // 
            // contextDetailMenu
            // 
            this.contextDetailMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNewRowItem,
            this.toolStripMenuDeleteRowItem});
            this.contextDetailMenu.Name = "contextDetailMenu";
            this.contextDetailMenu.Size = new System.Drawing.Size(137, 48);
            // 
            // toolStripMenuNewRowItem
            // 
            this.toolStripMenuNewRowItem.Name = "toolStripMenuNewRowItem";
            this.toolStripMenuNewRowItem.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuNewRowItem.Text = "Thêm dòng";
            // 
            // toolStripMenuDeleteRowItem
            // 
            this.toolStripMenuDeleteRowItem.Name = "toolStripMenuDeleteRowItem";
            this.toolStripMenuDeleteRowItem.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuDeleteRowItem.Text = "Xóa dòng";
            // 
            // FrmMinutesInventoryFixedAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 478);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmMinutesInventoryFixedAsset";
            this.Load += new System.EventHandler(this.FrmMinutesInventoryFixedAsset_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInventory.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInventory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFixedAssetCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMinutesInventoryFixedAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMinutesInventoryFixedAssetView)).EndInit();
            this.contextDetailMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LookUpEdit cboDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit cboFixedAssetCategory;
        private DevExpress.XtraGrid.GridControl grdMinutesInventoryFixedAsset;
        private System.Windows.Forms.ContextMenuStrip contextDetailMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewRowItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeleteRowItem;
        public DevExpress.XtraGrid.Views.Grid.GridView grdMinutesInventoryFixedAssetView;
        private DevExpress.XtraEditors.DateEdit dateEditInventory;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}