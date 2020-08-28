namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.InvoiceFormNumber
{
    partial class FrmInvoiceFormNumberDetail
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceFormNumberCode = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceFormNumberName = new DevExpress.XtraEditors.TextEdit();
            this.grdInvoiceFormNumberCategoryID = new DevExpress.XtraEditors.LookUpEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceFormNumberCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceFormNumberName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceFormNumberCategoryID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(298, 119);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(370, 119);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 119);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.grdInvoiceFormNumberCategoryID);
            this.groupboxMain.Controls.Add(this.txtInvoiceFormNumberName);
            this.groupboxMain.Controls.Add(this.txtInvoiceFormNumberCode);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Size = new System.Drawing.Size(432, 88);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mẫu số (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Loại hóa đơn (*)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tên mẫu (*)";
            // 
            // txtInvoiceFormNumberCode
            // 
            this.txtInvoiceFormNumberCode.Location = new System.Drawing.Point(93, 8);
            this.txtInvoiceFormNumberCode.Name = "txtInvoiceFormNumberCode";
            this.txtInvoiceFormNumberCode.Size = new System.Drawing.Size(176, 20);
            this.txtInvoiceFormNumberCode.TabIndex = 1;
            // 
            // txtInvoiceFormNumberName
            // 
            this.txtInvoiceFormNumberName.Location = new System.Drawing.Point(93, 59);
            this.txtInvoiceFormNumberName.Name = "txtInvoiceFormNumberName";
            this.txtInvoiceFormNumberName.Size = new System.Drawing.Size(330, 20);
            this.txtInvoiceFormNumberName.TabIndex = 5;
            // 
            // grdInvoiceFormNumberCategoryID
            // 
            this.grdInvoiceFormNumberCategoryID.Location = new System.Drawing.Point(93, 33);
            this.grdInvoiceFormNumberCategoryID.Name = "grdInvoiceFormNumberCategoryID";
            this.grdInvoiceFormNumberCategoryID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.grdInvoiceFormNumberCategoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdInvoiceFormNumberCategoryID.Properties.NullText = "";
            this.grdInvoiceFormNumberCategoryID.Size = new System.Drawing.Size(330, 20);
            this.grdInvoiceFormNumberCategoryID.TabIndex = 3;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(6, 98);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(114, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // FrmInvoiceFormNumberDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 151);
            this.ComponentName = "Mẫu số hóa đơn";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2017, 11, 8, 18, 23, 21, 715);
            this.FormCaption = "Mẫu số hóa đơn";
            this.Name = "FrmInvoiceFormNumberDetail";
            this.Reference = "THÊM MẪU SỐ HÓA ĐƠN - ID ";
            this.Text = "FrmInvoiceFormNumberDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceFormNumberCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceFormNumberName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceFormNumberCategoryID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtInvoiceFormNumberCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit grdInvoiceFormNumberCategoryID;
        private DevExpress.XtraEditors.TextEdit txtInvoiceFormNumberName;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}