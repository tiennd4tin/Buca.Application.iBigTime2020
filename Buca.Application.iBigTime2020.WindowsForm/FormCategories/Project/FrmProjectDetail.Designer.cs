using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{
    internal partial class FrmProjectDetail
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
            this.components = new System.ComponentModel.Container();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInformation = new System.Windows.Forms.TabPage();
            this.btnEstimateDetail = new DevExpress.XtraEditors.SimpleButton();
            this.lukExecutionUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtxBankName = new DevExpress.XtraEditors.TextEdit();
            this.txtTargetProjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.calcTotalAmountApproved = new DevExpress.XtraEditors.CalcEdit();
            this.lkUpTargetProgram = new DevExpress.XtraEditors.LookUpEdit();
            this.txtProjectSize = new DevExpress.XtraEditors.TextEdit();
            this.lkuBankAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtBuildLacation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvestmentClass = new DevExpress.XtraEditors.TextEdit();
            this.txtProjectNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvest = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.dateFinishDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.dateStartDate = new DevExpress.XtraEditors.DateEdit();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.tabBank = new System.Windows.Forms.TabPage();
            this.grdBank = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.grdBankView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lukExecutionUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtxBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcTotalAmountApproved.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpTargetProgram.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuildLacation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvestmentClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinishDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinishDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectCode.Properties)).BeginInit();
            this.tabBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBankView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Location = new System.Drawing.Point(8, 2);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(15, 30);
            this.groupboxMain.TabIndex = 21;
            this.groupboxMain.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(507, 230);
            this.btnSave.TabIndex = 18;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(583, 230);
            this.btnExit.TabIndex = 19;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 230);
            this.btnHelp.TabIndex = 20;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(15, 205);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(96, 19);
            this.cbIsActive.TabIndex = 17;
            this.cbIsActive.CheckedChanged += new System.EventHandler(this.cbIsActive_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInformation);
            this.tabControl1.Controls.Add(this.tabBank);
            this.tabControl1.Location = new System.Drawing.Point(8, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 177);
            this.tabControl1.TabIndex = 0;
            // 
            // tabInformation
            // 
            this.tabInformation.BackColor = System.Drawing.Color.White;
            this.tabInformation.Controls.Add(this.btnEstimateDetail);
            this.tabInformation.Controls.Add(this.lukExecutionUnit);
            this.tabInformation.Controls.Add(this.labelControl9);
            this.tabInformation.Controls.Add(this.labelControl7);
            this.tabInformation.Controls.Add(this.txtxBankName);
            this.tabInformation.Controls.Add(this.txtTargetProjectName);
            this.tabInformation.Controls.Add(this.labelControl17);
            this.tabInformation.Controls.Add(this.calcTotalAmountApproved);
            this.tabInformation.Controls.Add(this.lkUpTargetProgram);
            this.tabInformation.Controls.Add(this.txtProjectSize);
            this.tabInformation.Controls.Add(this.lkuBankAccount);
            this.tabInformation.Controls.Add(this.labelControl6);
            this.tabInformation.Controls.Add(this.labelControl18);
            this.tabInformation.Controls.Add(this.txtBuildLacation);
            this.tabInformation.Controls.Add(this.labelControl5);
            this.tabInformation.Controls.Add(this.labelControl15);
            this.tabInformation.Controls.Add(this.labelControl4);
            this.tabInformation.Controls.Add(this.labelControl14);
            this.tabInformation.Controls.Add(this.txtInvestmentClass);
            this.tabInformation.Controls.Add(this.txtProjectNumber);
            this.tabInformation.Controls.Add(this.labelControl1);
            this.tabInformation.Controls.Add(this.txtInvest);
            this.tabInformation.Controls.Add(this.labelControl10);
            this.tabInformation.Controls.Add(this.labelControl11);
            this.tabInformation.Controls.Add(this.dateFinishDate);
            this.tabInformation.Controls.Add(this.labelControl12);
            this.tabInformation.Controls.Add(this.dateStartDate);
            this.tabInformation.Controls.Add(this.txtProjectName);
            this.tabInformation.Controls.Add(this.labelControl13);
            this.tabInformation.Controls.Add(this.txtProjectCode);
            this.tabInformation.Controls.Add(this.labelControl16);
            this.tabInformation.Location = new System.Drawing.Point(4, 22);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformation.Size = new System.Drawing.Size(630, 151);
            this.tabInformation.TabIndex = 0;
            this.tabInformation.Text = "Thông tin chung";
            // 
            // btnEstimateDetail
            // 
            this.btnEstimateDetail.ImageIndex = 0;
            this.btnEstimateDetail.Location = new System.Drawing.Point(493, 247);
            this.btnEstimateDetail.Name = "btnEstimateDetail";
            this.btnEstimateDetail.Size = new System.Drawing.Size(120, 23);
            this.btnEstimateDetail.TabIndex = 80;
            this.btnEstimateDetail.Text = "Chi ti?t d? toán kinh phí";
            this.btnEstimateDetail.Visible = false;
            this.btnEstimateDetail.Click += new System.EventHandler(this.btnEstimateDetail_Click);
            // 
            // lukExecutionUnit
            // 
            this.lukExecutionUnit.Location = new System.Drawing.Point(151, 197);
            this.lukExecutionUnit.Name = "lukExecutionUnit";
            this.lukExecutionUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lukExecutionUnit.Properties.NullText = "";
            this.lukExecutionUnit.Size = new System.Drawing.Size(462, 20);
            this.lukExecutionUnit.TabIndex = 77;
            this.lukExecutionUnit.Visible = false;
            this.lukExecutionUnit.EditValueChanged += new System.EventHandler(this.lukExecutionUnit_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(289, 70);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(69, 13);
            this.labelControl9.TabIndex = 92;
            this.labelControl9.Text = "Tên dự án cha";
            this.labelControl9.ToolTip = "Tên chuong trình m?c tiêu, d? án";
            this.labelControl9.Click += new System.EventHandler(this.labelControl9_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(289, 153);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 13);
            this.labelControl7.TabIndex = 91;
            this.labelControl7.Text = "Tên ngân hàng";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // txtxBankName
            // 
            this.txtxBankName.Location = new System.Drawing.Point(378, 151);
            this.txtxBankName.Name = "txtxBankName";
            this.txtxBankName.Size = new System.Drawing.Size(235, 20);
            this.txtxBankName.TabIndex = 76;
            this.txtxBankName.EditValueChanged += new System.EventHandler(this.txtxBankName_EditValueChanged);
            // 
            // txtTargetProjectName
            // 
            this.txtTargetProjectName.Location = new System.Drawing.Point(378, 67);
            this.txtTargetProjectName.Name = "txtTargetProjectName";
            this.txtTargetProjectName.Size = new System.Drawing.Size(235, 20);
            this.txtTargetProjectName.TabIndex = 74;
            this.txtTargetProjectName.EditValueChanged += new System.EventHandler(this.txtTargetProjectName_EditValueChanged);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(11, 70);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(60, 13);
            this.labelControl17.TabIndex = 83;
            this.labelControl17.Text = "Thuộc dự án";
            this.labelControl17.ToolTip = "Thu?c chuong trình m?c tiêu, d? án";
            this.labelControl17.Click += new System.EventHandler(this.labelControl17_Click);
            // 
            // calcTotalAmountApproved
            // 
            this.calcTotalAmountApproved.Location = new System.Drawing.Point(151, 249);
            this.calcTotalAmountApproved.Name = "calcTotalAmountApproved";
            this.calcTotalAmountApproved.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcTotalAmountApproved.Size = new System.Drawing.Size(462, 20);
            this.calcTotalAmountApproved.TabIndex = 79;
            this.calcTotalAmountApproved.Visible = false;
            this.calcTotalAmountApproved.EditValueChanged += new System.EventHandler(this.calcTotalAmountApproved_EditValueChanged);
            // 
            // lkUpTargetProgram
            // 
            this.lkUpTargetProgram.Location = new System.Drawing.Point(151, 67);
            this.lkUpTargetProgram.Name = "lkUpTargetProgram";
            this.lkUpTargetProgram.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lkUpTargetProgram.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lkUpTargetProgram.Properties.NullText = "";
            this.lkUpTargetProgram.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkUpTargetProgram.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkUpTargetProgram_Properties_ButtonClick);
            this.lkUpTargetProgram.Size = new System.Drawing.Size(132, 20);
            this.lkUpTargetProgram.TabIndex = 73;
            this.lkUpTargetProgram.EditValueChanged += new System.EventHandler(this.lkUpTargetProgram_EditValueChanged);
            // 
            // txtProjectSize
            // 
            this.txtProjectSize.Location = new System.Drawing.Point(151, 300);
            this.txtProjectSize.Name = "txtProjectSize";
            this.txtProjectSize.Size = new System.Drawing.Size(462, 20);
            this.txtProjectSize.TabIndex = 82;
            this.txtProjectSize.Visible = false;
            this.txtProjectSize.EditValueChanged += new System.EventHandler(this.txtProjectSize_EditValueChanged);
            // 
            // lkuBankAccount
            // 
            this.lkuBankAccount.Location = new System.Drawing.Point(151, 152);
            this.lkuBankAccount.Name = "lkuBankAccount";
            this.lkuBankAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lkuBankAccount.Properties.NullText = "";
            this.lkuBankAccount.Size = new System.Drawing.Size(132, 20);
            this.lkuBankAccount.TabIndex = 75;
            this.lkuBankAccount.EditValueChanged += new System.EventHandler(this.lkuBankAccount_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 303);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(84, 13);
            this.labelControl6.TabIndex = 90;
            this.labelControl6.Text = "Quy mô xây d?ng";
            this.labelControl6.Visible = false;
            this.labelControl6.Click += new System.EventHandler(this.labelControl6_Click);
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(11, 277);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(90, 13);
            this.labelControl18.TabIndex = 86;
            this.labelControl18.Text = "Ð?a di?m xây d?ng";
            this.labelControl18.Visible = false;
            this.labelControl18.Click += new System.EventHandler(this.labelControl18_Click);
            // 
            // txtBuildLacation
            // 
            this.txtBuildLacation.Location = new System.Drawing.Point(151, 274);
            this.txtBuildLacation.Name = "txtBuildLacation";
            this.txtBuildLacation.Size = new System.Drawing.Size(462, 20);
            this.txtBuildLacation.TabIndex = 81;
            this.txtBuildLacation.Visible = false;
            this.txtBuildLacation.EditValueChanged += new System.EventHandler(this.txtBuildLacation_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 199);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(79, 13);
            this.labelControl5.TabIndex = 89;
            this.labelControl5.Text = "Ðon v? th?c hi?n";
            this.labelControl5.Visible = false;
            this.labelControl5.Click += new System.EventHandler(this.labelControl5_Click);
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(11, 252);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(130, 13);
            this.labelControl15.TabIndex = 85;
            this.labelControl15.Text = "T?ng s? kinh phí du?c duy?t";
            this.labelControl15.Visible = false;
            this.labelControl15.Click += new System.EventHandler(this.labelControl15_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 151);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 13);
            this.labelControl4.TabIndex = 88;
            this.labelControl4.Text = "Số tài khoản ngân hàng";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(11, 226);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(107, 13);
            this.labelControl14.TabIndex = 84;
            this.labelControl14.Text = "C?p quy?t d?nh d?u tu";
            this.labelControl14.Visible = false;
            this.labelControl14.Click += new System.EventHandler(this.labelControl14_Click);
            // 
            // txtInvestmentClass
            // 
            this.txtInvestmentClass.Location = new System.Drawing.Point(151, 223);
            this.txtInvestmentClass.Name = "txtInvestmentClass";
            this.txtInvestmentClass.Size = new System.Drawing.Size(462, 20);
            this.txtInvestmentClass.TabIndex = 78;
            this.txtInvestmentClass.Visible = false;
            this.txtInvestmentClass.EditValueChanged += new System.EventHandler(this.txtInvestmentClass_EditValueChanged);
            // 
            // txtProjectNumber
            // 
            this.txtProjectNumber.Location = new System.Drawing.Point(151, 171);
            this.txtProjectNumber.Name = "txtProjectNumber";
            this.txtProjectNumber.Size = new System.Drawing.Size(462, 20);
            this.txtProjectNumber.TabIndex = 72;
            this.txtProjectNumber.Visible = false;
            this.txtProjectNumber.EditValueChanged += new System.EventHandler(this.txtProjectNumber_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 169);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 87;
            this.labelControl1.Text = "S? hi?u d? án";
            this.labelControl1.Visible = false;
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtInvest
            // 
            this.txtInvest.Location = new System.Drawing.Point(151, 121);
            this.txtInvest.Name = "txtInvest";
            this.txtInvest.Size = new System.Drawing.Size(462, 20);
            this.txtInvest.TabIndex = 68;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(11, 124);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(71, 13);
            this.labelControl10.TabIndex = 71;
            this.labelControl10.Text = "Chủ đầu tư (*)";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(289, 98);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(84, 13);
            this.labelControl11.TabIndex = 70;
            this.labelControl11.Text = "Ngày kết thúc (*)";
            // 
            // dateFinishDate
            // 
            this.dateFinishDate.EditValue = null;
            this.dateFinishDate.Location = new System.Drawing.Point(378, 93);
            this.dateFinishDate.Name = "dateFinishDate";
            this.dateFinishDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinishDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateFinishDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateFinishDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFinishDate.Size = new System.Drawing.Size(235, 20);
            this.dateFinishDate.TabIndex = 67;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(11, 98);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(82, 13);
            this.labelControl12.TabIndex = 69;
            this.labelControl12.Text = "Ngày bắt đầu (*)";
            // 
            // dateStartDate
            // 
            this.dateStartDate.EditValue = null;
            this.dateStartDate.Location = new System.Drawing.Point(151, 95);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStartDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStartDate.Size = new System.Drawing.Size(132, 20);
            this.dateStartDate.TabIndex = 66;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(151, 41);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(462, 20);
            this.txtProjectName.TabIndex = 64;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(11, 46);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(66, 13);
            this.labelControl13.TabIndex = 65;
            this.labelControl13.Text = "Tên dự án (*)";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(151, 15);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(132, 20);
            this.txtProjectCode.TabIndex = 63;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(11, 21);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(62, 13);
            this.labelControl16.TabIndex = 62;
            this.labelControl16.Text = "Mã dự án (*)";
            // 
            // tabBank
            // 
            this.tabBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.tabBank.Controls.Add(this.grdBank);
            this.tabBank.Location = new System.Drawing.Point(4, 22);
            this.tabBank.Name = "tabBank";
            this.tabBank.Padding = new System.Windows.Forms.Padding(3);
            this.tabBank.Size = new System.Drawing.Size(630, 151);
            this.tabBank.TabIndex = 1;
            this.tabBank.Text = "Tài khoản ngân hàng - kho bạc";
            // 
            // grdBank
            // 
            this.grdBank.DataSource = this.bindingSourceDetail;
            this.grdBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBank.Location = new System.Drawing.Point(3, 3);
            this.grdBank.MainView = this.grdBankView;
            this.grdBank.Name = "grdBank";
            this.grdBank.Size = new System.Drawing.Size(624, 145);
            this.grdBank.TabIndex = 5;
            this.grdBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBankView});
            // 
            // grdBankView
            // 
            this.grdBankView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdBankView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdBankView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdBankView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.grdBankView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdBankView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdBankView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdBankView.FixedLineWidth = 1;
            this.grdBankView.GridControl = this.grdBank;
            this.grdBankView.Name = "grdBankView";
            this.grdBankView.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.grdBankView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdBankView.OptionsBehavior.FocusLeaveOnTab = true;
            this.grdBankView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdBankView.OptionsView.ColumnAutoWidth = false;
            this.grdBankView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdBankView.OptionsView.ShowFooter = true;
            this.grdBankView.OptionsView.ShowGroupPanel = false;
            this.grdBankView.OptionsView.ShowIndicator = false;
            this.grdBankView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdAccountingView_InitNewRow);
            this.grdBankView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdBankView_CellValueChanged);
            this.grdBankView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnGrid_Mag_MouseUp);
            // 
            // FrmProjectDetail
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 259);
            this.ComponentName = "Dự án";
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2020, 6, 17, 11, 59, 7, 703);
            this.FormCaption = "Dự án";
            this.Name = "FrmProjectDetail";
            this.Reference = "THÊM DỰ ÁN - ID ";
            this.TableCode = "Project";
            this.Text = "FrmProjectDetail";
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabInformation.ResumeLayout(false);
            this.tabInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lukExecutionUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtxBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcTotalAmountApproved.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpTargetProgram.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuildLacation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvestmentClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinishDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinishDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectCode.Properties)).EndInit();
            this.tabBank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBankView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInformation;
        private DevExpress.XtraEditors.TextEdit txtInvest;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DateEdit dateFinishDate;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.DateEdit dateStartDate;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtProjectCode;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.TabPage tabBank;
        public DevExpress.XtraEditors.SimpleButton btnEstimateDetail;
        private DevExpress.XtraEditors.LookUpEdit lukExecutionUnit;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtxBankName;
        private DevExpress.XtraEditors.TextEdit txtTargetProjectName;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.CalcEdit calcTotalAmountApproved;
        private DevExpress.XtraEditors.LookUpEdit lkUpTargetProgram;
        private DevExpress.XtraEditors.TextEdit txtProjectSize;
        private DevExpress.XtraEditors.LookUpEdit lkuBankAccount;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtBuildLacation;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtInvestmentClass;
        private DevExpress.XtraEditors.TextEdit txtProjectNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        protected DevExpress.XtraGrid.GridControl grdBank;
        protected DevExpress.XtraGrid.Views.Grid.GridView grdBankView;
        protected System.Windows.Forms.BindingSource bindingSourceDetail; 

    }
}