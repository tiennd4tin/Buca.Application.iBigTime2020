namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS13H
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
            this.gridAccounts = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridAccountsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.lookUpEditCurrencyCode = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkIsDetail = new DevExpress.XtraEditors.CheckEdit();
            this.ckbIsDetailMonth = new DevExpress.XtraEditors.CheckEdit();
            this.grdBank = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceBank = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewBank = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCurrencyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbIsDetailMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewBank)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.ckbIsDetailMonth);
            this.groupboxMain.Controls.Add(this.checkIsDetail);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.lookUpEditCurrencyCode);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Location = new System.Drawing.Point(8, 10);
            this.groupboxMain.Size = new System.Drawing.Size(557, 80);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(412, 539);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(493, 539);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 539);
            // 
            // gridAccounts
            // 
            this.gridAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAccounts.DataSource = this.bindingSource;
            this.gridAccounts.Location = new System.Drawing.Point(8, 98);
            this.gridAccounts.MainView = this.gridAccountsView;
            this.gridAccounts.Name = "gridAccounts";
            this.gridAccounts.Size = new System.Drawing.Size(557, 179);
            this.gridAccounts.TabIndex = 8;
            this.gridAccounts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAccountsView});
            // 
            // gridAccountsView
            // 
            this.gridAccountsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridAccountsView.GridControl = this.gridAccounts;
            this.gridAccountsView.Name = "gridAccountsView";
            this.gridAccountsView.OptionsDetail.EnableMasterViewMode = false;
            this.gridAccountsView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridAccountsView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridAccountsView.OptionsView.ShowGroupPanel = false;
            this.gridAccountsView.OptionsView.ShowIndicator = false;
            this.gridAccountsView.OptionsView.ShowViewCaption = true;
            this.gridAccountsView.ViewCaption = "Tài khoản";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(2, 3);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.TabIndex = 0;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // lookUpEditCurrencyCode
            // 
            this.lookUpEditCurrencyCode.EditValue = "";
            this.lookUpEditCurrencyCode.Location = new System.Drawing.Point(345, 15);
            this.lookUpEditCurrencyCode.Name = "lookUpEditCurrencyCode";
            this.lookUpEditCurrencyCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditCurrencyCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCurrencyCode.Properties.NullText = "";
            this.lookUpEditCurrencyCode.Size = new System.Drawing.Size(210, 20);
            this.lookUpEditCurrencyCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(299, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Loại tiền";
            // 
            // checkIsDetail
            // 
            this.checkIsDetail.Location = new System.Drawing.Point(297, 43);
            this.checkIsDetail.Name = "checkIsDetail";
            this.checkIsDetail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkIsDetail.Properties.Caption = "Xem sổ chi tiết";
            this.checkIsDetail.Size = new System.Drawing.Size(114, 19);
            this.checkIsDetail.TabIndex = 2;
            // 
            // ckbIsDetailMonth
            // 
            this.ckbIsDetailMonth.Location = new System.Drawing.Point(413, 44);
            this.ckbIsDetailMonth.Name = "ckbIsDetailMonth";
            this.ckbIsDetailMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.ckbIsDetailMonth.Properties.Caption = "Xem chi tiết theo tháng";
            this.ckbIsDetailMonth.Size = new System.Drawing.Size(142, 19);
            this.ckbIsDetailMonth.TabIndex = 3;
            // 
            // grdBank
            // 
            this.grdBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBank.DataSource = this.bindingSourceBank;
            this.grdBank.Location = new System.Drawing.Point(8, 283);
            this.grdBank.MainView = this.grdViewBank;
            this.grdBank.Name = "grdBank";
            this.grdBank.Size = new System.Drawing.Size(557, 247);
            this.grdBank.TabIndex = 9;
            this.grdBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewBank});
            // 
            // grdViewBank
            // 
            this.grdViewBank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdViewBank.GridControl = this.grdBank;
            this.grdViewBank.Name = "grdViewBank";
            this.grdViewBank.OptionsDetail.EnableMasterViewMode = false;
            this.grdViewBank.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdViewBank.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdViewBank.OptionsView.ShowGroupPanel = false;
            this.grdViewBank.OptionsView.ShowIndicator = false;
            this.grdViewBank.OptionsView.ShowViewCaption = true;
            this.grdViewBank.ViewCaption = "Tài khoản ngân hàng";
            // 
            // FrmS13H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 573);
            this.Controls.Add(this.grdBank);
            this.Controls.Add(this.gridAccounts);
            this.Name = "FrmS13H";
            this.Load += new System.EventHandler(this.FrmS13H_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.gridAccounts, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.grdBank, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCurrencyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbIsDetailMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewBank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridAccounts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAccountsView;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCurrencyCode;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.CheckEdit checkIsDetail;
        private DevExpress.XtraEditors.CheckEdit ckbIsDetailMonth;
        private DevExpress.XtraGrid.GridControl grdBank;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewBank;
        private System.Windows.Forms.BindingSource bindingSourceBank;
    }
}