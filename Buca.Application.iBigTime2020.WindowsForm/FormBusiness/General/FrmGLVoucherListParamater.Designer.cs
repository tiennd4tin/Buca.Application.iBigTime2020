namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General
{
    partial class FrmGLVoucherListParamater
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
            this.btnFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdAccount = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            this.gridviewAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.panel1);
            this.groupboxMain.Controls.Add(this.btnFilter);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Size = new System.Drawing.Size(1065, 504);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(923, 519);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1004, 519);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 519);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(305, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(748, 50);
            this.btnFilter.TabIndex = 38;
            this.btnFilter.Text = "Liệt kê chứng từ";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdAccount);
            this.panel1.Location = new System.Drawing.Point(5, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 432);
            this.panel1.TabIndex = 1;
            // 
            // grdAccount
            // 
            this.grdAccount.DataSource = this.bindingSource;
            this.grdAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAccount.Location = new System.Drawing.Point(0, 0);
            this.grdAccount.MainView = this.gridviewAccount;
            this.grdAccount.Name = "grdAccount";
            this.grdAccount.Size = new System.Drawing.Size(1048, 432);
            this.grdAccount.TabIndex = 1;
            this.grdAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridviewAccount});
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = true;
            // 
            // gridviewAccount
            // 
            this.gridviewAccount.GridControl = this.grdAccount;
            this.gridviewAccount.Name = "gridviewAccount";
            this.gridviewAccount.OptionsView.ShowGroupPanel = false;
            this.gridviewAccount.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(2, 2);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Thời gian";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(298, 70);
            this.dateTimeRangeV1.TabIndex = 39;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // FrmGLVoucherListParamater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 553);
            this.Name = "FrmGLVoucherListParamater";
            this.Text = "FrmGLVoucherListParamater";
            this.Load += new System.EventHandler(this.FrmGLVoucherListParamater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grdAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridviewAccount;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button btnFilter;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
    }
}