using DevExpress.XtraGrid.Views.Base;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    partial class FrmBUCommitmentAdjustmentDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBUCommitmentAdjustmentDetail));
            this.bandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.checkIncurredCurrency = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.btnChooseBUCommitment = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.CheckIsSuggestAdjustment = new DevExpress.XtraEditors.CheckEdit();
            this.CheckIsSuggestSupplement = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.cbObjectBank = new DevExpress.XtraEditors.LookUpEdit();
            this.LookUpEditContract = new DevExpress.XtraEditors.LookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIncurredCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseBUCommitment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckIsSuggestAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckIsSuggestSupplement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbObjectBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditContract.Properties)).BeginInit();
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
            this.groupVoucher.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupVoucher.AppearanceCaption.Options.UseFont = true;
            this.groupVoucher.Location = new System.Drawing.Point(793, 79);
            this.groupVoucher.Size = new System.Drawing.Size(211, 161);
            this.groupVoucher.TabIndex = 2;
            // 
            // groupObject
            // 
            this.groupObject.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupObject.AppearanceCaption.Options.UseFont = true;
            this.groupObject.Controls.Add(this.cbObjectBank);
            this.groupObject.Controls.Add(this.txtBankName);
            this.groupObject.Controls.Add(this.labelControl14);
            this.groupObject.Controls.Add(this.labelControl13);
            this.groupObject.Controls.Add(this.CheckIsSuggestSupplement);
            this.groupObject.Controls.Add(this.CheckIsSuggestAdjustment);
            this.groupObject.Controls.Add(this.labelControl11);
            this.groupObject.Controls.Add(this.labelControl10);
            this.groupObject.Controls.Add(this.labelControl6);
            this.groupObject.Controls.Add(this.labelControl4);
            this.groupObject.Controls.Add(this.labelControl15);
            this.groupObject.Controls.Add(this.labelControl12);
            this.groupObject.Controls.Add(this.btnChooseBUCommitment);
            this.groupObject.Controls.Add(this.LookUpEditContract);
            this.groupObject.Location = new System.Drawing.Point(6, 79);
            this.groupObject.Size = new System.Drawing.Size(781, 161);
            this.groupObject.Controls.SetChildIndex(this.LookUpEditContract, 0);
            this.groupObject.Controls.SetChildIndex(this.lbAccountingObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.lkAccountingObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.lblAccountingObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.cboProject, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControlProjectAuto, 0);
            this.groupObject.Controls.SetChildIndex(this.btnChooseBUCommitment, 0);
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl12, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl15, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl4, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl6, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl10, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl11, 0);
            this.groupObject.Controls.SetChildIndex(this.CheckIsSuggestAdjustment, 0);
            this.groupObject.Controls.SetChildIndex(this.CheckIsSuggestSupplement, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl13, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl14, 0);
            this.groupObject.Controls.SetChildIndex(this.txtBankName, 0);
            this.groupObject.Controls.SetChildIndex(this.cbObjectBank, 0);
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
            this.dtRefDate.Location = new System.Drawing.Point(116, 79);
            this.dtRefDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtRefDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtRefDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtRefDate.Size = new System.Drawing.Size(89, 20);
            this.dtRefDate.TabIndex = 11;
            this.dtRefDate.Visible = false;
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(116, 53);
            this.dtPostDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPostDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPostDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtPostDate.Size = new System.Drawing.Size(89, 20);
            this.dtPostDate.TabIndex = 10;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(116, 27);
            this.txtRefNo.Size = new System.Drawing.Size(89, 20);
            this.txtRefNo.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 82);
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.Text = "Ngày KBNN ghi sổ";
            this.labelControl3.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 57);
            this.labelControl2.Size = new System.Drawing.Size(104, 13);
            this.labelControl2.Text = "Ngày đề nghị ĐC CKC";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 30);
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.Text = "Số phiếu điều chỉnh";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(6, 170);
            this.labelControl8.Visible = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(403, 200);
            this.txtAddress.Size = new System.Drawing.Size(7, 20);
            this.txtAddress.TabStop = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(313, 207);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(482, 200);
            this.cboObjectName.Size = new System.Drawing.Size(12, 20);
            this.cboObjectName.TabStop = false;
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(382, 200);
            this.cboObjectCode.Size = new System.Drawing.Size(15, 20);
            this.cboObjectCode.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(226, 207);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(428, 200);
            this.txtContactName.Size = new System.Drawing.Size(3, 20);
            this.txtContactName.TabStop = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(42, 207);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(90, 167);
            this.txtDescription.Size = new System.Drawing.Size(686, 20);
            this.txtDescription.TabStop = false;
            this.txtDescription.Visible = false;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(132, 207);
            // 
            // tabAccounting
            // 
            this.tabAccounting.Size = new System.Drawing.Size(996, 243);
            // 
            // tabAccountingDetail
            // 
            this.tabAccountingDetail.Size = new System.Drawing.Size(992, 240);
            // 
            // tabTax
            // 
            this.tabTax.Size = new System.Drawing.Size(992, 240);
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(6, 305);
            this.tabMain.SelectedTabPage = this.tabAccounting;
            this.tabMain.Size = new System.Drawing.Size(998, 268);
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(17, 200);
            this.cboBank.Size = new System.Drawing.Size(19, 20);
            this.cboBank.TabStop = false;
            // 
            // tabInventoryItem
            // 
            this.tabInventoryItem.Size = new System.Drawing.Size(992, 240);
            // 
            // tabrevaluation
            // 
            this.tabrevaluation.Size = new System.Drawing.Size(992, 240);
            // 
            // cboProject
            // 
            // 
            // lkAccountingObjectCategory
            // 
            // 
            // lblAccountingObjectName
            // 
            this.lblAccountingObjectName.Visible = false;
            // 
            // bandedGridView
            // 
            this.bandedGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.bandedGridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.bandedGridView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.bandedGridView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bandedGridView.FixedLineWidth = 1;
            this.bandedGridView.GridControl = this.grdAccounting;
            this.bandedGridView.Name = "bandedGridView";
            this.bandedGridView.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.bandedGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.bandedGridView.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.bandedGridView.OptionsView.ShowGroupPanel = false;
            this.bandedGridView.OptionsView.ShowIndicator = false;
            this.bandedGridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.bandedGridView_InitNewRow);
            this.bandedGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.bandedGridView_CellValueChanged);
            // 
            // checkIncurredCurrency
            // 
            this.checkIncurredCurrency.EditValue = "";
            this.checkIncurredCurrency.Location = new System.Drawing.Point(5, 59);
            this.checkIncurredCurrency.MenuManager = this.barToolManager;
            this.checkIncurredCurrency.Name = "checkIncurredCurrency";
            this.checkIncurredCurrency.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkIncurredCurrency.Properties.Caption = "Có phát sinh ngoại tệ";
            this.checkIncurredCurrency.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.checkIncurredCurrency.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.checkIncurredCurrency.Size = new System.Drawing.Size(126, 19);
            this.checkIncurredCurrency.TabIndex = 1;
            this.checkIncurredCurrency.Visible = false;
            this.checkIncurredCurrency.CheckedChanged += new System.EventHandler(this.checkIncurredCurrency_CheckedChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(9, 30);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(103, 13);
            this.labelControl12.TabIndex = 25;
            this.labelControl12.Text = "Số điều chỉnh CKC (*)";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(9, 57);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(94, 13);
            this.labelControl15.TabIndex = 31;
            this.labelControl15.Text = "Hợp đồng thực hiện";
            // 
            // btnChooseBUCommitment
            // 
            this.btnChooseBUCommitment.Location = new System.Drawing.Point(117, 27);
            this.btnChooseBUCommitment.MenuManager = this.barToolManager;
            this.btnChooseBUCommitment.Name = "btnChooseBUCommitment";
            this.btnChooseBUCommitment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnChooseBUCommitment.Size = new System.Drawing.Size(273, 20);
            this.btnChooseBUCommitment.TabIndex = 1;
            this.btnChooseBUCommitment.Click += new System.EventHandler(this.btnChooseBUCommitment_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 5F);
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.LineColor = System.Drawing.Color.Black;
            this.labelControl4.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl4.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(11, 72);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(94, 26);
            this.labelControl4.TabIndex = 43;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(117, 84);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(111, 13);
            this.labelControl6.TabIndex = 44;
            this.labelControl6.Text = "Thông tin đã hạch toán";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 5F);
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl10.LineColor = System.Drawing.Color.Black;
            this.labelControl10.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl10.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl10.LineVisible = true;
            this.labelControl10.Location = new System.Drawing.Point(235, 75);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(152, 18);
            this.labelControl10.TabIndex = 45;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(396, 84);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(83, 13);
            this.labelControl11.TabIndex = 46;
            this.labelControl11.Text = "Thông tin đề nghị";
            // 
            // CheckIsSuggestAdjustment
            // 
            this.CheckIsSuggestAdjustment.EditValue = "";
            this.CheckIsSuggestAdjustment.Location = new System.Drawing.Point(493, 82);
            this.CheckIsSuggestAdjustment.MenuManager = this.barToolManager;
            this.CheckIsSuggestAdjustment.Name = "CheckIsSuggestAdjustment";
            this.CheckIsSuggestAdjustment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.CheckIsSuggestAdjustment.Properties.Caption = "Điều chỉnh";
            this.CheckIsSuggestAdjustment.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.CheckIsSuggestAdjustment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CheckIsSuggestAdjustment.Size = new System.Drawing.Size(75, 19);
            this.CheckIsSuggestAdjustment.TabIndex = 3;
            // 
            // CheckIsSuggestSupplement
            // 
            this.CheckIsSuggestSupplement.EditValue = "";
            this.CheckIsSuggestSupplement.Location = new System.Drawing.Point(578, 82);
            this.CheckIsSuggestSupplement.MenuManager = this.barToolManager;
            this.CheckIsSuggestSupplement.Name = "CheckIsSuggestSupplement";
            this.CheckIsSuggestSupplement.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.CheckIsSuggestSupplement.Properties.Caption = "Bổ sung";
            this.CheckIsSuggestSupplement.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.CheckIsSuggestSupplement.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CheckIsSuggestSupplement.Size = new System.Drawing.Size(75, 19);
            this.CheckIsSuggestSupplement.TabIndex = 4;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(9, 109);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(70, 13);
            this.labelControl13.TabIndex = 49;
            this.labelControl13.Text = "Tài khoản NCC";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(9, 136);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(96, 13);
            this.labelControl14.TabIndex = 51;
            this.labelControl14.Text = "Tên ngân hàng NCC";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(117, 133);
            this.txtBankName.MenuManager = this.barToolManager;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(273, 20);
            this.txtBankName.TabIndex = 7;
            // 
            // cbObjectBank
            // 
            this.cbObjectBank.Location = new System.Drawing.Point(117, 106);
            this.cbObjectBank.MenuManager = this.barToolManager;
            this.cbObjectBank.Name = "cbObjectBank";
            this.cbObjectBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cbObjectBank.Properties.NullText = "";
            this.cbObjectBank.Properties.PopupWidth = 450;
            this.cbObjectBank.Size = new System.Drawing.Size(273, 20);
            this.cbObjectBank.TabIndex = 52;
            this.cbObjectBank.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cbObjectBank_ButtonClick);
            this.cbObjectBank.EditValueChanged += new System.EventHandler(this.cboObjectBank_EditValueChanged);
            // 
            // LookUpEditContract
            // 
            this.LookUpEditContract.Location = new System.Drawing.Point(117, 54);
            this.LookUpEditContract.MenuManager = this.barToolManager;
            this.LookUpEditContract.Name = "LookUpEditContract";
            this.LookUpEditContract.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditContract.Properties.NullText = "";
            this.LookUpEditContract.Size = new System.Drawing.Size(273, 20);
            this.LookUpEditContract.TabIndex = 2;
            // 
            // FrmBUCommitmentAdjustmentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = BuCA.Enum.RefType.BUCommitmentAdjustment;
            this.ClientSize = new System.Drawing.Size(1013, 603);
            this.ComponentName = "Điều chỉnh cam kết chi";
            this.Controls.Add(this.checkIncurredCurrency);
            this.EventTime = new System.DateTime(2020, 8, 21, 16, 20, 4, 791);
            this.FormCaption = "Điều chỉnh cam kết chi";
            this.IsDisplayAccounting = true;
            this.Name = "FrmBUCommitmentAdjustmentDetail";
            this.Reference = "THÊM ĐIỀU CHỈNH CAM KẾT CHI - SỐ CT: ";
            this.RefTypeUsingDisplayReport = BuCA.Enum.RefType.BUCommitmentAdjustment;
            this.Text = "Điều chỉnh cam kết chi";
            this.Load += new System.EventHandler(this.FrmBUCommitmentAdjustmentDetail_Load);
            this.Controls.SetChildIndex(this.checkIncurredCurrency, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIncurredCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseBUCommitment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckIsSuggestAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckIsSuggestSupplement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbObjectBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditContract.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void BandedGridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private DevExpress.XtraEditors.CheckEdit checkIncurredCurrency;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl15;

        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView;
        private DevExpress.XtraEditors.ButtonEdit btnChooseBUCommitment;
        private DevExpress.XtraEditors.CheckEdit CheckIsSuggestSupplement;
        private DevExpress.XtraEditors.CheckEdit CheckIsSuggestAdjustment;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        protected DevExpress.XtraEditors.LookUpEdit cbObjectBank;
        private DevExpress.XtraEditors.LookUpEdit LookUpEditContract;
    }
}