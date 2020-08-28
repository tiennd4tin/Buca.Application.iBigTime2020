namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    partial class FrmBUPlanWithDrawTransferInsurranceDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBUPlanWithDrawTransferInsurranceDetail));
            this.rndCashWithDrawType = new DevExpress.XtraEditors.RadioGroup();
            this.groupboxMain = new DevExpress.XtraEditors.GroupControl();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.txtTargetProgramName = new DevExpress.XtraEditors.TextEdit();
            this.cboBankId = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboTargetProgramId = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAccountingObjectBankAccount = new DevExpress.XtraEditors.TextEdit();
            this.txtAccountingObjectBankName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cboBUCommitmentRequestId = new DevExpress.XtraEditors.LookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.rndCashWithDrawType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetProgramName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTargetProgramId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountingObjectBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountingObjectBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBUCommitmentRequestId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            // 
            // groupVoucher
            // 
            this.groupVoucher.Controls.Add(this.labelControl10);
            this.groupVoucher.Controls.Add(this.cboBUCommitmentRequestId);
            this.groupVoucher.Location = new System.Drawing.Point(801, 94);
            this.groupVoucher.Size = new System.Drawing.Size(188, 228);
            this.groupVoucher.TabIndex = 4;
            this.groupVoucher.Controls.SetChildIndex(this.cboBUCommitmentRequestId, 0);
            this.groupVoucher.Controls.SetChildIndex(this.labelControl1, 0);
            this.groupVoucher.Controls.SetChildIndex(this.labelControl2, 0);
            this.groupVoucher.Controls.SetChildIndex(this.labelControl3, 0);
            this.groupVoucher.Controls.SetChildIndex(this.txtRefNo, 0);
            this.groupVoucher.Controls.SetChildIndex(this.dtPostDate, 0);
            this.groupVoucher.Controls.SetChildIndex(this.dtRefDate, 0);
            this.groupVoucher.Controls.SetChildIndex(this.labelControl10, 0);
            // 
            // groupObject
            // 
            this.groupObject.Controls.Add(this.txtAccountingObjectBankName);
            this.groupObject.Controls.Add(this.txtAccountingObjectBankAccount);
            this.groupObject.Location = new System.Drawing.Point(12, 184);
            this.groupObject.Size = new System.Drawing.Size(783, 135);
            this.groupObject.TabIndex = 3;
            this.groupObject.Text = "Đơn vị nhận tiền";
            this.groupObject.Controls.SetChildIndex(this.lblAccountingObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.lbAccountingObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.lkAccountingObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAccountingObjectBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAccountingObjectBankName, 0);
            this.groupObject.Controls.SetChildIndex(this.cboProject, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControlProjectAuto, 0);
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            // 
            // imageToolbar24Collection
            // 
            this.imageToolbar24Collection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToolbar24Collection.ImageStream")));
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
            this.dtRefDate.Location = new System.Drawing.Point(62, 54);
            this.dtRefDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtRefDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtRefDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtRefDate.Size = new System.Drawing.Size(115, 20);
            this.dtRefDate.TabIndex = 5;
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(62, 29);
            this.dtPostDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPostDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPostDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtPostDate.Size = new System.Drawing.Size(115, 20);
            this.dtPostDate.TabIndex = 3;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(62, 80);
            this.txtRefNo.Size = new System.Drawing.Size(115, 20);
            this.txtRefNo.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 58);
            this.labelControl3.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 33);
            this.labelControl2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 84);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 109);
            this.labelControl8.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(80, 53);
            this.txtAddress.Size = new System.Drawing.Size(694, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 57);
            // 
            // cboObjectName
            // 
            this.cboObjectName.EditValue = "";
            this.cboObjectName.Location = new System.Drawing.Point(218, 27);
            this.cboObjectName.Size = new System.Drawing.Size(556, 20);
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(80, 27);
            this.cboObjectCode.Properties.PopupWidth = 450;
            this.cboObjectCode.Size = new System.Drawing.Size(132, 20);
            this.cboObjectCode.EditValueChanged += new System.EventHandler(this.cboObjectCode_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 30);
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Đơn vị nhận";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(98, 140);
            this.txtContactName.Size = new System.Drawing.Size(6, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 83);
            this.labelControl9.Size = new System.Drawing.Size(60, 13);
            this.labelControl9.TabIndex = 4;
            this.labelControl9.Text = "Tài khoản số";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(80, 105);
            this.txtDescription.Size = new System.Drawing.Size(694, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(98, 143);
            // 
            // tabAccounting
            // 
            this.tabAccounting.Size = new System.Drawing.Size(975, 151);
            // 
            // tabAccountingDetail
            // 
            this.tabAccountingDetail.Size = new System.Drawing.Size(975, 151);
            // 
            // tabTax
            // 
            this.tabTax.Size = new System.Drawing.Size(975, 151);
            // 
            // tabMain
            // 
            this.tabMain.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.False;
            this.tabMain.Location = new System.Drawing.Point(13, 391);
            this.tabMain.SelectedTabPage = this.tabAccounting;
            this.tabMain.Size = new System.Drawing.Size(977, 176);
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(114, 140);
            this.cboBank.Size = new System.Drawing.Size(10, 20);
            // 
            // tabInventoryItem
            // 
            this.tabInventoryItem.Size = new System.Drawing.Size(975, 151);
            // 
            // tabrevaluation
            // 
            this.tabrevaluation.Size = new System.Drawing.Size(975, 151);
            // 
            // cboProject
            // 
            // 
            // lkAccountingObjectCategory
            // 
            // 
            // rndCashWithDrawType
            // 
            this.rndCashWithDrawType.EditValue = "03";
            this.rndCashWithDrawType.Location = new System.Drawing.Point(9, 66);
            this.rndCashWithDrawType.MenuManager = this.barToolManager;
            this.rndCashWithDrawType.Name = "rndCashWithDrawType";
            this.rndCashWithDrawType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rndCashWithDrawType.Properties.Columns = 3;
            this.rndCashWithDrawType.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rndCashWithDrawType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("01", "Tạm ứng đã cấp dự toán (1)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("02", "Tạm ứng chưa cấp dự toán (2)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("04", "Thực chi (3)")});
            this.rndCashWithDrawType.Size = new System.Drawing.Size(564, 31);
            this.rndCashWithDrawType.TabIndex = 0;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.txtBankName);
            this.groupboxMain.Controls.Add(this.txtTargetProgramName);
            this.groupboxMain.Controls.Add(this.cboBankId);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.cboTargetProgramId);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.panel1);
            this.groupboxMain.Location = new System.Drawing.Point(12, 94);
            this.groupboxMain.Name = "groupboxMain";
            this.groupboxMain.Size = new System.Drawing.Size(783, 85);
            this.groupboxMain.TabIndex = 1;
            this.groupboxMain.Text = "Đơn vị trả tiền";
            // 
            // txtBankName
            // 
            this.txtBankName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBankName.EditValue = "";
            this.txtBankName.Location = new System.Drawing.Point(218, 52);
            this.txtBankName.MenuManager = this.barToolManager;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBankName.Properties.Appearance.Options.UseBackColor = true;
            this.txtBankName.Properties.ReadOnly = true;
            this.txtBankName.Size = new System.Drawing.Size(556, 20);
            this.txtBankName.TabIndex = 5;
            // 
            // txtTargetProgramName
            // 
            this.txtTargetProgramName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetProgramName.EditValue = "";
            this.txtTargetProgramName.Location = new System.Drawing.Point(218, 26);
            this.txtTargetProgramName.MenuManager = this.barToolManager;
            this.txtTargetProgramName.Name = "txtTargetProgramName";
            this.txtTargetProgramName.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTargetProgramName.Properties.Appearance.Options.UseBackColor = true;
            this.txtTargetProgramName.Properties.ReadOnly = true;
            this.txtTargetProgramName.Size = new System.Drawing.Size(556, 20);
            this.txtTargetProgramName.TabIndex = 2;
            // 
            // cboBankId
            // 
            this.cboBankId.EnterMoveNextControl = true;
            this.cboBankId.Location = new System.Drawing.Point(80, 52);
            this.cboBankId.MenuManager = this.barToolManager;
            this.cboBankId.Name = "cboBankId";
            this.cboBankId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboBankId.Properties.NullText = "";
            this.cboBankId.Properties.PopupWidth = 450;
            this.cboBankId.Size = new System.Drawing.Size(132, 20);
            this.cboBankId.TabIndex = 4;
            this.cboBankId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboBankId_ButtonClick);
            this.cboBankId.EditValueChanged += new System.EventHandler(this.cboBankId_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 56);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 13);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Tài khoản số";
            // 
            // cboTargetProgramId
            // 
            this.cboTargetProgramId.Location = new System.Drawing.Point(80, 26);
            this.cboTargetProgramId.MenuManager = this.barToolManager;
            this.cboTargetProgramId.Name = "cboTargetProgramId";
            this.cboTargetProgramId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboTargetProgramId.Properties.NullText = "";
            this.cboTargetProgramId.Properties.PopupWidth = 450;
            this.cboTargetProgramId.Size = new System.Drawing.Size(132, 20);
            this.cboTargetProgramId.TabIndex = 1;
            this.cboTargetProgramId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboTargetProgramId_ButtonClick);
            this.cboTargetProgramId.EditValueChanged += new System.EventHandler(this.cboTargetProgramId_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "CTMT";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(110, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 227);
            this.panel1.TabIndex = 25;
            // 
            // txtAccountingObjectBankAccount
            // 
            this.txtAccountingObjectBankAccount.Location = new System.Drawing.Point(80, 79);
            this.txtAccountingObjectBankAccount.MenuManager = this.barToolManager;
            this.txtAccountingObjectBankAccount.Name = "txtAccountingObjectBankAccount";
            this.txtAccountingObjectBankAccount.Size = new System.Drawing.Size(132, 20);
            this.txtAccountingObjectBankAccount.TabIndex = 5;
            // 
            // txtAccountingObjectBankName
            // 
            this.txtAccountingObjectBankName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountingObjectBankName.Location = new System.Drawing.Point(218, 79);
            this.txtAccountingObjectBankName.MenuManager = this.barToolManager;
            this.txtAccountingObjectBankName.Name = "txtAccountingObjectBankName";
            this.txtAccountingObjectBankName.Size = new System.Drawing.Size(556, 20);
            this.txtAccountingObjectBankName.TabIndex = 12;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(14, 110);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(35, 13);
            this.labelControl10.TabIndex = 6;
            this.labelControl10.Text = "Số CKC";
            // 
            // cboBUCommitmentRequestId
            // 
            this.cboBUCommitmentRequestId.Location = new System.Drawing.Point(62, 106);
            this.cboBUCommitmentRequestId.MenuManager = this.barToolManager;
            this.cboBUCommitmentRequestId.Name = "cboBUCommitmentRequestId";
            this.cboBUCommitmentRequestId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBUCommitmentRequestId.Properties.NullText = "";
            this.cboBUCommitmentRequestId.Properties.PopupSizeable = false;
            this.cboBUCommitmentRequestId.Properties.PopupWidth = 360;
            this.cboBUCommitmentRequestId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboBUCommitmentRequestId.Size = new System.Drawing.Size(115, 20);
            this.cboBUCommitmentRequestId.TabIndex = 6;
            // 
            // FrmBUPlanWithDrawTransferInsurranceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = BuCA.Enum.RefType.BUPlanWithDrawTransfer;
            this.ClientSize = new System.Drawing.Size(1002, 597);
            this.ComponentName = "Rút dự toán chuyển lương, bảo hiểm";
            this.Controls.Add(this.groupboxMain);
            this.Controls.Add(this.rndCashWithDrawType);
            this.EventTime = new System.DateTime(2019, 10, 17, 15, 47, 49, 834);
            this.FormCaption = "Rút dự toán chuyển lương, bảo hiểm";
            this.IsDisplayAccounting = true;
            this.Name = "FrmBUPlanWithDrawTransferInsurranceDetail";
            this.Reference = "THÊM RÚT DỰ TOÁN CHUYỂN LƯƠNG, BẢO HIỂM - SỐ CT: ";
            this.Text = "FrmBUPlanWithDrawTransferDetail";
            this.Load += new System.EventHandler(this.FrmBUPlanWithDrawTransferInsurranceDetail_Load);
            this.Resize += new System.EventHandler(this.FrmBUPlanWithDrawTransferInsurranceDetail_Resize);
            this.Controls.SetChildIndex(this.rndCashWithDrawType, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupObject, 0);
            this.Controls.SetChildIndex(this.groupVoucher, 0);
            this.Controls.SetChildIndex(this.tabMain, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.rndCashWithDrawType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetProgramName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTargetProgramId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountingObjectBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountingObjectBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBUCommitmentRequestId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup rndCashWithDrawType;
        public DevExpress.XtraEditors.GroupControl groupboxMain;
        protected DevExpress.XtraEditors.LookUpEdit cboBankId;
        protected DevExpress.XtraEditors.LabelControl labelControl6;
        protected DevExpress.XtraEditors.LookUpEdit cboTargetProgramId;
        protected DevExpress.XtraEditors.LabelControl labelControl4;
        protected DevExpress.XtraEditors.TextEdit txtBankName;
        protected DevExpress.XtraEditors.TextEdit txtTargetProgramName;
        protected DevExpress.XtraEditors.TextEdit txtAccountingObjectBankName;
        protected DevExpress.XtraEditors.TextEdit txtAccountingObjectBankAccount;
        protected DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LookUpEdit cboBUCommitmentRequestId;
        private System.Windows.Forms.Panel panel1;
    }
}