namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Report
{
    partial class FrmVoucherReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoucherReports));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkPrintVoucherDate = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.chkPrintSystemDate = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.grdReportDetail = new DevExpress.XtraGrid.GridControl();
            this.grdReportDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintVoucherDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintSystemDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportDetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.chkPrintVoucherDate);
            this.groupControl1.Controls.Add(this.checkEdit2);
            this.groupControl1.Controls.Add(this.chkPrintSystemDate);
            this.groupControl1.Controls.Add(this.chkIsActive);
            this.groupControl1.Location = new System.Drawing.Point(12, 341);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(464, 89);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Tùy chọn in";
            // 
            // chkPrintVoucherDate
            // 
            this.chkPrintVoucherDate.EditValue = true;
            this.chkPrintVoucherDate.Location = new System.Drawing.Point(136, 57);
            this.chkPrintVoucherDate.Name = "chkPrintVoucherDate";
            this.chkPrintVoucherDate.Properties.Caption = "In ngày chứng từ";
            this.chkPrintVoucherDate.Size = new System.Drawing.Size(118, 19);
            this.chkPrintVoucherDate.TabIndex = 9;
            this.chkPrintVoucherDate.CheckedChanged += new System.EventHandler(this.chkPrintVoucherDate_CheckedChanged);
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(136, 30);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "In theo lô";
            this.checkEdit2.Size = new System.Drawing.Size(100, 19);
            this.checkEdit2.TabIndex = 8;
            // 
            // chkPrintSystemDate
            // 
            this.chkPrintSystemDate.Location = new System.Drawing.Point(10, 57);
            this.chkPrintSystemDate.Name = "chkPrintSystemDate";
            this.chkPrintSystemDate.Properties.Caption = "In ngày hệ thống";
            this.chkPrintSystemDate.Size = new System.Drawing.Size(118, 19);
            this.chkPrintSystemDate.TabIndex = 7;
            this.chkPrintSystemDate.CheckedChanged += new System.EventHandler(this.chkPrintSystemDate_CheckedChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(10, 30);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Xem trước khi in";
            this.chkIsActive.Size = new System.Drawing.Size(100, 19);
            this.chkIsActive.TabIndex = 6;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "export_excel.png");
            this.imageCollection.Images.SetKeyName(1, "design_report.png");
            this.imageCollection.Images.SetKeyName(2, "preview.png");
            this.imageCollection.Images.SetKeyName(3, "help.png");
            this.imageCollection.Images.SetKeyName(4, "Abort.png");
            this.imageCollection.Images.SetKeyName(5, "Print-16.png");
            this.imageCollection.Images.SetKeyName(6, "print16.png");
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ImageIndex = 4;
            this.btnExit.ImageList = this.imageCollection;
            this.btnExit.Location = new System.Drawing.Point(393, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "&Hủy xem";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.ImageIndex = 2;
            this.btnPreview.ImageList = this.imageCollection;
            this.btnPreview.Location = new System.Drawing.Point(219, 436);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(81, 25);
            this.btnPreview.TabIndex = 16;
            this.btnPreview.Text = "&Thực hiện";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEdit.ImageIndex = 1;
            this.btnEdit.ImageList = this.imageCollection;
            this.btnEdit.Location = new System.Drawing.Point(306, 436);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 25);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "&Sửa mẫu";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHelp.ImageIndex = 3;
            this.btnHelp.ImageList = this.imageCollection;
            this.btnHelp.Location = new System.Drawing.Point(12, 436);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(81, 25);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "&Trợ giúp";
            // 
            // grdReportDetail
            // 
            this.grdReportDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReportDetail.Location = new System.Drawing.Point(12, 8);
            this.grdReportDetail.MainView = this.grdReportDetailView;
            this.grdReportDetail.Name = "grdReportDetail";
            this.grdReportDetail.Size = new System.Drawing.Size(464, 327);
            this.grdReportDetail.TabIndex = 20;
            this.grdReportDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdReportDetailView});
            this.grdReportDetail.DoubleClick += new System.EventHandler(this.grdReportDetail_DoubleClick);
            // 
            // grdReportDetailView
            // 
            this.grdReportDetailView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdReportDetailView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdReportDetailView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdReportDetailView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.grdReportDetailView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdReportDetailView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdReportDetailView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdReportDetailView.FixedLineWidth = 1;
            this.grdReportDetailView.GridControl = this.grdReportDetail;
            this.grdReportDetailView.Name = "grdReportDetailView";
            this.grdReportDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdReportDetailView.OptionsBehavior.Editable = false;
            this.grdReportDetailView.OptionsBehavior.FocusLeaveOnTab = true;
            this.grdReportDetailView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdReportDetailView.OptionsView.ColumnAutoWidth = false;
            this.grdReportDetailView.OptionsView.ShowGroupPanel = false;
            this.grdReportDetailView.OptionsView.ShowIndicator = false;
            this.grdReportDetailView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdReportDetailView_FocusedRowChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(99, 436);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 21;
            this.btnExport.Text = "Xuất XML";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmVoucherReports
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(488, 466);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdReportDetail);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVoucherReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In chứng từ";
            this.Load += new System.EventHandler(this.FrmVoucherReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintVoucherDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintSystemDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportDetailView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkPrintVoucherDate;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit chkPrintSystemDate;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.Utils.ImageCollection imageCollection;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnPreview;
        public DevExpress.XtraEditors.SimpleButton btnEdit;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        protected DevExpress.XtraGrid.GridControl grdReportDetail;
        protected DevExpress.XtraGrid.Views.Grid.GridView grdReportDetailView;
        public DevExpress.XtraEditors.SimpleButton btnExport;
    }
}