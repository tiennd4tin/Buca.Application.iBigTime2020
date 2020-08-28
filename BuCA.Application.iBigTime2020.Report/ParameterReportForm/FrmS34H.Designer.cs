namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS34H
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
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.grdAccountingObject = new DevExpress.XtraGrid.GridControl();
            this.gridviewAccountingObject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btChooseProject = new DevExpress.XtraEditors.SimpleButton();
            this.cboCorrespondingAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboAccountingObjectCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ckbDetail = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkGroupTheSameItem = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountingObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewAccountingObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCorrespondingAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountingObjectCategory.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.groupBox1);
            this.groupboxMain.Controls.Add(this.groupControl4);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Size = new System.Drawing.Size(609, 469);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(457, 486);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(538, 486);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 486);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 21);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(290, 97);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.grdAccountingObject);
            this.groupControl4.Location = new System.Drawing.Point(5, 180);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(599, 284);
            this.groupControl4.TabIndex = 26;
            this.groupControl4.Text = "Đối tượng";
            // 
            // grdAccountingObject
            // 
            this.grdAccountingObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAccountingObject.Location = new System.Drawing.Point(2, 21);
            this.grdAccountingObject.MainView = this.gridviewAccountingObject;
            this.grdAccountingObject.Name = "grdAccountingObject";
            this.grdAccountingObject.Size = new System.Drawing.Size(595, 261);
            this.grdAccountingObject.TabIndex = 0;
            this.grdAccountingObject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridviewAccountingObject});
            // 
            // gridviewAccountingObject
            // 
            this.gridviewAccountingObject.GridControl = this.grdAccountingObject;
            this.gridviewAccountingObject.Name = "gridviewAccountingObject";
            this.gridviewAccountingObject.OptionsView.ShowAutoFilterRow = true;
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
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(306, 127);
            this.groupControl1.TabIndex = 23;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "Chọn kỳ báo cáo";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 65;
            this.labelControl5.Text = "Tài khoản";
            // 
            // cboAccount
            // 
            this.cboAccount.Location = new System.Drawing.Point(103, 37);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAccount.Properties.NullText = "";
            this.cboAccount.Size = new System.Drawing.Size(178, 20);
            this.cboAccount.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.btChooseProject);
            this.groupControl2.Controls.Add(this.cboCorrespondingAccount);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.cboAccountingObjectCategory);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.ckbDetail);
            this.groupControl2.Controls.Add(this.cboAccount);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(314, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(290, 127);
            this.groupControl2.TabIndex = 24;
            // 
            // btChooseProject
            // 
            this.btChooseProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btChooseProject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btChooseProject.Location = new System.Drawing.Point(153, 93);
            this.btChooseProject.Name = "btChooseProject";
            this.btChooseProject.Size = new System.Drawing.Size(128, 25);
            this.btChooseProject.TabIndex = 94;
            this.btChooseProject.Text = "Chọn dự án";
            this.btChooseProject.Click += new System.EventHandler(this.btChooseProject_Click);
            // 
            // cboCorrespondingAccount
            // 
            this.cboCorrespondingAccount.Location = new System.Drawing.Point(103, 67);
            this.cboCorrespondingAccount.Name = "cboCorrespondingAccount";
            this.cboCorrespondingAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCorrespondingAccount.Properties.NullText = "";
            this.cboCorrespondingAccount.Size = new System.Drawing.Size(178, 20);
            this.cboCorrespondingAccount.TabIndex = 92;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 93;
            this.labelControl3.Text = "Tài khoản đối ứng";
            // 
            // cboAccountingObjectCategory
            // 
            this.cboAccountingObjectCategory.Location = new System.Drawing.Point(103, 8);
            this.cboAccountingObjectCategory.Name = "cboAccountingObjectCategory";
            this.cboAccountingObjectCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAccountingObjectCategory.Properties.NullText = "";
            this.cboAccountingObjectCategory.Size = new System.Drawing.Size(178, 20);
            this.cboAccountingObjectCategory.TabIndex = 90;
            this.cboAccountingObjectCategory.EditValueChanged += new System.EventHandler(this.cboAccountingObjectCategory_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 91;
            this.labelControl1.Text = "Loại đối tượng";
            // 
            // ckbDetail
            // 
            this.ckbDetail.AutoSize = true;
            this.ckbDetail.BackColor = System.Drawing.Color.Gainsboro;
            this.ckbDetail.Location = new System.Drawing.Point(10, 97);
            this.ckbDetail.Name = "ckbDetail";
            this.ckbDetail.Size = new System.Drawing.Size(137, 17);
            this.ckbDetail.TabIndex = 89;
            this.ckbDetail.Text = "Xem chi tiết theo tháng";
            this.ckbDetail.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkGroupTheSameItem);
            this.groupBox1.Location = new System.Drawing.Point(5, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 37);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // chkGroupTheSameItem
            // 
            this.chkGroupTheSameItem.AutoSize = true;
            this.chkGroupTheSameItem.Location = new System.Drawing.Point(10, 13);
            this.chkGroupTheSameItem.Name = "chkGroupTheSameItem";
            this.chkGroupTheSameItem.Size = new System.Drawing.Size(191, 17);
            this.chkGroupTheSameItem.TabIndex = 89;
            this.chkGroupTheSameItem.Text = "Cộng gộp các bút toán giống nhau";
            this.chkGroupTheSameItem.UseVisualStyleBackColor = true;
            // 
            // FrmS34H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 522);
            this.Name = "FrmS34H";
            this.Load += new System.EventHandler(this.FrmS03H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountingObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewAccountingObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCorrespondingAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountingObjectCategory.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl grdAccountingObject;
        private DevExpress.XtraGrid.Views.Grid.GridView gridviewAccountingObject;
        private System.Windows.Forms.BindingSource bindingSource;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit cboAccount;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkGroupTheSameItem;
        private System.Windows.Forms.CheckBox ckbDetail;
        private DevExpress.XtraEditors.LookUpEdit cboCorrespondingAccount;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cboAccountingObjectCategory;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.SimpleButton btChooseProject;
    }
}