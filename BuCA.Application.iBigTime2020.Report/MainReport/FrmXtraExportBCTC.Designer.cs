using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.ReportClass;

namespace BuCA.Application.iBigTime2020.Report.MainReport
{
    partial class FrmXtraExportBCTC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraExportBCTC));
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters2 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            this.gifExportFilter1 = new PerpetuumSoft.Reporting.Export.Graph.GifExportFilter();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.gifExportFilter2 = new PerpetuumSoft.Reporting.Export.Graph.GifExportFilter();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource();
            this.grdXmlGroup = new DevExpress.XtraGrid.GridControl();
            this.grdXmlGroupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdXmlSource = new DevExpress.XtraGrid.GridControl();
            this.grdXmlBudgetSourceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbxReportTime = new System.Windows.Forms.ComboBox();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlBudgetSourceView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ImageIndex = 4;
            this.btnExit.ImageList = this.imageCollection;
            this.btnExit.Location = new System.Drawing.Point(743, 498);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 25);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "&Hủy";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.ImageIndex = 5;
            this.btnExport.ImageList = this.imageCollection;
            this.btnExport.Location = new System.Drawing.Point(656, 498);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 25);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Xuất File";
            this.btnExport.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // grdXmlGroup
            // 
            this.grdXmlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdXmlGroup.DataSource = this.bindingSource;
            this.grdXmlGroup.Location = new System.Drawing.Point(12, 101);
            this.grdXmlGroup.MainView = this.grdXmlGroupView;
            this.grdXmlGroup.Name = "grdXmlGroup";
            this.grdXmlGroup.Size = new System.Drawing.Size(812, 391);
            this.grdXmlGroup.TabIndex = 54;
            this.grdXmlGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdXmlGroupView});
            // 
            // grdXmlGroupView
            // 
            this.grdXmlGroupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdXmlGroupView.GridControl = this.grdXmlGroup;
            this.grdXmlGroupView.Name = "grdXmlGroupView";
            this.grdXmlGroupView.OptionsDetail.EnableMasterViewMode = false;
            this.grdXmlGroupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdXmlGroupView.OptionsSelection.MultiSelect = true;
            this.grdXmlGroupView.OptionsView.ColumnAutoWidth = false;
            this.grdXmlGroupView.OptionsView.ShowAutoFilterRow = true;
            this.grdXmlGroupView.OptionsView.ShowGroupPanel = false;
            this.grdXmlGroupView.OptionsView.ShowIndicator = false;
            // 
            // grdXmlSource
            // 
            this.grdXmlSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdXmlSource.DataSource = this.bindingSourceDetail;
            this.grdXmlSource.Location = new System.Drawing.Point(12, 101);
            this.grdXmlSource.MainView = this.grdXmlBudgetSourceView;
            this.grdXmlSource.Name = "grdXmlSource";
            this.grdXmlSource.Size = new System.Drawing.Size(812, 391);
            this.grdXmlSource.TabIndex = 55;
            this.grdXmlSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdXmlBudgetSourceView});
            this.grdXmlSource.Visible = false;
            // 
            // grdXmlBudgetSourceView
            // 
            this.grdXmlBudgetSourceView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdXmlBudgetSourceView.GridControl = this.grdXmlSource;
            this.grdXmlBudgetSourceView.Name = "grdXmlBudgetSourceView";
            this.grdXmlBudgetSourceView.OptionsDetail.EnableMasterViewMode = false;
            this.grdXmlBudgetSourceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdXmlBudgetSourceView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdXmlBudgetSourceView.OptionsView.ColumnAutoWidth = false;
            this.grdXmlBudgetSourceView.OptionsView.ShowAutoFilterRow = true;
            this.grdXmlBudgetSourceView.OptionsView.ShowGroupPanel = false;
            this.grdXmlBudgetSourceView.OptionsView.ShowIndicator = false;
            // 
            // cbxReportTime
            // 
            this.cbxReportTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReportTime.FormattingEnabled = true;
            this.cbxReportTime.Items.AddRange(new object[] {
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4",
            "Cả năm"});
            this.cbxReportTime.Location = new System.Drawing.Point(73, 20);
            this.cbxReportTime.Name = "cbxReportTime";
            this.cbxReportTime.Size = new System.Drawing.Size(121, 21);
            this.cbxReportTime.TabIndex = 57;
            // 
            // cbxYear
            // 
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.cbxYear.Location = new System.Drawing.Point(200, 20);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(73, 21);
            this.cbxYear.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxYear);
            this.groupBox1.Controls.Add(this.cbxReportTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 55);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kỳ báo cáo xuất khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Kỳ báo cáo";
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Enabled = false;
            this.btnPrev.ImageList = this.imageCollection;
            this.btnPrev.Location = new System.Drawing.Point(482, 498);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(81, 25);
            this.btnPrev.TabIndex = 60;
            this.btnPrev.Text = "Về trước";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.ImageList = this.imageCollection;
            this.btnNext.Location = new System.Drawing.Point(569, 498);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 25);
            this.btnNext.TabIndex = 61;
            this.btnNext.Text = "Tiếp theo";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(249, 27);
            this.lblTitle.TabIndex = 60;
            this.lblTitle.Text = "Chọn báo cáo để xuất";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(812, 55);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label3.Location = new System.Drawing.Point(450, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh mục nguồn của đơn vị cấp trên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label2.Location = new System.Drawing.Point(72, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh mục nguồn tại đơn vị";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtPath);
            this.groupBox3.Location = new System.Drawing.Point(12, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(812, 55);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(760, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(9, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(745, 21);
            this.txtPath.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 20);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(797, 23);
            this.progressBar.TabIndex = 64;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar);
            this.groupBox4.Location = new System.Drawing.Point(12, 435);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(812, 57);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tiến độ";
            this.groupBox4.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FrmXtraExportBCTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 535);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.grdXmlSource);
            this.Controls.Add(this.grdXmlGroup);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmXtraExportBCTC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất khẩu báo cáo tài chính";
            this.Load += new System.EventHandler(this.FrmXtraReportList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmXtraExportBCTC_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlGroupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXmlBudgetSourceView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PerpetuumSoft.Reporting.Export.Graph.GifExportFilter gifExportFilter1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private PerpetuumSoft.Reporting.Export.Graph.GifExportFilter gifExportFilter2;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private DevExpress.XtraGrid.GridControl grdXmlGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grdXmlGroupView;
        private DevExpress.XtraGrid.GridControl grdXmlSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grdXmlBudgetSourceView;
        private ComboBox cbxReportTime;
        private ComboBox cbxYear;
        private GroupBox groupBox1;
        private Label label1;
        public DevExpress.XtraEditors.SimpleButton btnPrev;
        public DevExpress.XtraEditors.SimpleButton btnNext;
        private Label lblTitle;
        private GroupBox groupBox2;
        private Label label3;
        private Label label2;
        private GroupBox groupBox3;
        private Button button1;
        private TextBox txtPath;
        private ProgressBar progressBar;
        private GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}