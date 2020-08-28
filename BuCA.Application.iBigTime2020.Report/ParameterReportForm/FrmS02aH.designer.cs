namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS02aH
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
            this.gridAccountNumberControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceAccount = new System.Windows.Forms.BindingSource(this.components);
            this.gridAccountNumberView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bindingSourceAccountingObject = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.button1 = new System.Windows.Forms.Button();
            this.CbxisShowOriginalCurrency = new DevExpress.XtraEditors.CheckEdit();
            this.CbxisGroupSameRow = new DevExpress.XtraEditors.CheckEdit();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountNumberControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountNumberView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountingObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbxisShowOriginalCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxisGroupSameRow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.gridAccountNumberControl);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Size = new System.Drawing.Size(611, 593);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(462, 608);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(543, 608);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 608);
            // 
            // gridAccountNumberControl
            // 
            this.gridAccountNumberControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAccountNumberControl.DataSource = this.bindingSourceAccount;
            this.gridAccountNumberControl.Location = new System.Drawing.Point(3, 107);
            this.gridAccountNumberControl.MainView = this.gridAccountNumberView;
            this.gridAccountNumberControl.Name = "gridAccountNumberControl";
            this.gridAccountNumberControl.Size = new System.Drawing.Size(601, 465);
            this.gridAccountNumberControl.TabIndex = 47;
            this.gridAccountNumberControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAccountNumberView});
            // 
            // gridAccountNumberView
            // 
            this.gridAccountNumberView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridAccountNumberView.GridControl = this.gridAccountNumberControl;
            this.gridAccountNumberView.Name = "gridAccountNumberView";
            this.gridAccountNumberView.OptionsDetail.EnableMasterViewMode = false;
            this.gridAccountNumberView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridAccountNumberView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridAccountNumberView.OptionsView.ShowGroupPanel = false;
            this.gridAccountNumberView.OptionsView.ShowIndicator = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.button1);
            this.groupControl1.Controls.Add(this.CbxisShowOriginalCurrency);
            this.groupControl1.Controls.Add(this.CbxisGroupSameRow);
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(4, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(600, 82);
            this.groupControl1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(311, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 70);
            this.button1.TabIndex = 26;
            this.button1.Text = "Lọc";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ChangeDatetime);
            // 
            // CbxisShowOriginalCurrency
            // 
            this.CbxisShowOriginalCurrency.Location = new System.Drawing.Point(403, 44);
            this.CbxisShowOriginalCurrency.Name = "CbxisShowOriginalCurrency";
            this.CbxisShowOriginalCurrency.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.CbxisShowOriginalCurrency.Properties.Caption = "Hiển thị số tiền nguyên tệ";
            this.CbxisShowOriginalCurrency.Size = new System.Drawing.Size(192, 19);
            this.CbxisShowOriginalCurrency.TabIndex = 25;
            // 
            // CbxisGroupSameRow
            // 
            this.CbxisGroupSameRow.Location = new System.Drawing.Point(403, 19);
            this.CbxisGroupSameRow.Name = "CbxisGroupSameRow";
            this.CbxisGroupSameRow.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.CbxisGroupSameRow.Properties.Caption = "Cộng gộp các bút toán giống nhau";
            this.CbxisGroupSameRow.Size = new System.Drawing.Size(192, 19);
            this.CbxisGroupSameRow.TabIndex = 24;
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 5);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(300, 70);
            this.dateTimeRangeV1.TabIndex = 23;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // FrmS02aH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 642);
            this.Name = "FrmS02aH";
            this.Text = "Sổ chi tiết tài khoản";
            this.Load += new System.EventHandler(this.FrmS02aH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountNumberControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountNumberView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountingObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CbxisShowOriginalCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxisGroupSameRow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridAccountNumberControl;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.BindingSource bindingSourceAccount;
        private System.Windows.Forms.BindingSource bindingSourceAccountingObject;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.CheckEdit CbxisShowOriginalCurrency;
        private DevExpress.XtraEditors.CheckEdit CbxisGroupSameRow;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAccountNumberView;
        private System.Windows.Forms.Button button1;
    }
}