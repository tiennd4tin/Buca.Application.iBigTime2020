namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FundStructure
{
    internal partial class FrmFundStructureDetail
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
            this.txtFundStructureCode = new DevExpress.XtraEditors.TextEdit();
            this.txtFundStructureNames = new DevExpress.XtraEditors.TextEdit();
            this.lbFullName = new DevExpress.XtraEditors.LabelControl();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtFundStructureName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkuFundStructure = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpInvestmentPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpBudgetItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCashWithdrawType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFundStructureCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFundStructureNames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFundStructureName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuFundStructure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvestmentPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBudgetItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCashWithdrawType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.checkEdit3);
            this.groupboxMain.Controls.Add(this.checkEdit2);
            this.groupboxMain.Controls.Add(this.checkEdit1);
            this.groupboxMain.Controls.Add(this.lookUpCashWithdrawType);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.lookUpBudgetItem);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.lookUpInvestmentPeriod);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.lkuFundStructure);
            this.groupboxMain.Controls.Add(this.txtFundStructureName);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtFundStructureNames);
            this.groupboxMain.Controls.Add(this.lbFullName);
            this.groupboxMain.Controls.Add(this.txtFundStructureCode);
            this.groupboxMain.Controls.Add(this.lbCode);
            this.groupboxMain.Location = new System.Drawing.Point(10, 5);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(443, 127);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 163);
            this.btnSave.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(385, 163);
            this.btnExit.TabIndex = 9;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 163);
            this.btnHelp.TabIndex = 10;
            // 
            // lbCode
            // 
            this.lbCode.Location = new System.Drawing.Point(11, 28);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(79, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Mã khoản chi (*)";
            // 
            // txtFundStructureCode
            // 
            this.txtFundStructureCode.Location = new System.Drawing.Point(99, 24);
            this.txtFundStructureCode.Name = "txtFundStructureCode";
            this.txtFundStructureCode.Size = new System.Drawing.Size(102, 20);
            this.txtFundStructureCode.TabIndex = 1;
            // 
            // txtFundStructureNames
            // 
            this.txtFundStructureNames.Location = new System.Drawing.Point(99, 50);
            this.txtFundStructureNames.Name = "txtFundStructureNames";
            this.txtFundStructureNames.Size = new System.Drawing.Size(309, 20);
            this.txtFundStructureNames.TabIndex = 2;
            // 
            // lbFullName
            // 
            this.lbFullName.Location = new System.Drawing.Point(11, 54);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(83, 13);
            this.lbFullName.TabIndex = 4;
            this.lbFullName.Text = "Tên khoản chi (*)";
            // 
            // cbIsActive
            // 
            this.cbIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(6, 138);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(105, 19);
            this.cbIsActive.TabIndex = 7;
            this.cbIsActive.CheckedChanged += new System.EventHandler(this.cbIsActive_CheckedChanged);
            // 
            // txtFundStructureName
            // 
            this.txtFundStructureName.Location = new System.Drawing.Point(207, 76);
            this.txtFundStructureName.Name = "txtFundStructureName";
            this.txtFundStructureName.Size = new System.Drawing.Size(201, 20);
            this.txtFundStructureName.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Thuộc khoản chi";
            // 
            // lkuFundStructure
            // 
            this.lkuFundStructure.Location = new System.Drawing.Point(99, 76);
            this.lkuFundStructure.Name = "lkuFundStructure";
            this.lkuFundStructure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lkuFundStructure.Properties.NullText = "";
            this.lkuFundStructure.Size = new System.Drawing.Size(102, 20);
            this.lkuFundStructure.TabIndex = 3;
            this.lkuFundStructure.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkuFundStructure_ButtonClick);
            this.lkuFundStructure.EditValueChanged += new System.EventHandler(this.lkuFundStructure_EditValueChanged);
            // 
            // lookUpInvestmentPeriod
            // 
            this.lookUpInvestmentPeriod.Location = new System.Drawing.Point(99, 128);
            this.lookUpInvestmentPeriod.Name = "lookUpInvestmentPeriod";
            this.lookUpInvestmentPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lookUpInvestmentPeriod.Properties.NullText = "";
            this.lookUpInvestmentPeriod.Size = new System.Drawing.Size(309, 20);
            this.lookUpInvestmentPeriod.TabIndex = 5;
            this.lookUpInvestmentPeriod.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUpInvestmentPeriod_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "Giai đoạn đầu tư";
            // 
            // lookUpBudgetItem
            // 
            this.lookUpBudgetItem.Location = new System.Drawing.Point(99, 102);
            this.lookUpBudgetItem.Name = "lookUpBudgetItem";
            this.lookUpBudgetItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lookUpBudgetItem.Properties.NullText = "";
            this.lookUpBudgetItem.Size = new System.Drawing.Size(309, 20);
            this.lookUpBudgetItem.TabIndex = 31;
            this.lookUpBudgetItem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUpBudgetItem_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 13);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "Mục/Tiểu mục";
            // 
            // lookUpCashWithdrawType
            // 
            this.lookUpCashWithdrawType.Location = new System.Drawing.Point(99, 154);
            this.lookUpCashWithdrawType.Name = "lookUpCashWithdrawType";
            this.lookUpCashWithdrawType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCashWithdrawType.Properties.NullText = "";
            this.lookUpCashWithdrawType.Size = new System.Drawing.Size(309, 20);
            this.lookUpCashWithdrawType.TabIndex = 33;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 157);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 34;
            this.labelControl4.Text = "Loại";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(11, 180);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Là chi phí quản lý dự án";
            this.checkEdit1.Size = new System.Drawing.Size(397, 19);
            this.checkEdit1.TabIndex = 36;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(11, 205);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Là chi phí chờ phân bổ";
            this.checkEdit2.Size = new System.Drawing.Size(397, 19);
            this.checkEdit2.TabIndex = 36;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(11, 230);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Là chi phí không tính vào giá trị công trình";
            this.checkEdit3.Size = new System.Drawing.Size(397, 19);
            this.checkEdit3.TabIndex = 36;
            // 
            // FrmFundStructureDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 194);
            this.ComponentName = "Khoản chi";
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2020, 4, 21, 19, 57, 23, 530);
            this.FormCaption = "Khoản chi";
            this.Name = "FrmFundStructureDetail";
            this.Reference = "THÊM KHOẢN CHI - ID ";
            this.TableCode = "FundStructure";
            this.Text = "FrmFundStructureDetail";
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFundStructureCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFundStructureNames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFundStructureName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuFundStructure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvestmentPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBudgetItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCashWithdrawType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbCode;
        private DevExpress.XtraEditors.TextEdit txtFundStructureCode;
        private DevExpress.XtraEditors.TextEdit txtFundStructureNames;
        private DevExpress.XtraEditors.LabelControl lbFullName;
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.TextEdit txtFundStructureName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkuFundStructure;
        private DevExpress.XtraEditors.LookUpEdit lookUpInvestmentPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpBudgetItem;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpCashWithdrawType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}