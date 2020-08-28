namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountTransfer
{
    partial class FrmAccountTransferDetail
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
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboBusinessType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpEditToAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.spinTransferOrder = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountTransferCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpEditReferentAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.grdLookUpEditFromAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTransferSide = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.grdLookUpEditBudgetSource = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusinessType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditToAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTransferOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTransferCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditReferentAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditFromAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferSide.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditBudgetSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(279, 279);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(351, 279);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 279);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.labelControl16);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl8);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.grdLookUpEditToAccount);
            this.groupboxMain.Controls.Add(this.spinTransferOrder);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.grdLookUpEditBudgetSource);
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.grdLookUpEditFromAccount);
            this.groupboxMain.Controls.Add(this.grdLookUpEditReferentAccount);
            this.groupboxMain.Controls.Add(this.cboTransferSide);
            this.groupboxMain.Controls.Add(this.cboBusinessType);
            this.groupboxMain.Controls.Add(this.txtAccountTransferCode);
            this.groupboxMain.Size = new System.Drawing.Size(412, 239);
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(99, 152);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(304, 80);
            this.memoDescription.TabIndex = 17;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(7, 187);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(40, 13);
            this.labelControl16.TabIndex = 16;
            this.labelControl16.Text = "&Diễn giải";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "&Loại kết chuyển";
            // 
            // cboBusinessType
            // 
            this.cboBusinessType.EditValue = "";
            this.cboBusinessType.Location = new System.Drawing.Point(99, 56);
            this.cboBusinessType.Name = "cboBusinessType";
            this.cboBusinessType.Properties.AutoHeight = false;
            this.cboBusinessType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBusinessType.Properties.Items.AddRange(new object[] {
            "Kết chuyển TK dự toán chi ĐTXDCB",// 0
            "Xác định kết quả hoạt động",// 1
            "Kết chuyển chi phí XDCB chờ quyết toán ", // 2
            "Quyết toán dự án hoàn thành"}); // 3
            this.cboBusinessType.Properties.PopupSizeable = true;
            this.cboBusinessType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBusinessType.Size = new System.Drawing.Size(304, 20);
            this.cboBusinessType.TabIndex = 9;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(7, 133);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 13);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Nguồn vốn";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 85);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "TK tham chiếu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 109);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "&Bên kết chuyển";
            // 
            // grdLookUpEditToAccount
            // 
            this.grdLookUpEditToAccount.EditValue = "true";
            this.grdLookUpEditToAccount.Location = new System.Drawing.Point(299, 32);
            this.grdLookUpEditToAccount.Name = "grdLookUpEditToAccount";
            this.grdLookUpEditToAccount.Properties.AutoHeight = false;
            this.grdLookUpEditToAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdLookUpEditToAccount.Properties.NullText = "";
            this.grdLookUpEditToAccount.Properties.PopupWidth = 450;
            this.grdLookUpEditToAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditToAccount.Size = new System.Drawing.Size(104, 20);
            this.grdLookUpEditToAccount.TabIndex = 7;
            this.grdLookUpEditToAccount.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditToAccount_ButtonClick);
            this.grdLookUpEditToAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditToAccount_KeyDown);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(210, 36);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Đế&n tài khoản";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 36);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "&Từ tài khoản (*)";
            // 
            // spinTransferOrder
            // 
            this.spinTransferOrder.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinTransferOrder.Location = new System.Drawing.Point(299, 8);
            this.spinTransferOrder.Name = "spinTransferOrder";
            this.spinTransferOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinTransferOrder.Properties.IsFloatValue = false;
            this.spinTransferOrder.Properties.Mask.EditMask = "N00";
            this.spinTransferOrder.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinTransferOrder.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinTransferOrder.Size = new System.Drawing.Size(104, 20);
            this.spinTransferOrder.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(210, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "&Số thứ tự";
            // 
            // txtAccountTransferCode
            // 
            this.txtAccountTransferCode.Location = new System.Drawing.Point(99, 8);
            this.txtAccountTransferCode.Name = "txtAccountTransferCode";
            this.txtAccountTransferCode.Size = new System.Drawing.Size(104, 20);
            this.txtAccountTransferCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã kết chuyển (*)";
            // 
            // grdLookUpEditReferentAccount
            // 
            this.grdLookUpEditReferentAccount.EditValue = true;
            this.grdLookUpEditReferentAccount.Location = new System.Drawing.Point(99, 80);
            this.grdLookUpEditReferentAccount.Name = "grdLookUpEditReferentAccount";
            this.grdLookUpEditReferentAccount.Properties.AutoHeight = false;
            this.grdLookUpEditReferentAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditReferentAccount.Properties.NullText = "";
            this.grdLookUpEditReferentAccount.Properties.PopupWidth = 450;
            this.grdLookUpEditReferentAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditReferentAccount.Size = new System.Drawing.Size(304, 20);
            this.grdLookUpEditReferentAccount.TabIndex = 11;
            this.grdLookUpEditReferentAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditReferentAccount_KeyDown);
            // 
            // grdLookUpEditFromAccount
            // 
            this.grdLookUpEditFromAccount.EditValue = "true";
            this.grdLookUpEditFromAccount.Location = new System.Drawing.Point(99, 32);
            this.grdLookUpEditFromAccount.Name = "grdLookUpEditFromAccount";
            this.grdLookUpEditFromAccount.Properties.AutoHeight = false;
            this.grdLookUpEditFromAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdLookUpEditFromAccount.Properties.NullText = "";
            this.grdLookUpEditFromAccount.Properties.PopupWidth = 450;
            this.grdLookUpEditFromAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditFromAccount.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditFromAccount_Properties_ButtonClick);
            this.grdLookUpEditFromAccount.Size = new System.Drawing.Size(104, 20);
            this.grdLookUpEditFromAccount.TabIndex = 5;
            this.grdLookUpEditFromAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditFromAccount_KeyDown);
            // 
            // cboTransferSide
            // 
            this.cboTransferSide.EditValue = "";
            this.cboTransferSide.Location = new System.Drawing.Point(99, 104);
            this.cboTransferSide.Name = "cboTransferSide";
            this.cboTransferSide.Properties.AutoHeight = false;
            this.cboTransferSide.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTransferSide.Properties.Items.AddRange(new object[] {
            "Nợ",
            "Có",
            "Hai bên"});
            this.cboTransferSide.Properties.PopupSizeable = true;
            this.cboTransferSide.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTransferSide.Size = new System.Drawing.Size(304, 20);
            this.cboTransferSide.TabIndex = 13;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(8, 252);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // grdLookUpEditBudgetSource
            // 
            this.grdLookUpEditBudgetSource.EditValue = "true";
            this.grdLookUpEditBudgetSource.Location = new System.Drawing.Point(99, 128);
            this.grdLookUpEditBudgetSource.Name = "grdLookUpEditBudgetSource";
            this.grdLookUpEditBudgetSource.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLookUpEditBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdLookUpEditBudgetSource.Properties.NullText = "";
            this.grdLookUpEditBudgetSource.Properties.PopupSizeable = false;
            this.grdLookUpEditBudgetSource.Properties.PopupWidth = 400;
            this.grdLookUpEditBudgetSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditBudgetSource.Size = new System.Drawing.Size(304, 20);
            this.grdLookUpEditBudgetSource.TabIndex = 15;
            this.grdLookUpEditBudgetSource.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditBudgetSource_ButtonClick);
            this.grdLookUpEditBudgetSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditBudgetSource_KeyDown);
            // 
            // FrmAccountTransferDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 311);
            this.ComponentName = "Tài khoản kết chuyển";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2020, 5, 14, 11, 57, 44, 784);
            this.FormCaption = "Tài khoản kết chuyển";
            this.Name = "FrmAccountTransferDetail";
            this.Reference = "THÊM TÀI KHOẢN KẾT CHUYỂN - ID ";
            this.Text = "FrmAccountTransferDetail";
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusinessType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditToAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTransferOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTransferCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditReferentAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditFromAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferSide.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditBudgetSource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboBusinessType;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditToAccount;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SpinEdit spinTransferOrder;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAccountTransferCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditReferentAccount;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditFromAccount;
        private DevExpress.XtraEditors.ComboBoxEdit cboTransferSide;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditBudgetSource;
    }
}