﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Tool
{
    partial class FrmToolDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtInventoryItemCode = new DevExpress.XtraEditors.TextEdit();
            this.txtInventoryItemName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.calcUnitPrice = new DevExpress.XtraEditors.CalcEdit();
            this.calcSalePrice = new DevExpress.XtraEditors.CalcEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.txtMadeIn = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTaxable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTaxRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtConvertUnit = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.chkIsService = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboInventoryAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDefaultStockId = new DevExpress.XtraEditors.LookUpEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboSaleAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.cboCOGSAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.calcConvertRate = new DevExpress.XtraEditors.CalcEdit();
            this.cboInventoryCategoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.cboAccountingObjectId = new DevExpress.XtraEditors.LookUpEdit();
            this.rndIsStock = new DevExpress.XtraEditors.RadioGroup();
            this.lookUpDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventoryItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventoryItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSalePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMadeIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTaxable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTaxRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvertUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultStockId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCOGSAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcConvertRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryCategoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountingObjectId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndIsStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(341, 289);
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(421, 289);
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 289);
            this.btnHelp.Size = new System.Drawing.Size(75, 27);
            this.btnHelp.TabIndex = 5;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.txtConvertUnit);
            this.groupboxMain.Controls.Add(this.label11);
            this.groupboxMain.Controls.Add(this.label12);
            this.groupboxMain.Controls.Add(this.cboTaxRate);
            this.groupboxMain.Controls.Add(this.label10);
            this.groupboxMain.Controls.Add(this.label9);
            this.groupboxMain.Controls.Add(this.txtMadeIn);
            this.groupboxMain.Controls.Add(this.label8);
            this.groupboxMain.Controls.Add(this.txtUnit);
            this.groupboxMain.Controls.Add(this.label7);
            this.groupboxMain.Controls.Add(this.label6);
            this.groupboxMain.Controls.Add(this.calcSalePrice);
            this.groupboxMain.Controls.Add(this.label5);
            this.groupboxMain.Controls.Add(this.label4);
            this.groupboxMain.Controls.Add(this.label3);
            this.groupboxMain.Controls.Add(this.txtInventoryItemName);
            this.groupboxMain.Controls.Add(this.label2);
            this.groupboxMain.Controls.Add(this.txtInventoryItemCode);
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Controls.Add(this.calcUnitPrice);
            this.groupboxMain.Controls.Add(this.cboTaxable);
            this.groupboxMain.Controls.Add(this.calcConvertRate);
            this.groupboxMain.Controls.Add(this.rndIsStock);
            this.groupboxMain.Controls.Add(this.label15);
            this.groupboxMain.Controls.Add(this.cboCOGSAccount);
            this.groupboxMain.Controls.Add(this.cboSaleAccount);
            this.groupboxMain.Controls.Add(this.label16);
            this.groupboxMain.Controls.Add(this.label17);
            this.groupboxMain.Controls.Add(this.lookUpDepartment);
            this.groupboxMain.Controls.Add(this.cboAccountingObjectId);
            this.groupboxMain.Controls.Add(this.chkIsService);
            this.groupboxMain.Controls.Add(this.cboInventoryCategoryId);
            this.groupboxMain.Location = new System.Drawing.Point(8, 12);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(488, 169);
            this.groupboxMain.Text = "&Thông tin chung";
            // 
            // btnPrintFixAsset
            // 
            this.btnPrintFixAsset.Location = new System.Drawing.Point(84, 58);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã công cụ, dụng cụ (*)";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(6, 264);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 2;
            // 
            // txtInventoryItemCode
            // 
            this.txtInventoryItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryItemCode.Location = new System.Drawing.Point(140, 25);
            this.txtInventoryItemCode.Name = "txtInventoryItemCode";
            this.txtInventoryItemCode.Size = new System.Drawing.Size(146, 20);
            this.txtInventoryItemCode.TabIndex = 1;
            // 
            // txtInventoryItemName
            // 
            this.txtInventoryItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryItemName.Location = new System.Drawing.Point(140, 51);
            this.txtInventoryItemName.Name = "txtInventoryItemName";
            this.txtInventoryItemName.Size = new System.Drawing.Size(342, 20);
            this.txtInventoryItemName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên công cụ, dụng cụ (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loại công cụ, dụng cụ (*)";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đơn giá mua";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Đơn giá bán";
            this.label5.Visible = false;
            // 
            // calcUnitPrice
            // 
            this.calcUnitPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.calcUnitPrice.Location = new System.Drawing.Point(226, 120);
            this.calcUnitPrice.Name = "calcUnitPrice";
            this.calcUnitPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcUnitPrice.Properties.Mask.BeepOnError = true;
            this.calcUnitPrice.Properties.Mask.EditMask = "n0";
            this.calcUnitPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.calcUnitPrice.Size = new System.Drawing.Size(137, 20);
            this.calcUnitPrice.TabIndex = 10;
            this.calcUnitPrice.Tag = "";
            this.calcUnitPrice.Visible = false;
            // 
            // calcSalePrice
            // 
            this.calcSalePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcSalePrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.calcSalePrice.Location = new System.Drawing.Point(245, 120);
            this.calcSalePrice.Name = "calcSalePrice";
            this.calcSalePrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcSalePrice.Properties.Mask.BeepOnError = true;
            this.calcSalePrice.Properties.Mask.EditMask = "n0";
            this.calcSalePrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.calcSalePrice.Size = new System.Drawing.Size(125, 20);
            this.calcSalePrice.TabIndex = 12;
            this.calcSalePrice.Tag = "";
            this.calcSalePrice.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nhà cung cấp";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Đơn vị tính";
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnit.Location = new System.Drawing.Point(140, 77);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(124, 20);
            this.txtUnit.TabIndex = 18;
            // 
            // txtMadeIn
            // 
            this.txtMadeIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMadeIn.Location = new System.Drawing.Point(226, 129);
            this.txtMadeIn.Name = "txtMadeIn";
            this.txtMadeIn.Size = new System.Drawing.Size(145, 20);
            this.txtMadeIn.TabIndex = 16;
            this.txtMadeIn.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Hãng sản xuất";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Thuộc diện";
            this.label9.Visible = false;
            // 
            // cboTaxable
            // 
            this.cboTaxable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTaxable.EditValue = "Chịu thuế";
            this.cboTaxable.Location = new System.Drawing.Point(203, 124);
            this.cboTaxable.Name = "cboTaxable";
            this.cboTaxable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTaxable.Properties.Items.AddRange(new object[] {
            "Chịu thuế",
            "Không chịu thuế"});
            this.cboTaxable.Size = new System.Drawing.Size(145, 20);
            this.cboTaxable.TabIndex = 20;
            this.cboTaxable.Visible = false;
            this.cboTaxable.SelectedIndexChanged += new System.EventHandler(this.cboTaxable_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Thuế suất";
            this.label10.Visible = false;
            // 
            // cboTaxRate
            // 
            this.cboTaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTaxRate.EditValue = "0%";
            this.cboTaxRate.Location = new System.Drawing.Point(266, 124);
            this.cboTaxRate.Name = "cboTaxRate";
            this.cboTaxRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTaxRate.Properties.Items.AddRange(new object[] {
            "0%",
            "5%",
            "10%"});
            this.cboTaxRate.Size = new System.Drawing.Size(124, 20);
            this.cboTaxRate.TabIndex = 22;
            this.cboTaxRate.Visible = false;
            // 
            // txtConvertUnit
            // 
            this.txtConvertUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertUnit.Location = new System.Drawing.Point(226, 124);
            this.txtConvertUnit.Name = "txtConvertUnit";
            this.txtConvertUnit.Size = new System.Drawing.Size(145, 20);
            this.txtConvertUnit.TabIndex = 24;
            this.txtConvertUnit.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Đơn vị quy đổi";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(263, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Tỷ lệ quy đổi";
            this.label12.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 117);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "Diễn giải";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(140, 104);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(336, 52);
            this.txtDescription.TabIndex = 28;
            // 
            // chkIsService
            // 
            this.chkIsService.EditValue = true;
            this.chkIsService.Location = new System.Drawing.Point(180, 125);
            this.chkIsService.Name = "chkIsService";
            this.chkIsService.Properties.Caption = "Là dịch vụ";
            this.chkIsService.Size = new System.Drawing.Size(96, 19);
            this.chkIsService.TabIndex = 29;
            this.chkIsService.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.cboInventoryAccount);
            this.groupControl1.Controls.Add(this.cboDefaultStockId);
            this.groupControl1.Controls.Add(this.label14);
            this.groupControl1.Controls.Add(this.label13);
            this.groupControl1.Location = new System.Drawing.Point(8, 195);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(488, 63);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thông tin ngầm định";
            // 
            // cboInventoryAccount
            // 
            this.cboInventoryAccount.EditValue = true;
            this.cboInventoryAccount.Location = new System.Drawing.Point(332, 28);
            this.cboInventoryAccount.Name = "cboInventoryAccount";
            this.cboInventoryAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboInventoryAccount.Properties.DisplayMember = "AccountNumber";
            this.cboInventoryAccount.Properties.NullText = "";
            this.cboInventoryAccount.Properties.PopupWidth = 350;
            this.cboInventoryAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboInventoryAccount.Properties.ValueMember = "AccountNumber";
            this.cboInventoryAccount.Size = new System.Drawing.Size(143, 20);
            this.cboInventoryAccount.TabIndex = 5;
            this.cboInventoryAccount.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboInventoryAccount_ButtonClick);
            // 
            // cboDefaultStockId
            // 
            this.cboDefaultStockId.EditValue = true;
            this.cboDefaultStockId.Location = new System.Drawing.Point(92, 28);
            this.cboDefaultStockId.Name = "cboDefaultStockId";
            this.cboDefaultStockId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboDefaultStockId.Properties.NullText = "";
            this.cboDefaultStockId.Properties.PopupWidth = 350;
            this.cboDefaultStockId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDefaultStockId.Size = new System.Drawing.Size(143, 20);
            this.cboDefaultStockId.TabIndex = 1;
            this.cboDefaultStockId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboDefaultStockId_ButtonClick);
            this.cboDefaultStockId.EditValueChanged += new System.EventHandler(this.cboDefaultStockId_EditValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(249, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Tài khoản kho";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Kho ngầm định";
            // 
            // cboSaleAccount
            // 
            this.cboSaleAccount.EditValue = true;
            this.cboSaleAccount.Location = new System.Drawing.Point(226, 124);
            this.cboSaleAccount.Name = "cboSaleAccount";
            this.cboSaleAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboSaleAccount.Properties.DisplayMember = "AccountNumber";
            this.cboSaleAccount.Properties.NullText = "";
            this.cboSaleAccount.Properties.PopupWidth = 350;
            this.cboSaleAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboSaleAccount.Properties.ValueMember = "AccountNumber";
            this.cboSaleAccount.Size = new System.Drawing.Size(160, 20);
            this.cboSaleAccount.TabIndex = 7;
            this.cboSaleAccount.Visible = false;
            this.cboSaleAccount.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboSaleAccount_ButtonClick);
            // 
            // cboCOGSAccount
            // 
            this.cboCOGSAccount.EditValue = true;
            this.cboCOGSAccount.Location = new System.Drawing.Point(242, 120);
            this.cboCOGSAccount.Name = "cboCOGSAccount";
            this.cboCOGSAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboCOGSAccount.Properties.DisplayMember = "AccountNumber";
            this.cboCOGSAccount.Properties.NullText = "";
            this.cboCOGSAccount.Properties.PopupWidth = 350;
            this.cboCOGSAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCOGSAccount.Properties.ValueMember = "AccountNumber";
            this.cboCOGSAccount.Size = new System.Drawing.Size(160, 20);
            this.cboCOGSAccount.TabIndex = 3;
            this.cboCOGSAccount.Visible = false;
            this.cboCOGSAccount.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboCOGSAccount_ButtonClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(260, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "TK doanh thu";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(242, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "TK chi phí";
            this.label15.Visible = false;
            // 
            // calcConvertRate
            // 
            this.calcConvertRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcConvertRate.Location = new System.Drawing.Point(242, 120);
            this.calcConvertRate.Name = "calcConvertRate";
            this.calcConvertRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcConvertRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.calcConvertRate.Size = new System.Drawing.Size(124, 20);
            this.calcConvertRate.TabIndex = 26;
            this.calcConvertRate.Tag = "Rate";
            this.calcConvertRate.Visible = false;
            // 
            // cboInventoryCategoryId
            // 
            this.cboInventoryCategoryId.EditValue = true;
            this.cboInventoryCategoryId.Location = new System.Drawing.Point(139, 120);
            this.cboInventoryCategoryId.Name = "cboInventoryCategoryId";
            this.cboInventoryCategoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboInventoryCategoryId.Properties.NullText = "";
            this.cboInventoryCategoryId.Properties.PopupWidth = 330;
            this.cboInventoryCategoryId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboInventoryCategoryId.Size = new System.Drawing.Size(334, 20);
            this.cboInventoryCategoryId.TabIndex = 6;
            this.cboInventoryCategoryId.Visible = false;
            // 
            // cboAccountingObjectId
            // 
            this.cboAccountingObjectId.Location = new System.Drawing.Point(141, 120);
            this.cboAccountingObjectId.Name = "cboAccountingObjectId";
            this.cboAccountingObjectId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboAccountingObjectId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboAccountingObjectId.Properties.NullText = "";
            this.cboAccountingObjectId.Properties.PopupWidth = 330;
            this.cboAccountingObjectId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboAccountingObjectId.Size = new System.Drawing.Size(333, 20);
            this.cboAccountingObjectId.TabIndex = 14;
            this.cboAccountingObjectId.Visible = false;
            this.cboAccountingObjectId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboAccountingObjectId_ButtonClick);
            // 
            // rndIsStock
            // 
            this.rndIsStock.EditValue = "03";
            this.rndIsStock.Location = new System.Drawing.Point(245, 119);
            this.rndIsStock.Name = "rndIsStock";
            this.rndIsStock.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rndIsStock.Properties.Columns = 3;
            this.rndIsStock.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rndIsStock.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Qua kho"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Không qua kho")});
            this.rndIsStock.Size = new System.Drawing.Size(186, 21);
            this.rndIsStock.TabIndex = 2;
            this.rndIsStock.Visible = false;
            this.rndIsStock.SelectedIndexChanged += new System.EventHandler(this.rndCashWithDrawType_SelectedIndexChanged);
            // 
            // lookUpDepartment
            // 
            this.lookUpDepartment.EditValue = true;
            this.lookUpDepartment.Location = new System.Drawing.Point(141, 124);
            this.lookUpDepartment.Name = "lookUpDepartment";
            this.lookUpDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDepartment.Properties.NullText = "";
            this.lookUpDepartment.Properties.PopupWidth = 350;
            this.lookUpDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpDepartment.Size = new System.Drawing.Size(334, 20);
            this.lookUpDepartment.TabIndex = 8;
            this.lookUpDepartment.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(221, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Phòng ban";
            this.label17.Visible = false;
            // 
            // FrmToolDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 325);
            this.ComponentName = "Công cụ, dụng cụ";
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2020, 5, 6, 19, 48, 25, 484);
            this.FormCaption = "Công cụ, dụng cụ";
            this.Name = "FrmToolDetail";
            this.Reference = "THÊM CÔNG CỤ, DỤNG CỤ - ID ";
            this.TableCode = "InventoryItem";
            this.Text = "FrmXtraToolDetail";
            this.Load += new System.EventHandler(this.FrmXtraToolDetail_Load);
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventoryItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventoryItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSalePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMadeIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTaxable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTaxRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvertUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultStockId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSaleAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCOGSAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcConvertRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInventoryCategoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountingObjectId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndIsStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartment.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private System.Windows.Forms.Label label3;
        protected DevExpress.XtraEditors.TextEdit txtInventoryItemName;
        private System.Windows.Forms.Label label2;
        protected DevExpress.XtraEditors.TextEdit txtInventoryItemCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.CalcEdit calcUnitPrice;
        private DevExpress.XtraEditors.CalcEdit calcSalePrice;
        protected DevExpress.XtraEditors.TextEdit txtUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        protected DevExpress.XtraEditors.TextEdit txtMadeIn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        protected DevExpress.XtraEditors.TextEdit txtConvertUnit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.ComboBoxEdit cboTaxRate;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.ComboBoxEdit cboTaxable;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.CheckEdit chkIsService;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.CalcEdit calcConvertRate;
        private DevExpress.XtraEditors.LookUpEdit cboDefaultStockId;
        private DevExpress.XtraEditors.LookUpEdit cboInventoryAccount;
        private DevExpress.XtraEditors.LookUpEdit cboSaleAccount;
        private DevExpress.XtraEditors.LookUpEdit cboCOGSAccount;
        private DevExpress.XtraEditors.LookUpEdit cboInventoryCategoryId;
        private DevExpress.XtraEditors.LookUpEdit lookUpDepartment;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraEditors.RadioGroup rndIsStock;
        public DevExpress.XtraEditors.LookUpEdit cboAccountingObjectId;
    }
}