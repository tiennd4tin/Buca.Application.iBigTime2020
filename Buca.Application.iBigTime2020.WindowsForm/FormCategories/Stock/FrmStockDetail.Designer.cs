namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Stock
{
    partial class FrmStockDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboDefaultAccountNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.txtStockCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtStockName = new DevExpress.XtraEditors.TextEdit();
            this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 221);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(312, 221);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 221);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.txtAccountName);
            this.groupboxMain.Controls.Add(this.txtStockName);
            this.groupboxMain.Controls.Add(this.txtStockCode);
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.cboDefaultAccountNumber);
            this.groupboxMain.Controls.Add(this.label3);
            this.groupboxMain.Controls.Add(this.label2);
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Size = new System.Drawing.Size(378, 179);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Mã kho (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên &kho (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mô &tả";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(6, 194);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Đượ&c sử dụng";
            this.chkActive.Size = new System.Drawing.Size(94, 19);
            this.chkActive.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(8, 155);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 13);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "TK Kho";
            // 
            // cboDefaultAccountNumber
            // 
            this.cboDefaultAccountNumber.EditValue = true;
            this.cboDefaultAccountNumber.Location = new System.Drawing.Point(72, 151);
            this.cboDefaultAccountNumber.Name = "cboDefaultAccountNumber";
            this.cboDefaultAccountNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboDefaultAccountNumber.Properties.NullText = "";
            this.cboDefaultAccountNumber.Properties.PopupWidth = 350;
            this.cboDefaultAccountNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDefaultAccountNumber.Size = new System.Drawing.Size(88, 20);
            this.cboDefaultAccountNumber.TabIndex = 7;
            this.cboDefaultAccountNumber.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboDefaultAccountNumber_ButtonClick);
            this.cboDefaultAccountNumber.EditValueChanged += new System.EventHandler(this.cboDefaultAccountNumber_EditValueChanged);
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(72, 12);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(112, 20);
            this.txtStockCode.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 65);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(297, 79);
            this.txtDescription.TabIndex = 5;
            // 
            // txtStockName
            // 
            this.txtStockName.Location = new System.Drawing.Point(72, 39);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(297, 20);
            this.txtStockName.TabIndex = 3;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Enabled = false;
            this.txtAccountName.Location = new System.Drawing.Point(166, 151);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(203, 20);
            this.txtAccountName.TabIndex = 8;
            // 
            // FrmStockDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 253);
            this.ComponentName = "Kho";
            this.Controls.Add(this.chkActive);
            this.EventTime = new System.DateTime(2019, 10, 9, 10, 51, 33, 485);
            this.FormCaption = "Kho";
            this.Name = "FrmStockDetail";
            this.Reference = "THÊM KHO - ID ";
            this.TableCode = "Stock";
            this.Text = "FrmXtraStockDetail";
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cboDefaultAccountNumber;
        private DevExpress.XtraEditors.TextEdit txtAccountName;
        private DevExpress.XtraEditors.TextEdit txtStockName;
        private DevExpress.XtraEditors.TextEdit txtStockCode;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
    }
}