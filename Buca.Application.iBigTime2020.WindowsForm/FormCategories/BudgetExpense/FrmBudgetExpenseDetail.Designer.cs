namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetExpense
{
    partial class FrmBudgetExpenseDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboBudgetExpenseType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBudgetExpenseName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtBudgetExpenseCode = new DevExpress.XtraEditors.TextEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetExpenseType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetExpenseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetExpenseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(285, 133);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(357, 133);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 133);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.cboBudgetExpenseType);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtBudgetExpenseName);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.txtBudgetExpenseCode);
            this.groupboxMain.Size = new System.Drawing.Size(421, 96);
            // 
            // cboBudgetExpenseType
            // 
            this.cboBudgetExpenseType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBudgetExpenseType.EditValue = "Phí";
            this.cboBudgetExpenseType.Location = new System.Drawing.Point(104, 65);
            this.cboBudgetExpenseType.Name = "cboBudgetExpenseType";
            this.cboBudgetExpenseType.Properties.AutoComplete = false;
            this.cboBudgetExpenseType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetExpenseType.Properties.ImmediatePopup = true;
            this.cboBudgetExpenseType.Properties.Items.AddRange(new object[] {
            "Phí",
            "Lệ phí"});
            this.cboBudgetExpenseType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBudgetExpenseType.Size = new System.Drawing.Size(306, 20);
            this.cboBudgetExpenseType.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 69);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(85, 13);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Loại phí, lệ phí (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tên phí, lệ phí (*)";
            // 
            // txtBudgetExpenseName
            // 
            this.txtBudgetExpenseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBudgetExpenseName.Location = new System.Drawing.Point(104, 38);
            this.txtBudgetExpenseName.Name = "txtBudgetExpenseName";
            this.txtBudgetExpenseName.Size = new System.Drawing.Size(306, 20);
            this.txtBudgetExpenseName.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mã phí, lệ phí (*)";
            // 
            // txtBudgetExpenseCode
            // 
            this.txtBudgetExpenseCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBudgetExpenseCode.Location = new System.Drawing.Point(104, 11);
            this.txtBudgetExpenseCode.Name = "txtBudgetExpenseCode";
            this.txtBudgetExpenseCode.Size = new System.Drawing.Size(306, 20);
            this.txtBudgetExpenseCode.TabIndex = 1;
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(5, 108);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "&Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(135, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // FrmBudgetExpenseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 165);
            this.ComponentName = "Phí, lệ phí";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 2, 26, 10, 29, 55, 526);
            this.FormCaption = "Phí, lệ phí";
            this.Name = "FrmBudgetExpenseDetail";
            this.Reference = "THÊM PHÍ, LỆ PHÍ - ID ";
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetExpenseType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetExpenseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetExpenseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboBudgetExpenseType;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        protected DevExpress.XtraEditors.TextEdit txtBudgetExpenseName;
        protected DevExpress.XtraEditors.LabelControl labelControl4;
        protected DevExpress.XtraEditors.TextEdit txtBudgetExpenseCode;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}
