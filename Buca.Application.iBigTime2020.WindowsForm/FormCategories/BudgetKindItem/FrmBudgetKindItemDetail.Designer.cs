namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetKindItem
{
    partial class FrmBudgetKindItemDetail
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
            this.txtBudgetKindItemCode = new DevExpress.XtraEditors.TextEdit();
            this.grdLookUpEditParentId = new DevExpress.XtraEditors.LookUpEdit();
            this.memoBudgetKindItemName = new DevExpress.XtraEditors.MemoEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetKindItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditParentId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBudgetKindItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.memoBudgetKindItemName);
            this.groupboxMain.Controls.Add(this.grdLookUpEditParentId);
            this.groupboxMain.Controls.Add(this.txtBudgetKindItemCode);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Size = new System.Drawing.Size(493, 112);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(368, 148);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(440, 148);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 148);
            this.btnHelp.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã loại khoản (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tên loại khoản (*)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(263, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Thuộc loại";
            // 
            // txtBudgetKindItemCode
            // 
            this.txtBudgetKindItemCode.Location = new System.Drawing.Point(101, 11);
            this.txtBudgetKindItemCode.Name = "txtBudgetKindItemCode";
            this.txtBudgetKindItemCode.Size = new System.Drawing.Size(155, 20);
            this.txtBudgetKindItemCode.TabIndex = 1;
            // 
            // grdLookUpEditParentId
            // 
            this.grdLookUpEditParentId.EditValue = "";
            this.grdLookUpEditParentId.Location = new System.Drawing.Point(317, 12);
            this.grdLookUpEditParentId.Name = "grdLookUpEditParentId";
            this.grdLookUpEditParentId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLookUpEditParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdLookUpEditParentId.Properties.NullText = "";
            this.grdLookUpEditParentId.Properties.PopupSizeable = false;
            this.grdLookUpEditParentId.Properties.PopupWidth = 400;
            this.grdLookUpEditParentId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditParentId.Size = new System.Drawing.Size(165, 20);
            this.grdLookUpEditParentId.TabIndex = 3;
            this.grdLookUpEditParentId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditParentId_ButtonClick);
            this.grdLookUpEditParentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditParentId_KeyDown);
            // 
            // memoBudgetKindItemName
            // 
            this.memoBudgetKindItemName.Location = new System.Drawing.Point(101, 37);
            this.memoBudgetKindItemName.Name = "memoBudgetKindItemName";
            this.memoBudgetKindItemName.Properties.NullText = "<Tên loại khoản mới>";
            this.memoBudgetKindItemName.Size = new System.Drawing.Size(381, 66);
            this.memoBudgetKindItemName.TabIndex = 5;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(8, 125);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(132, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // FrmBudgetKindItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 179);
            this.ComponentName = "Loại khoản";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 10, 9, 14, 32, 0, 779);
            this.FormCaption = "Loại khoản";
            this.KeyFieldName = "";
            this.Name = "FrmBudgetKindItemDetail";
            this.Reference = "THÊM LOẠI KHOẢN - ID ";
            this.Text = "FrmBudgetKindItemDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetKindItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditParentId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBudgetKindItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditParentId;
        private DevExpress.XtraEditors.TextEdit txtBudgetKindItemCode;
        private DevExpress.XtraEditors.MemoEdit memoBudgetKindItemName;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}