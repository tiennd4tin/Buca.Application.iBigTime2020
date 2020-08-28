namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountCategory
{
    partial class FrmAccountingCategoryDetail
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
            this.txtAccountCategoryId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountCategoryName = new DevExpress.XtraEditors.TextEdit();
            this.choAccountCategoryKind = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkDetailByBudgetChapter = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByInventoryItem = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByMethodDistribute = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByActivity = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByProject = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByBankAccount = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByBudgetSubItem = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByBudgetItem = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByBudgetSource = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByBudgetKindItem = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByFund = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailByAccountingObject = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCategoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choAccountCategoryKind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetChapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByInventoryItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByMethodDistribute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByActivity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetSubItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetKindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByFund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByAccountingObject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(246, 322);
            this.btnSave.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(318, 322);
            this.btnExit.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 322);
            this.btnHelp.TabIndex = 5;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.choAccountCategoryKind);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtAccountCategoryName);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.txtAccountCategoryId);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(382, 116);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // txtAccountCategoryId
            // 
            this.txtAccountCategoryId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountCategoryId.Enabled = false;
            this.txtAccountCategoryId.Location = new System.Drawing.Point(81, 28);
            this.txtAccountCategoryId.Name = "txtAccountCategoryId";
            this.txtAccountCategoryId.Size = new System.Drawing.Size(88, 20);
            this.txtAccountCategoryId.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mã nhóm (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tên nhóm (*)";
            // 
            // txtAccountCategoryName
            // 
            this.txtAccountCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountCategoryName.Location = new System.Drawing.Point(81, 55);
            this.txtAccountCategoryName.Name = "txtAccountCategoryName";
            this.txtAccountCategoryName.Size = new System.Drawing.Size(290, 20);
            this.txtAccountCategoryName.TabIndex = 3;
            // 
            // choAccountCategoryKind
            // 
            this.choAccountCategoryKind.EditValue = "";
            this.choAccountCategoryKind.Location = new System.Drawing.Point(81, 82);
            this.choAccountCategoryKind.Name = "choAccountCategoryKind";
            this.choAccountCategoryKind.Properties.AutoComplete = false;
            this.choAccountCategoryKind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.choAccountCategoryKind.Properties.Items.AddRange(new object[] {
            "Dư nợ",
            "Dư có",
            "Lưỡng tính"});
            this.choAccountCategoryKind.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.choAccountCategoryKind.Size = new System.Drawing.Size(290, 20);
            this.choAccountCategoryKind.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(61, 13);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "&Tính chất (*)";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.chkDetailByBudgetChapter);
            this.groupControl1.Controls.Add(this.chkDetailByInventoryItem);
            this.groupControl1.Controls.Add(this.chkDetailByMethodDistribute);
            this.groupControl1.Controls.Add(this.chkDetailByActivity);
            this.groupControl1.Controls.Add(this.chkDetailByProject);
            this.groupControl1.Controls.Add(this.chkDetailByBankAccount);
            this.groupControl1.Controls.Add(this.chkDetailByBudgetSubItem);
            this.groupControl1.Controls.Add(this.chkDetailByBudgetItem);
            this.groupControl1.Controls.Add(this.chkDetailByBudgetSource);
            this.groupControl1.Controls.Add(this.chkDetailByBudgetKindItem);
            this.groupControl1.Controls.Add(this.chkDetailByFund);
            this.groupControl1.Controls.Add(this.chkDetailByAccountingObject);
            this.groupControl1.Location = new System.Drawing.Point(8, 129);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(382, 156);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Chi tiết theo";
            // 
            // chkDetailByBudgetChapter
            // 
            this.chkDetailByBudgetChapter.Location = new System.Drawing.Point(158, 128);
            this.chkDetailByBudgetChapter.Name = "chkDetailByBudgetChapter";
            this.chkDetailByBudgetChapter.Properties.Caption = "&Chương";
            this.chkDetailByBudgetChapter.Size = new System.Drawing.Size(76, 19);
            this.chkDetailByBudgetChapter.TabIndex = 9;
            // 
            // chkDetailByInventoryItem
            // 
            this.chkDetailByInventoryItem.Location = new System.Drawing.Point(260, 28);
            this.chkDetailByInventoryItem.Name = "chkDetailByInventoryItem";
            this.chkDetailByInventoryItem.Properties.Caption = "&Vật tư, hàng hóa";
            this.chkDetailByInventoryItem.Size = new System.Drawing.Size(108, 19);
            this.chkDetailByInventoryItem.TabIndex = 10;
            // 
            // chkDetailByMethodDistribute
            // 
            this.chkDetailByMethodDistribute.Location = new System.Drawing.Point(260, 53);
            this.chkDetailByMethodDistribute.Name = "chkDetailByMethodDistribute";
            this.chkDetailByMethodDistribute.Properties.Caption = "&Hình thức cấp phát";
            this.chkDetailByMethodDistribute.Size = new System.Drawing.Size(132, 19);
            this.chkDetailByMethodDistribute.TabIndex = 11;
            this.chkDetailByMethodDistribute.Visible = false;
            // 
            // chkDetailByActivity
            // 
            this.chkDetailByActivity.Location = new System.Drawing.Point(158, 103);
            this.chkDetailByActivity.Name = "chkDetailByActivity";
            this.chkDetailByActivity.Properties.Caption = "&Hoạt động";
            this.chkDetailByActivity.Size = new System.Drawing.Size(119, 19);
            this.chkDetailByActivity.TabIndex = 8;
            // 
            // chkDetailByProject
            // 
            this.chkDetailByProject.Location = new System.Drawing.Point(158, 78);
            this.chkDetailByProject.Name = "chkDetailByProject";
            this.chkDetailByProject.Properties.Caption = "&Dự án";
            this.chkDetailByProject.Size = new System.Drawing.Size(115, 19);
            this.chkDetailByProject.TabIndex = 7;
            // 
            // chkDetailByBankAccount
            // 
            this.chkDetailByBankAccount.Location = new System.Drawing.Point(10, 128);
            this.chkDetailByBankAccount.Name = "chkDetailByBankAccount";
            this.chkDetailByBankAccount.Properties.Caption = "&TK Ngân hàng, kho bạc";
            this.chkDetailByBankAccount.Size = new System.Drawing.Size(135, 19);
            this.chkDetailByBankAccount.TabIndex = 4;
            // 
            // chkDetailByBudgetSubItem
            // 
            this.chkDetailByBudgetSubItem.Location = new System.Drawing.Point(10, 103);
            this.chkDetailByBudgetSubItem.Name = "chkDetailByBudgetSubItem";
            this.chkDetailByBudgetSubItem.Properties.Caption = "&Tiểu mục";
            this.chkDetailByBudgetSubItem.Size = new System.Drawing.Size(135, 19);
            this.chkDetailByBudgetSubItem.TabIndex = 3;
            // 
            // chkDetailByBudgetItem
            // 
            this.chkDetailByBudgetItem.Location = new System.Drawing.Point(10, 78);
            this.chkDetailByBudgetItem.Name = "chkDetailByBudgetItem";
            this.chkDetailByBudgetItem.Properties.Caption = "&Mục";
            this.chkDetailByBudgetItem.Size = new System.Drawing.Size(135, 19);
            this.chkDetailByBudgetItem.TabIndex = 2;
            // 
            // chkDetailByBudgetSource
            // 
            this.chkDetailByBudgetSource.Location = new System.Drawing.Point(10, 28);
            this.chkDetailByBudgetSource.Name = "chkDetailByBudgetSource";
            this.chkDetailByBudgetSource.Properties.Caption = "&Nguồn vốn";
            this.chkDetailByBudgetSource.Size = new System.Drawing.Size(135, 19);
            this.chkDetailByBudgetSource.TabIndex = 0;
            // 
            // chkDetailByBudgetKindItem
            // 
            this.chkDetailByBudgetKindItem.Location = new System.Drawing.Point(10, 53);
            this.chkDetailByBudgetKindItem.Name = "chkDetailByBudgetKindItem";
            this.chkDetailByBudgetKindItem.Properties.Caption = "&Loại khoản";
            this.chkDetailByBudgetKindItem.Size = new System.Drawing.Size(135, 19);
            this.chkDetailByBudgetKindItem.TabIndex = 1;
            // 
            // chkDetailByFund
            // 
            this.chkDetailByFund.Location = new System.Drawing.Point(158, 28);
            this.chkDetailByFund.Name = "chkDetailByFund";
            this.chkDetailByFund.Properties.Caption = "&Loại quỹ";
            this.chkDetailByFund.Size = new System.Drawing.Size(115, 19);
            this.chkDetailByFund.TabIndex = 5;
            // 
            // chkDetailByAccountingObject
            // 
            this.chkDetailByAccountingObject.Location = new System.Drawing.Point(158, 53);
            this.chkDetailByAccountingObject.Name = "chkDetailByAccountingObject";
            this.chkDetailByAccountingObject.Properties.Caption = "&Đối tượng";
            this.chkDetailByAccountingObject.Size = new System.Drawing.Size(115, 19);
            this.chkDetailByAccountingObject.TabIndex = 6;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(6, 294);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "&Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(135, 19);
            this.chkIsActive.TabIndex = 2;
            // 
            // FrmAccountingCategoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 354);
            this.ComponentName = "Nhóm tài khoản";
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.groupControl1);
            this.EventTime = new System.DateTime(2018, 2, 7, 11, 6, 2, 362);
            this.FormCaption = "Nhóm tài khoản";
            this.Name = "FrmAccountingCategoryDetail";
            this.Reference = "THÊM NHÓM TÀI KHOẢN - ID ";
            this.Text = "Nhóm tài khoản";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCategoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choAccountCategoryKind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetChapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByInventoryItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByMethodDistribute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByActivity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetSubItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByBudgetKindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByFund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailByAccountingObject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.TextEdit txtAccountCategoryId;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        protected DevExpress.XtraEditors.TextEdit txtAccountCategoryName;
        protected DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit choAccountCategoryKind;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkDetailByBudgetChapter;
        private DevExpress.XtraEditors.CheckEdit chkDetailByInventoryItem;
        private DevExpress.XtraEditors.CheckEdit chkDetailByMethodDistribute;
        private DevExpress.XtraEditors.CheckEdit chkDetailByActivity;
        private DevExpress.XtraEditors.CheckEdit chkDetailByProject;
        private DevExpress.XtraEditors.CheckEdit chkDetailByBankAccount;
        private DevExpress.XtraEditors.CheckEdit chkDetailByBudgetSubItem;
        private DevExpress.XtraEditors.CheckEdit chkDetailByBudgetItem;
        private DevExpress.XtraEditors.CheckEdit chkDetailByBudgetSource;
        private DevExpress.XtraEditors.CheckEdit chkDetailByBudgetKindItem;
        private DevExpress.XtraEditors.CheckEdit chkDetailByFund;
        private DevExpress.XtraEditors.CheckEdit chkDetailByAccountingObject;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}