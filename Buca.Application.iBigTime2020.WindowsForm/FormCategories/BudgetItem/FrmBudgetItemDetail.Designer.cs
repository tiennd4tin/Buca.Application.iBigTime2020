namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem
{
    partial class FrmBudgetItemDetail
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
            this.cboBudgetItemType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblParentID = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtBudgetItemCode = new DevExpress.XtraEditors.TextEdit();
            this.txtBudgetItemName = new DevExpress.XtraEditors.TextEdit();
            this.grdLookUpEditParentId = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditParentId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.grdLookUpEditParentId);
            this.groupboxMain.Controls.Add(this.txtBudgetItemName);
            this.groupboxMain.Controls.Add(this.txtBudgetItemCode);
            this.groupboxMain.Controls.Add(this.lblParentID);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.cboBudgetItemType);
            this.groupboxMain.Location = new System.Drawing.Point(8, 9);
            this.groupboxMain.Size = new System.Drawing.Size(431, 118);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 153);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(372, 153);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 153);
            this.btnHelp.TabIndex = 4;
            // 
            // cboBudgetItemType
            // 
            this.cboBudgetItemType.EditValue = "";
            this.cboBudgetItemType.Location = new System.Drawing.Point(73, 10);
            this.cboBudgetItemType.Name = "cboBudgetItemType";
            this.cboBudgetItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetItemType.Properties.Items.AddRange(new object[] {
            "Nhóm",
            "Tiểu Nhóm",
            "Mục",
            "Tiểu Mục"});
            this.cboBudgetItemType.Size = new System.Drawing.Size(169, 20);
            this.cboBudgetItemType.TabIndex = 1;
            this.cboBudgetItemType.SelectedIndexChanged += new System.EventHandler(this.cboBudgetItemType_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Loại";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mã (*)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tên (*)";
            // 
            // lblParentID
            // 
            this.lblParentID.Location = new System.Drawing.Point(10, 92);
            this.lblParentID.Name = "lblParentID";
            this.lblParentID.Size = new System.Drawing.Size(58, 13);
            this.lblParentID.TabIndex = 6;
            this.lblParentID.Text = "Thuộc nhóm";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(6, 131);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(115, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // txtBudgetItemCode
            // 
            this.txtBudgetItemCode.Location = new System.Drawing.Point(73, 36);
            this.txtBudgetItemCode.Name = "txtBudgetItemCode";
            this.txtBudgetItemCode.Size = new System.Drawing.Size(349, 20);
            this.txtBudgetItemCode.TabIndex = 3;
            // 
            // txtBudgetItemName
            // 
            this.txtBudgetItemName.Location = new System.Drawing.Point(73, 62);
            this.txtBudgetItemName.Name = "txtBudgetItemName";
            this.txtBudgetItemName.Properties.NullText = "<Tên mục lục ngân sách mới>";
            this.txtBudgetItemName.Size = new System.Drawing.Size(349, 20);
            this.txtBudgetItemName.TabIndex = 5;
            // 
            // grdLookUpEditParentId
            // 
            this.grdLookUpEditParentId.EditValue = "";
            this.grdLookUpEditParentId.Location = new System.Drawing.Point(73, 88);
            this.grdLookUpEditParentId.Name = "grdLookUpEditParentId";
            this.grdLookUpEditParentId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLookUpEditParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdLookUpEditParentId.Properties.NullText = "";
            this.grdLookUpEditParentId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditParentId.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditParentId_Properties_ButtonClick);
            this.grdLookUpEditParentId.Size = new System.Drawing.Size(349, 20);
            this.grdLookUpEditParentId.TabIndex = 7;
            this.grdLookUpEditParentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditParentId_KeyDown);
            // 
            // FrmBudgetItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 184);
            this.ComponentName = "Mục Tiểu mục";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 10, 9, 14, 34, 37, 958);
            this.FormCaption = "Mục Tiểu mục";
            this.Name = "FrmBudgetItemDetail";
            this.Reference = "THÊM MỤC TIỂU MỤC - ID ";
            this.Text = "FrmBudgetItemDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditParentId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboBudgetItemType;
        private DevExpress.XtraEditors.LabelControl lblParentID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditParentId;
        private DevExpress.XtraEditors.TextEdit txtBudgetItemName;
        private DevExpress.XtraEditors.TextEdit txtBudgetItemCode;
    }
}