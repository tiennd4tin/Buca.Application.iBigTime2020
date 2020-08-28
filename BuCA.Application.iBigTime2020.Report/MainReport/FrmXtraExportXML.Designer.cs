using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.ReportClass;

namespace BuCA.Application.iBigTime2020.Report.MainReport
{
    partial class FrmXtraExportXML
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
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters1 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraExportXML));
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters2 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            this.gifExportFilter1 = new PerpetuumSoft.Reporting.Export.Graph.GifExportFilter();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.gifExportFilter2 = new PerpetuumSoft.Reporting.Export.Graph.GifExportFilter();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            this.cboCurrencyCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtReportPeriod = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboAmountType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.XmlPathtxt = new System.Windows.Forms.TextBox();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource();
            this.grdXmlGroup = new DevExpress.XtraGrid.GridControl();
            this.grdXmlGroupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdXmlDetail = new DevExpress.XtraGrid.GridControl();
            this.grdXmlDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SelectPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrencyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAmountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlDetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // gifExportFilter1
            // 
            this.gifExportFilter1.ExtraParameters = extraParameters1;
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
            // gifExportFilter2
            // 
            this.gifExportFilter2.ExtraParameters = extraParameters2;
            // 
            // cboCurrencyCode
            // 
            this.cboCurrencyCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrencyCode.Location = new System.Drawing.Point(490, 35);
            this.cboCurrencyCode.Name = "cboCurrencyCode";
            this.cboCurrencyCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCurrencyCode.Properties.PopupSizeable = true;
            this.cboCurrencyCode.Size = new System.Drawing.Size(128, 20);
            this.cboCurrencyCode.TabIndex = 1;
            // 
            // dtReportPeriod
            // 
            this.dtReportPeriod.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dtReportPeriod.Appearance.Options.UseBackColor = true;
            this.dtReportPeriod.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dtReportPeriod.FromDate = new System.DateTime(((long)(0)));
            this.dtReportPeriod.FromDateLabelText = "Từ ngày";
            this.dtReportPeriod.InitSelectedIndex = 0;
            this.dtReportPeriod.Location = new System.Drawing.Point(6, -5);
            this.dtReportPeriod.MinimumSize = new System.Drawing.Size(290, 70);
            this.dtReportPeriod.Name = "dtReportPeriod";
            this.dtReportPeriod.PeriodLabelText = "Kỳ báo cáo";
            this.dtReportPeriod.Size = new System.Drawing.Size(295, 78);
            this.dtReportPeriod.TabIndex = 0;
            this.dtReportPeriod.ToDate = new System.DateTime(((long)(0)));
            this.dtReportPeriod.ToDateLabelText = "Đến ngày";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(417, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Loại tiền";
            // 
            // cboAmountType
            // 
            this.cboAmountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAmountType.EditValue = "Tiền nguyên tệ";
            this.cboAmountType.Location = new System.Drawing.Point(490, 12);
            this.cboAmountType.Name = "cboAmountType";
            this.cboAmountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAmountType.Properties.Items.AddRange(new object[] {
            "Tiền quy đổi",
            "Tiền nguyên tệ"});
            this.cboAmountType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAmountType.Size = new System.Drawing.Size(128, 20);
            this.cboAmountType.TabIndex = 0;
            this.cboAmountType.SelectedIndexChanged += new System.EventHandler(this.cboAmountType_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(417, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Loại hạch toán";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.cboCurrencyCode);
            this.groupControl2.Controls.Add(this.dtReportPeriod);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cboAmountType);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(6, 564);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(626, 69);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Tùy chọn";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ImageIndex = 4;
            this.btnExit.ImageList = this.imageCollection;
            this.btnExit.Location = new System.Drawing.Point(543, 651);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 25);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "&Hủy";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.ImageIndex = 5;
            this.btnExportToExcel.ImageList = this.imageCollection;
            this.btnExportToExcel.Location = new System.Drawing.Point(454, 651);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(81, 25);
            this.btnExportToExcel.TabIndex = 16;
            this.btnExportToExcel.Text = "Xuất File";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(12, 656);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Đường dẫn";
            // 
            // XmlPathtxt
            // 
            this.XmlPathtxt.Location = new System.Drawing.Point(83, 653);
            this.XmlPathtxt.Name = "XmlPathtxt";
            this.XmlPathtxt.Size = new System.Drawing.Size(318, 21);
            this.XmlPathtxt.TabIndex = 18;
            // 
            // grdXmlGroup
            // 
            this.grdXmlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdXmlGroup.DataSource = this.bindingSource;
            this.grdXmlGroup.Location = new System.Drawing.Point(6, 18);
            this.grdXmlGroup.MainView = this.grdXmlGroupView;
            this.grdXmlGroup.Name = "grdXmlGroup";
            this.grdXmlGroup.Size = new System.Drawing.Size(626, 268);
            this.grdXmlGroup.TabIndex = 54;
            this.grdXmlGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdXmlGroupView});
            this.grdXmlGroup.Click += new System.EventHandler(this.grdXmlGroup_Click);
            // 
            // grdXmlGroupView
            // 
            this.grdXmlGroupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdXmlGroupView.GridControl = this.grdXmlGroup;
            this.grdXmlGroupView.Name = "grdXmlGroupView";
            this.grdXmlGroupView.OptionsDetail.EnableMasterViewMode = false;
            this.grdXmlGroupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdXmlGroupView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdXmlGroupView.OptionsView.ColumnAutoWidth = false;
            this.grdXmlGroupView.OptionsView.ShowAutoFilterRow = true;
            this.grdXmlGroupView.OptionsView.ShowGroupPanel = false;
            this.grdXmlGroupView.OptionsView.ShowIndicator = false;
            // 
            // grdXmlDetail
            // 
            this.grdXmlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdXmlDetail.DataSource = this.bindingSourceDetail;
            this.grdXmlDetail.Location = new System.Drawing.Point(7, 292);
            this.grdXmlDetail.MainView = this.grdXmlDetailView;
            this.grdXmlDetail.Name = "grdXmlDetail";
            this.grdXmlDetail.Size = new System.Drawing.Size(626, 268);
            this.grdXmlDetail.TabIndex = 55;
            this.grdXmlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdXmlDetailView});
            // 
            // grdXmlDetailView
            // 
            this.grdXmlDetailView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdXmlDetailView.GridControl = this.grdXmlDetail;
            this.grdXmlDetailView.Name = "grdXmlDetailView";
            this.grdXmlDetailView.OptionsDetail.EnableMasterViewMode = false;
            this.grdXmlDetailView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdXmlDetailView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdXmlDetailView.OptionsView.ColumnAutoWidth = false;
            this.grdXmlDetailView.OptionsView.ShowAutoFilterRow = true;
            this.grdXmlDetailView.OptionsView.ShowGroupPanel = false;
            this.grdXmlDetailView.OptionsView.ShowIndicator = false;
            // 
            // SelectPath
            // 
            this.SelectPath.Location = new System.Drawing.Point(403, 652);
            this.SelectPath.Name = "SelectPath";
            this.SelectPath.Size = new System.Drawing.Size(41, 23);
            this.SelectPath.TabIndex = 56;
            this.SelectPath.Text = "...";
            this.SelectPath.UseVisualStyleBackColor = true;
            this.SelectPath.Click += new System.EventHandler(this.SelectPath_Click);
            // 
            // FrmXtraExportXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 688);
            this.Controls.Add(this.SelectPath);
            this.Controls.Add(this.grdXmlDetail);
            this.Controls.Add(this.grdXmlGroup);
            this.Controls.Add(this.XmlPathtxt);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExportToExcel);
            this.Name = "FrmXtraExportXML";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.FrmXtraReportList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrencyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAmountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlDetailView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PerpetuumSoft.Reporting.Export.Graph.GifExportFilter gifExportFilter1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private PerpetuumSoft.Reporting.Export.Graph.GifExportFilter gifExportFilter2;
        private DevExpress.XtraEditors.ComboBoxEdit cboCurrencyCode;
        private DateTimeRangeBlockDev.DateTimeRangeV dtReportPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboAmountType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox XmlPathtxt;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private DevExpress.XtraGrid.GridControl grdXmlGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grdXmlGroupView;
        private DevExpress.XtraGrid.GridControl grdXmlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grdXmlDetailView;
        private Button SelectPath;
    }
}