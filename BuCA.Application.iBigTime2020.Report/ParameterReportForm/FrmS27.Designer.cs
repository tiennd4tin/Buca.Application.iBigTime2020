namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS27
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.checkcboBudgetSource = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridProjectControl = new DevExpress.XtraGrid.GridControl();
            this.gridProjectView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbxAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.gridProjectControl);
            this.groupboxMain.Controls.Add(this.checkcboBudgetSource);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.cbxAccount);
            this.groupboxMain.Size = new System.Drawing.Size(618, 381);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(469, 396);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(550, 396);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 396);
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 5);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(296, 70);
            this.dateTimeRangeV1.TabIndex = 24;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(322, 48);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 92;
            this.labelControl5.Text = "Nguồn vốn";
            // 
            // checkcboBudgetSource
            // 
            this.checkcboBudgetSource.EditValue = "";
            this.checkcboBudgetSource.Location = new System.Drawing.Point(380, 45);
            this.checkcboBudgetSource.Name = "checkcboBudgetSource";
            this.checkcboBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkcboBudgetSource.Properties.SelectAllItemVisible = false;
            this.checkcboBudgetSource.Size = new System.Drawing.Size(227, 20);
            this.checkcboBudgetSource.TabIndex = 93;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(322, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 95;
            this.labelControl1.Text = "Tài khoản";
            // 
            // gridProjectControl
            // 
            this.gridProjectControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProjectControl.Location = new System.Drawing.Point(5, 81);
            this.gridProjectControl.MainView = this.gridProjectView;
            this.gridProjectControl.Name = "gridProjectControl";
            this.gridProjectControl.Size = new System.Drawing.Size(608, 295);
            this.gridProjectControl.TabIndex = 96;
            this.gridProjectControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProjectView,
            this.gridView1});
            // 
            // gridProjectView
            // 
            this.gridProjectView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridProjectView.GridControl = this.gridProjectControl;
            this.gridProjectView.Name = "gridProjectView";
            this.gridProjectView.OptionsDetail.EnableMasterViewMode = false;
            this.gridProjectView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridProjectView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridProjectView.OptionsView.ShowAutoFilterRow = true;
            this.gridProjectView.OptionsView.ShowGroupPanel = false;
            this.gridProjectView.OptionsView.ShowIndicator = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridProjectControl;
            this.gridView1.Name = "gridView1";
            // 
            // cbxAccount
            // 
            this.cbxAccount.Location = new System.Drawing.Point(380, 19);
            this.cbxAccount.Name = "cbxAccount";
            this.cbxAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxAccount.Properties.NullText = "";
            this.cbxAccount.Properties.PopupSizeable = false;
            this.cbxAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbxAccount.Size = new System.Drawing.Size(227, 20);
            this.cbxAccount.TabIndex = 94;
            // 
            // FrmS27
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 433);
            this.Name = "FrmS27";
            this.Text = "Sổ chi phí đầu tư xây dựng";
            this.Load += new System.EventHandler(this.FrmS27_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkcboBudgetSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridProjectControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProjectView;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkcboBudgetSource;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit cbxAccount;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}