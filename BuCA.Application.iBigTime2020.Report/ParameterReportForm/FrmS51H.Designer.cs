﻿namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS51H
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
            this.gridInventoryControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            this.gridInventoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboActivity = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboInventoryType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.rndOption = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboActivity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).BeginInit();
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
            this.btnOk.Location = new System.Drawing.Point(466, 439);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(547, 439);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 439);
            // 
            // gridInventoryControl
            // 
            this.gridInventoryControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInventoryControl.DataSource = this.bindingSource;
            this.gridInventoryControl.Location = new System.Drawing.Point(6, 119);
            this.gridInventoryControl.MainView = this.gridInventoryView;
            this.gridInventoryControl.Name = "gridInventoryControl";
            this.gridInventoryControl.Size = new System.Drawing.Size(615, 314);
            this.gridInventoryControl.TabIndex = 4;
            this.gridInventoryControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInventoryView});
            // 
            // gridInventoryView
            // 
            this.gridInventoryView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridInventoryView.GridControl = this.gridInventoryControl;
            this.gridInventoryView.Name = "gridInventoryView";
            this.gridInventoryView.OptionsDetail.EnableMasterViewMode = false;
            this.gridInventoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridInventoryView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridInventoryView.OptionsView.ShowAutoFilterRow = true;
            this.gridInventoryView.OptionsView.ShowGroupPanel = false;
            this.gridInventoryView.OptionsView.ShowIndicator = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(6, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(305, 105);
            this.groupControl1.TabIndex = 0;
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
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 25);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(295, 72);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.cboActivity);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cboInventoryType);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Location = new System.Drawing.Point(317, 8);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(304, 67);
            this.groupControl2.TabIndex = 1;
            // 
            // cboActivity
            // 
            this.cboActivity.Location = new System.Drawing.Point(99, 8);
            this.cboActivity.Name = "cboActivity";
            this.cboActivity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboActivity.Properties.NullText = "";
            this.cboActivity.Properties.PopupSizeable = false;
            this.cboActivity.Properties.PopupWidth = 460;
            this.cboActivity.Size = new System.Drawing.Size(199, 20);
            this.cboActivity.TabIndex = 88;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 89;
            this.labelControl1.Text = "Hoạt động";
            // 
            // cboInventoryType
            // 
            this.cboInventoryType.Location = new System.Drawing.Point(99, 34);
            this.cboInventoryType.Name = "cboInventoryType";
            this.cboInventoryType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboInventoryType.Properties.NullText = "";
            this.cboInventoryType.Properties.PopupSizeable = false;
            this.cboInventoryType.Properties.PopupWidth = 460;
            this.cboInventoryType.Size = new System.Drawing.Size(199, 20);
            this.cboInventoryType.TabIndex = 86;
            this.cboInventoryType.EditValueChanged += new System.EventHandler(this.cboInventoryType_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(84, 13);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "Loại vật tư/CCDC";
            // 
            // rndOption
            // 
            this.rndOption.EditValue = "06";
            this.rndOption.Location = new System.Drawing.Point(317, 82);
            this.rndOption.Name = "rndOption";
            this.rndOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rndOption.Properties.Appearance.Options.UseBackColor = true;
            this.rndOption.Properties.Columns = 3;
            this.rndOption.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rndOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("03", "Tất cả"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("06", "Tổng hợp"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("09", "Tùy chọn")});
            this.rndOption.Size = new System.Drawing.Size(307, 31);
            this.rndOption.TabIndex = 91;
            this.rndOption.SelectedIndexChanged += new System.EventHandler(this.rndOption_SelectedIndexChanged);
            // 
            // FrmS51H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 473);
            this.Controls.Add(this.rndOption);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridInventoryControl);
            this.Name = "FrmS51H";
            this.Load += new System.EventHandler(this.FrmS51H_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.gridInventoryControl, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.rndOption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboActivity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridInventoryControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInventoryView;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit cboActivity;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboInventoryType;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.RadioGroup rndOption;
    }
}