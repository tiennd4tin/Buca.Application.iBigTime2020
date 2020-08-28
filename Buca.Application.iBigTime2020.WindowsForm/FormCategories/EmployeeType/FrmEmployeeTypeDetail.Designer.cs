namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.EmployeeType
{
    partial class FrmEmployeeTypeDetail
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
            this.lblEmployeeTypeCode = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeTypeCode = new DevExpress.XtraEditors.TextEdit();
            this.txtEmployeeTypeName = new DevExpress.XtraEditors.TextEdit();
            this.lblEmployeeTypeName = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(344, 197);
            this.btnSave.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(416, 197);
            this.btnExit.TabIndex = 6;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 197);
            this.btnHelp.TabIndex = 7;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.lblDescription);
            this.groupboxMain.Controls.Add(this.txtEmployeeTypeName);
            this.groupboxMain.Controls.Add(this.lblEmployeeTypeName);
            this.groupboxMain.Controls.Add(this.txtEmployeeTypeCode);
            this.groupboxMain.Controls.Add(this.lblEmployeeTypeCode);
            this.groupboxMain.Size = new System.Drawing.Size(480, 162);
            // 
            // lblEmployeeTypeCode
            // 
            this.lblEmployeeTypeCode.Location = new System.Drawing.Point(9, 10);
            this.lblEmployeeTypeCode.Name = "lblEmployeeTypeCode";
            this.lblEmployeeTypeCode.Size = new System.Drawing.Size(85, 13);
            this.lblEmployeeTypeCode.TabIndex = 0;
            this.lblEmployeeTypeCode.Text = "Mã loại cán bộ (*)";
            // 
            // txtEmployeeTypeCode
            // 
            this.txtEmployeeTypeCode.Location = new System.Drawing.Point(102, 7);
            this.txtEmployeeTypeCode.Name = "txtEmployeeTypeCode";
            this.txtEmployeeTypeCode.Size = new System.Drawing.Size(195, 20);
            this.txtEmployeeTypeCode.TabIndex = 1;
            // 
            // txtEmployeeTypeName
            // 
            this.txtEmployeeTypeName.Location = new System.Drawing.Point(102, 33);
            this.txtEmployeeTypeName.Name = "txtEmployeeTypeName";
            this.txtEmployeeTypeName.Size = new System.Drawing.Size(368, 20);
            this.txtEmployeeTypeName.TabIndex = 2;
            // 
            // lblEmployeeTypeName
            // 
            this.lblEmployeeTypeName.Location = new System.Drawing.Point(9, 36);
            this.lblEmployeeTypeName.Name = "lblEmployeeTypeName";
            this.lblEmployeeTypeName.Size = new System.Drawing.Size(89, 13);
            this.lblEmployeeTypeName.TabIndex = 2;
            this.lblEmployeeTypeName.Text = "Tên loại cán bộ (*)";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 97);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(40, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Diễn giải";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(6, 175);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(103, 19);
            this.chkIsActive.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(102, 60);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(368, 96);
            this.txtDescription.TabIndex = 3;
            // 
            // FrmEmployeeTypeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 229);
            this.ComponentName = "Loại cán bộ";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2017, 12, 7, 14, 47, 48, 932);
            this.FormCaption = "Loại cán bộ";
            this.KeyValue = "EmployeeTypeId";
            this.Name = "FrmEmployeeTypeDetail";
            this.Reference = "THÊM LOẠI CÁN BỘ - ID EmployeeTypeId";
            this.Text = "Loại cán bộ";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblEmployeeTypeCode;
        private DevExpress.XtraEditors.TextEdit txtEmployeeTypeCode;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.TextEdit txtEmployeeTypeName;
        private DevExpress.XtraEditors.LabelControl lblEmployeeTypeName;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
    }
}