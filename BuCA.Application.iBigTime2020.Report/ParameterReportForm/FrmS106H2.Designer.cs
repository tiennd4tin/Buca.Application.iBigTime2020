﻿namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS106H2
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
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.grdBudgetItem = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewBudgetItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboBudgetKindItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetChapter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboBudgetSource = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rndOption = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudgetItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBudgetItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupControl4);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Controls.Add(this.rndOption);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Location = new System.Drawing.Point(5, 5);
            this.groupboxMain.Size = new System.Drawing.Size(629, 446);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(478, 460);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(559, 460);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 462);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.grdBudgetItem);
            this.groupControl4.Location = new System.Drawing.Point(8, 164);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(612, 277);
            this.groupControl4.TabIndex = 29;
            this.groupControl4.Text = "Chọn Mục lục ngân sách";
            // 
            // grdBudgetItem
            // 
            this.grdBudgetItem.DataSource = this.bindingSource;
            this.grdBudgetItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBudgetItem.Location = new System.Drawing.Point(2, 21);
            this.grdBudgetItem.MainView = this.gridViewBudgetItem;
            this.grdBudgetItem.Name = "grdBudgetItem";
            this.grdBudgetItem.Size = new System.Drawing.Size(608, 254);
            this.grdBudgetItem.TabIndex = 0;
            this.grdBudgetItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBudgetItem});
            // 
            // gridViewBudgetItem
            // 
            this.gridViewBudgetItem.GridControl = this.grdBudgetItem;
            this.gridViewBudgetItem.Name = "gridViewBudgetItem";
            this.gridViewBudgetItem.OptionsView.ColumnAutoWidth = false;
            this.gridViewBudgetItem.OptionsView.ShowAutoFilterRow = true;
            this.gridViewBudgetItem.OptionsView.ShowGroupPanel = false;
            this.gridViewBudgetItem.OptionsView.ShowIndicator = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.cboBudgetKindItem);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cboBudgetChapter);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.cboBudgetSource);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(321, 8);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(299, 150);
            this.groupControl2.TabIndex = 28;
            // 
            // cboBudgetKindItem
            // 
            this.cboBudgetKindItem.Location = new System.Drawing.Point(70, 95);
            this.cboBudgetKindItem.Name = "cboBudgetKindItem";
            this.cboBudgetKindItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetKindItem.Properties.NullText = "";
            this.cboBudgetKindItem.Size = new System.Drawing.Size(210, 20);
            this.cboBudgetKindItem.TabIndex = 88;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 89;
            this.labelControl1.Text = "Khoản";
            // 
            // cboBudgetChapter
            // 
            this.cboBudgetChapter.Location = new System.Drawing.Point(70, 60);
            this.cboBudgetChapter.Name = "cboBudgetChapter";
            this.cboBudgetChapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetChapter.Properties.NullText = "";
            this.cboBudgetChapter.Size = new System.Drawing.Size(210, 20);
            this.cboBudgetChapter.TabIndex = 86;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 64);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(38, 13);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "Chương";
            // 
            // cboBudgetSource
            // 
            this.cboBudgetSource.Location = new System.Drawing.Point(70, 23);
            this.cboBudgetSource.Name = "cboBudgetSource";
            this.cboBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetSource.Properties.NullText = "";
            this.cboBudgetSource.Size = new System.Drawing.Size(210, 20);
            this.cboBudgetSource.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 13);
            this.labelControl5.TabIndex = 65;
            this.labelControl5.Text = "Nguồn";
            // 
            // rndOption
            // 
            this.rndOption.EditValue = "09";
            this.rndOption.Location = new System.Drawing.Point(8, 127);
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
            this.rndOption.TabIndex = 90;
            this.rndOption.SelectedIndexChanged += new System.EventHandler(this.rndOption_SelectedIndexChanged);
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
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(307, 112);
            this.groupControl1.TabIndex = 27;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "Chọn kỳ báo cáo";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 24);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(302, 70);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // FrmS106H2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 500);
            this.Name = "FrmS106H2";
            this.Load += new System.EventHandler(this.FrmS101HPartII_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBudgetItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBudgetItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl grdBudgetItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBudgetItem;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.RadioGroup rndOption;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetKindItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetChapter;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit cboBudgetSource;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}