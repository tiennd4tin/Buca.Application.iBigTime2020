namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank
{
    internal partial class FrmBankDetail
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
            this.lbCode = new DevExpress.XtraEditors.LabelControl();
            this.lbType = new DevExpress.XtraEditors.LabelControl();
            this.lbFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtBankAccount = new DevExpress.XtraEditors.TextEdit();
            this.lbBankAccount = new DevExpress.XtraEditors.LabelControl();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.lbTaxCode = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtBudgetCode = new DevExpress.XtraEditors.TextEdit();
            this.chkIsOpenInBank = new DevExpress.XtraEditors.CheckEdit();
            this.radIsOpenInBank = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsOpenInBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radIsOpenInBank.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(330, 289);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(406, 289);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(10, 289);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.radIsOpenInBank);
            this.groupboxMain.Controls.Add(this.chkIsOpenInBank);
            this.groupboxMain.Controls.Add(this.txtBudgetCode);
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.txtBankName);
            this.groupboxMain.Controls.Add(this.txtBankAccount);
            this.groupboxMain.Controls.Add(this.lbTaxCode);
            this.groupboxMain.Controls.Add(this.lbBankAccount);
            this.groupboxMain.Controls.Add(this.txtAddress);
            this.groupboxMain.Controls.Add(this.lbFullName);
            this.groupboxMain.Controls.Add(this.lbType);
            this.groupboxMain.Controls.Add(this.lbCode);
            this.groupboxMain.Location = new System.Drawing.Point(10, 4);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 256);
            // 
            // btnPrintFixAsset
            // 
            this.btnPrintFixAsset.Location = new System.Drawing.Point(84, 290);
            // 
            // lbCode
            // 
            this.lbCode.Location = new System.Drawing.Point(8, 34);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(76, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Số tài khoản (*)";
            // 
            // lbType
            // 
            this.lbType.Location = new System.Drawing.Point(8, 58);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(71, 13);
            this.lbType.TabIndex = 3;
            this.lbType.Text = "Tên NH, KB (*)";
            // 
            // lbFullName
            // 
            this.lbFullName.Location = new System.Drawing.Point(8, 82);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(32, 13);
            this.lbFullName.TabIndex = 5;
            this.lbFullName.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 82);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(350, 20);
            this.txtAddress.TabIndex = 6;
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.Location = new System.Drawing.Point(104, 30);
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(160, 20);
            this.txtBankAccount.TabIndex = 1;
            // 
            // lbBankAccount
            // 
            this.lbBankAccount.Location = new System.Drawing.Point(8, 106);
            this.lbBankAccount.Name = "lbBankAccount";
            this.lbBankAccount.Size = new System.Drawing.Size(86, 13);
            this.lbBankAccount.TabIndex = 7;
            this.lbBankAccount.Text = "Mã cấp ngân sách";
            // 
            // cbIsActive
            // 
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(8, 265);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(96, 19);
            this.cbIsActive.TabIndex = 1;
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(104, 56);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(350, 20);
            this.txtBankName.TabIndex = 4;
            // 
            // lbTaxCode
            // 
            this.lbTaxCode.Location = new System.Drawing.Point(8, 164);
            this.lbTaxCode.Name = "lbTaxCode";
            this.lbTaxCode.Size = new System.Drawing.Size(40, 13);
            this.lbTaxCode.TabIndex = 9;
            this.lbTaxCode.Text = "Diễn giải";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 134);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(350, 88);
            this.txtDescription.TabIndex = 10;
            // 
            // txtBudgetCode
            // 
            this.txtBudgetCode.Location = new System.Drawing.Point(104, 108);
            this.txtBudgetCode.Name = "txtBudgetCode";
            this.txtBudgetCode.Size = new System.Drawing.Size(350, 20);
            this.txtBudgetCode.TabIndex = 8;
            // 
            // chkIsOpenInBank
            // 
            this.chkIsOpenInBank.Location = new System.Drawing.Point(265, 33);
            this.chkIsOpenInBank.Name = "chkIsOpenInBank";
            this.chkIsOpenInBank.Properties.Caption = "Được mở tại ngân hàng";
            this.chkIsOpenInBank.Size = new System.Drawing.Size(144, 19);
            this.chkIsOpenInBank.TabIndex = 2;
            this.chkIsOpenInBank.Visible = false;
            // 
            // radIsOpenInBank
            // 
            this.radIsOpenInBank.Location = new System.Drawing.Point(100, 224);
            this.radIsOpenInBank.Name = "radIsOpenInBank";
            this.radIsOpenInBank.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radIsOpenInBank.Properties.Appearance.Options.UseBackColor = true;
            this.radIsOpenInBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radIsOpenInBank.Properties.Columns = 2;
            this.radIsOpenInBank.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mở tại ngân hàng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mở tại kho bạc")});
            this.radIsOpenInBank.Size = new System.Drawing.Size(350, 28);
            this.radIsOpenInBank.TabIndex = 11;
            // 
            // FrmBankDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 321);
            this.ComponentName = "Tài khoản ngân hàng, kho bạc";
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2018, 12, 12, 16, 1, 28, 958);
            this.FormCaption = "Tài khoản ngân hàng, kho bạc";
            this.Name = "FrmBankDetail";
            this.Reference = "THÊM TÀI KHOẢN NGÂN HÀNG, KHO BẠC - ID ";
            this.TableCode = "AccountingObject";
            this.Text = "FrmBankDetail";
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsOpenInBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radIsOpenInBank.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.LabelControl lbCode;
        private DevExpress.XtraEditors.LabelControl lbType;
        private DevExpress.XtraEditors.TextEdit txtBankAccount;
        private DevExpress.XtraEditors.LabelControl lbBankAccount;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl lbFullName;
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private DevExpress.XtraEditors.LabelControl lbTaxCode;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtBudgetCode;
        private DevExpress.XtraEditors.CheckEdit chkIsOpenInBank;
        private DevExpress.XtraEditors.RadioGroup radIsOpenInBank;
    }
}