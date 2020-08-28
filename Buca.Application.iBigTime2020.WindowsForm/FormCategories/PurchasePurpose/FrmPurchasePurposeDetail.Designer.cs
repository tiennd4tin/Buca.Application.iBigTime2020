namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.PurchasePurpose
{
    partial class FrmPurchasePurposeDetail
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
            this.txtPurchasePurposeCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtPurchasePurposeName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePurposeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePurposeName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 193);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(312, 193);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 193);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.txtPurchasePurposeName);
            this.groupboxMain.Controls.Add(this.txtPurchasePurposeCode);
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.label3);
            this.groupboxMain.Controls.Add(this.label2);
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Size = new System.Drawing.Size(378, 152);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhóm  HHDV(*)";
            this.label1.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên nhóm HHDV(*)";
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
            this.chkActive.Location = new System.Drawing.Point(6, 166);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Đượ&c sử dụng";
            this.chkActive.Size = new System.Drawing.Size(94, 19);
            this.chkActive.TabIndex = 1;
            // 
            // txtPurchasePurposeCode
            // 
            this.txtPurchasePurposeCode.Location = new System.Drawing.Point(108, 12);
            this.txtPurchasePurposeCode.Name = "txtPurchasePurposeCode";
            this.txtPurchasePurposeCode.Size = new System.Drawing.Size(112, 20);
            this.txtPurchasePurposeCode.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(108, 65);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(261, 79);
            this.txtDescription.TabIndex = 5;
            // 
            // txtPurchasePurposeName
            // 
            this.txtPurchasePurposeName.Location = new System.Drawing.Point(108, 39);
            this.txtPurchasePurposeName.Name = "txtPurchasePurposeName";
            this.txtPurchasePurposeName.Size = new System.Drawing.Size(261, 20);
            this.txtPurchasePurposeName.TabIndex = 3;
            // 
            // FrmPurchasePurposeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 225);
            this.ComponentName = "Nhóm hàng hóa dịch vụ";
            this.Controls.Add(this.chkActive);
            this.EventTime = new System.DateTime(2018, 5, 23, 18, 48, 43, 153);
            this.FormCaption = "Nhóm hàng hóa dịch vụ";
            this.Name = "FrmPurchasePurposeDetail";
            this.Reference = "THÊM NHÓM HÀNG HÓA DỊCH VỤ - ID ";
            this.TableCode = "PurchasePurpose";
            this.Text = "FrmPurchasePurposeDetail";
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePurposeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasePurposeName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.CheckEdit chkIsSystem;
        private DevExpress.XtraEditors.TextEdit txtPurchasePurposeName;
        private DevExpress.XtraEditors.TextEdit txtPurchasePurposeCode;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
    }
}