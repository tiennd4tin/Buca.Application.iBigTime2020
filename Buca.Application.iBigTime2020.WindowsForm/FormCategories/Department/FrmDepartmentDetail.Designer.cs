namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department
{
    partial class FrmDepartmentDetail
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
            this.txtDepartmentCode = new DevExpress.XtraEditors.TextEdit();
            this.lblDepartmentCode = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.lblDepartmentName = new DevExpress.XtraEditors.LabelControl();
            this.lblParentId = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.cboParentId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParentId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.cboParentId);
            this.groupboxMain.Controls.Add(this.lblDescription);
            this.groupboxMain.Controls.Add(this.lblParentId);
            this.groupboxMain.Controls.Add(this.txtDepartmentName);
            this.groupboxMain.Controls.Add(this.lblDepartmentName);
            this.groupboxMain.Controls.Add(this.txtDepartmentCode);
            this.groupboxMain.Controls.Add(this.lblDepartmentCode);
            this.groupboxMain.Location = new System.Drawing.Point(10, 10);
            this.groupboxMain.Margin = new System.Windows.Forms.Padding(0);
            this.groupboxMain.Size = new System.Drawing.Size(487, 177);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(350, 216);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(427, 216);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.TabIndex = 7;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(10, 216);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(0);
            this.btnHelp.TabIndex = 8;
            // 
            // txtDepartmentCode
            // 
            this.txtDepartmentCode.EditValue = "";
            this.txtDepartmentCode.Location = new System.Drawing.Point(107, 10);
            this.txtDepartmentCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtDepartmentCode.Name = "txtDepartmentCode";
            this.txtDepartmentCode.Properties.NullText = "<Tên phòng ban mới>";
            this.txtDepartmentCode.Size = new System.Drawing.Size(367, 20);
            this.txtDepartmentCode.TabIndex = 1;
            // 
            // lblDepartmentCode
            // 
            this.lblDepartmentCode.Location = new System.Drawing.Point(10, 13);
            this.lblDepartmentCode.Name = "lblDepartmentCode";
            this.lblDepartmentCode.Size = new System.Drawing.Size(86, 13);
            this.lblDepartmentCode.TabIndex = 2;
            this.lblDepartmentCode.Text = "Mã Phòng/Ban (*)";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(107, 36);
            this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(0);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Properties.NullText = "<Tên phòng ban mới>";
            this.txtDepartmentName.Size = new System.Drawing.Size(367, 20);
            this.txtDepartmentName.TabIndex = 2;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.Location = new System.Drawing.Point(10, 38);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(90, 13);
            this.lblDepartmentName.TabIndex = 4;
            this.lblDepartmentName.Text = "Tên Phòng/Ban (*)";
            // 
            // lblParentId
            // 
            this.lblParentId.Location = new System.Drawing.Point(10, 66);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(84, 13);
            this.lblParentId.TabIndex = 6;
            this.lblParentId.Text = "Thuộc Phòng/Ban";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(10, 121);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(40, 13);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Diễn giải";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 193);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(0);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(100, 19);
            this.chkIsActive.TabIndex = 5;
            // 
            // cboParentId
            // 
            this.cboParentId.Location = new System.Drawing.Point(107, 62);
            this.cboParentId.Margin = new System.Windows.Forms.Padding(0);
            this.cboParentId.Name = "cboParentId";
            this.cboParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.cboParentId.Properties.NullText = "";
            this.cboParentId.Size = new System.Drawing.Size(367, 20);
            this.cboParentId.TabIndex = 3;
            this.cboParentId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboParentId_ButtonClick);
            this.cboParentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboParentId_KeyDown);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(107, 88);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(367, 81);
            this.txtDescription.TabIndex = 4;
            // 
            // FrmDepartmentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.ComponentName = "Phòng ban";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 10, 9, 14, 40, 27, 384);
            this.FormCaption = "Phòng ban";
            this.Name = "FrmDepartmentDetail";
            this.Reference = "THÊM PHÒNG BAN - ID ";
            this.Text = "Phòng ban";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParentId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblParentId;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraEditors.LabelControl lblDepartmentName;
        private DevExpress.XtraEditors.TextEdit txtDepartmentCode;
        private DevExpress.XtraEditors.LabelControl lblDepartmentCode;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.LookUpEdit cboParentId;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
    }
}