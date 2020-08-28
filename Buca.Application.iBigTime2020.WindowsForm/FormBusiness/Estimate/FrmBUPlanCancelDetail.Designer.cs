namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    partial class FrmBUPlanCancelDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBUPlanCancelDetail));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.dtDecisionDate = new DevExpress.XtraEditors.DateEdit();
            this.txtDecisionNo = new DevExpress.XtraEditors.TextEdit();
            this.txtBudgetChapterName = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditBudgetChapterCode = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupObject)).BeginInit();
            this.groupObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageToolbar24Collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailByTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupGridDetailMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupUtility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccountingObjectCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDecisionDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDecisionDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetChapterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditBudgetChapterCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            this.imageToobarCollection.Images.SetKeyName(0, "nav_blue_bottom.png");
            this.imageToobarCollection.Images.SetKeyName(1, "nav_blue_left.png");
            this.imageToobarCollection.Images.SetKeyName(2, "nav_blue_right.png");
            this.imageToobarCollection.Images.SetKeyName(3, "nav_blue_up.png");
            this.imageToobarCollection.Images.SetKeyName(4, "undo.png");
            this.imageToobarCollection.Images.SetKeyName(5, "order-add.png");
            this.imageToobarCollection.Images.SetKeyName(6, "order-delete.png");
            this.imageToobarCollection.Images.SetKeyName(7, "order-edit.png");
            this.imageToobarCollection.Images.SetKeyName(8, "order-print.png");
            this.imageToobarCollection.Images.SetKeyName(9, "help.png");
            this.imageToobarCollection.Images.SetKeyName(10, "stop.png");
            this.imageToobarCollection.Images.SetKeyName(11, "refresh_update.png");
            this.imageToobarCollection.Images.SetKeyName(12, "save.png");
            // 
            // groupVoucher
            // 
            this.groupVoucher.Location = new System.Drawing.Point(818, 56);
            this.groupVoucher.Size = new System.Drawing.Size(182, 113);
            // 
            // groupObject
            // 
            this.groupObject.Controls.Add(this.lookUpEditBudgetChapterCode);
            this.groupObject.Controls.Add(this.txtBudgetChapterName);
            this.groupObject.Controls.Add(this.txtDecisionNo);
            this.groupObject.Controls.Add(this.dtDecisionDate);
            this.groupObject.Controls.Add(this.labelControl10);
            this.groupObject.Controls.Add(this.labelControl6);
            this.groupObject.Controls.Add(this.labelControl4);
            this.groupObject.Location = new System.Drawing.Point(8, 56);
            this.groupObject.Size = new System.Drawing.Size(802, 113);
            this.groupObject.Controls.SetChildIndex(this.lblAccountingObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.cboProject, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControlProjectAuto, 0);
            this.groupObject.Controls.SetChildIndex(this.lbAccountingObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.lkAccountingObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl4, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl6, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl10, 0);
            this.groupObject.Controls.SetChildIndex(this.dtDecisionDate, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDecisionNo, 0);
            this.groupObject.Controls.SetChildIndex(this.txtBudgetChapterName, 0);
            this.groupObject.Controls.SetChildIndex(this.lookUpEditBudgetChapterCode, 0);
            // 
            // imageToolbar24Collection
            // 
            this.imageToolbar24Collection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToolbar24Collection.ImageStream")));
            this.imageToolbar24Collection.Images.SetKeyName(0, "close_window.png");
            this.imageToolbar24Collection.Images.SetKeyName(1, "help.png");
            this.imageToolbar24Collection.Images.SetKeyName(2, "nav_green_bottom.png");
            this.imageToolbar24Collection.Images.SetKeyName(3, "nav_green_left.png");
            this.imageToolbar24Collection.Images.SetKeyName(4, "nav_green_right.png");
            this.imageToolbar24Collection.Images.SetKeyName(5, "nav_green_top.png");
            this.imageToolbar24Collection.Images.SetKeyName(6, "order-add.png");
            this.imageToolbar24Collection.Images.SetKeyName(7, "order-delete.png");
            this.imageToolbar24Collection.Images.SetKeyName(8, "order-edit.png");
            this.imageToolbar24Collection.Images.SetKeyName(9, "order-print.png");
            this.imageToolbar24Collection.Images.SetKeyName(10, "refresh_update.png");
            this.imageToolbar24Collection.Images.SetKeyName(11, "save.png");
            this.imageToolbar24Collection.Images.SetKeyName(12, "undo.png");
            this.imageToolbar24Collection.Images.SetKeyName(13, "clipboard_copy.png");
            this.imageToolbar24Collection.Images.SetKeyName(14, "1.dau.png");
            this.imageToolbar24Collection.Images.SetKeyName(15, "2.truoc.png");
            this.imageToolbar24Collection.Images.SetKeyName(16, "3.sau.png");
            this.imageToolbar24Collection.Images.SetKeyName(17, "4.cuoi.png");
            this.imageToolbar24Collection.Images.SetKeyName(18, "5.them.png");
            this.imageToolbar24Collection.Images.SetKeyName(19, "6.sua.png");
            this.imageToolbar24Collection.Images.SetKeyName(20, "7.xoa.png");
            this.imageToolbar24Collection.Images.SetKeyName(21, "8.nhan-ban.png");
            this.imageToolbar24Collection.Images.SetKeyName(22, "9.luu.png");
            this.imageToolbar24Collection.Images.SetKeyName(23, "10.Tienich.png");
            this.imageToolbar24Collection.Images.SetKeyName(24, "11.in.png");
            this.imageToolbar24Collection.Images.SetKeyName(25, "12.hoan.png");
            this.imageToolbar24Collection.Images.SetKeyName(26, "13.nap.png");
            this.imageToolbar24Collection.Images.SetKeyName(27, "14.giup.png");
            this.imageToolbar24Collection.Images.SetKeyName(28, "15.dong.png");
            // 
            // dtRefDate
            // 
            this.dtRefDate.EditValue = new System.DateTime(2014, 3, 18, 19, 18, 2, 581);
            this.dtRefDate.Location = new System.Drawing.Point(55, 83);
            this.dtRefDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtRefDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtRefDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtRefDate.Size = new System.Drawing.Size(118, 20);
            this.dtRefDate.TabIndex = 5;
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(55, 56);
            this.dtPostDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPostDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPostDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtPostDate.Size = new System.Drawing.Size(118, 20);
            this.dtPostDate.TabIndex = 3;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(55, 29);
            this.txtRefNo.Size = new System.Drawing.Size(118, 20);
            this.txtRefNo.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 86);
            this.labelControl3.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 59);
            this.labelControl2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 32);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(9, 87);
            this.labelControl8.Size = new System.Drawing.Size(40, 13);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "Diễn giải";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 140);
            this.txtAddress.Size = new System.Drawing.Size(693, 20);
            this.txtAddress.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(17, 140);
            this.labelControl7.Visible = false;
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(204, 140);
            this.cboObjectName.Size = new System.Drawing.Size(593, 20);
            this.cboObjectName.Visible = false;
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(104, 140);
            this.cboObjectCode.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 140);
            this.labelControl5.Visible = false;
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(104, 140);
            this.txtContactName.Size = new System.Drawing.Size(693, 20);
            this.txtContactName.Visible = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(17, 140);
            this.labelControl9.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(94, 83);
            this.txtDescription.Size = new System.Drawing.Size(700, 20);
            this.txtDescription.TabIndex = 8;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(17, 140);
            this.lblBankAccount.Visible = false;
            // 
            // tabAccounting
            // 
            this.tabAccounting.Size = new System.Drawing.Size(991, 312);
            // 
            // tabAccountingDetail
            // 
            this.tabAccountingDetail.Size = new System.Drawing.Size(991, 312);
            // 
            // tabTax
            // 
            this.tabTax.Size = new System.Drawing.Size(991, 312);
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(8, 234);
            this.tabMain.SelectedTabPage = this.tabAccounting;
            this.tabMain.Size = new System.Drawing.Size(993, 337);
            this.tabMain.TabIndex = 3;
            // 
            // cboBank
            // 
            this.cboBank.Visible = false;
            // 
            // tabInventoryItem
            // 
            this.tabInventoryItem.Size = new System.Drawing.Size(991, 312);
            // 
            // tabrevaluation
            // 
            this.tabrevaluation.Size = new System.Drawing.Size(991, 312);
            // 
            // cboProject
            // 
            // 
            // lkAccountingObjectCategory
            // 
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(79, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Ngày quyết định";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(232, 33);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(31, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Số QĐ";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(9, 60);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(38, 13);
            this.labelControl10.TabIndex = 4;
            this.labelControl10.Text = "Chương";
            // 
            // dtDecisionDate
            // 
            this.dtDecisionDate.EditValue = "";
            this.dtDecisionDate.Location = new System.Drawing.Point(94, 29);
            this.dtDecisionDate.MenuManager = this.barToolManager;
            this.dtDecisionDate.Name = "dtDecisionDate";
            this.dtDecisionDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtDecisionDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDecisionDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtDecisionDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDecisionDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDecisionDate.Properties.NullDate = "";
            this.dtDecisionDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDecisionDate.Size = new System.Drawing.Size(132, 20);
            this.dtDecisionDate.TabIndex = 1;
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecisionNo.Location = new System.Drawing.Point(266, 29);
            this.txtDecisionNo.MenuManager = this.barToolManager;
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.Size = new System.Drawing.Size(528, 20);
            this.txtDecisionNo.TabIndex = 3;
            // 
            // txtBudgetChapterName
            // 
            this.txtBudgetChapterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBudgetChapterName.Enabled = false;
            this.txtBudgetChapterName.Location = new System.Drawing.Point(232, 56);
            this.txtBudgetChapterName.MenuManager = this.barToolManager;
            this.txtBudgetChapterName.Name = "txtBudgetChapterName";
            this.txtBudgetChapterName.Size = new System.Drawing.Size(562, 20);
            this.txtBudgetChapterName.TabIndex = 6;
            // 
            // lookUpEditBudgetChapterCode
            // 
            this.lookUpEditBudgetChapterCode.EditValue = "";
            this.lookUpEditBudgetChapterCode.Location = new System.Drawing.Point(94, 56);
            this.lookUpEditBudgetChapterCode.MenuManager = this.barToolManager;
            this.lookUpEditBudgetChapterCode.Name = "lookUpEditBudgetChapterCode";
            this.lookUpEditBudgetChapterCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditBudgetChapterCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lookUpEditBudgetChapterCode.Properties.NullText = "";
            this.lookUpEditBudgetChapterCode.Properties.PopupSizeable = false;
            this.lookUpEditBudgetChapterCode.Properties.PopupWidth = 400;
            this.lookUpEditBudgetChapterCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditBudgetChapterCode.Size = new System.Drawing.Size(132, 20);
            this.lookUpEditBudgetChapterCode.TabIndex = 5;
            this.lookUpEditBudgetChapterCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUpEditBudgetChapterCode_ButtonClick);
            this.lookUpEditBudgetChapterCode.EditValueChanged += new System.EventHandler(this.lookUpEditBudgetChapterCode_EditValueChanged);
            this.lookUpEditBudgetChapterCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUpEditBudgetChapterCode_KeyDown);
            // 
            // FrmBUPlanCancelDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = BuCA.Enum.RefType.BUPlanCancel;
            this.ClientSize = new System.Drawing.Size(1008, 603);
            this.ComponentName = "Chứng từ hủy dự toán";
            this.EventTime = new System.DateTime(2019, 10, 17, 22, 46, 34, 468);
            this.FormCaption = "Chứng từ hủy dự toán";
            this.IsDisplayAccounting = true;
            this.Name = "FrmBUPlanCancelDetail";
            this.Reference = "THÊM CHỨNG TỪ HỦY DỰ TOÁN - SỐ CT: ";
            this.Text = "FrmBUPlanCancelDetail";
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            this.groupVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupObject)).EndInit();
            this.groupObject.ResumeLayout(false);
            this.groupObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageToolbar24Collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailByTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupGridDetailMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupUtility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccountingObjectCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDecisionDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDecisionDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetChapterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditBudgetChapterCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEditBudgetChapterCode;
        private DevExpress.XtraEditors.TextEdit txtBudgetChapterName;
        private DevExpress.XtraEditors.TextEdit txtDecisionNo;
        private DevExpress.XtraEditors.DateEdit dtDecisionDate;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}