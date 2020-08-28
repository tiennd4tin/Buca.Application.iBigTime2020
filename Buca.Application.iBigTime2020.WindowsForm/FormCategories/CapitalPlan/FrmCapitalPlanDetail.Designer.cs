namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.CapitalPlan
{
    internal partial class FrmCapitalPlanDetail
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lbCode = new DevExpress.XtraEditors.LabelControl();
            this.lbType = new DevExpress.XtraEditors.LabelControl();
            this.lbFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtCapCode = new DevExpress.XtraEditors.TextEdit();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtCapName = new DevExpress.XtraEditors.TextEdit();
            this.CapYear = new System.Windows.Forms.NumericUpDown();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateStartDate = new DevExpress.XtraEditors.DateEdit();
            this.dateToDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.capTypeId = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capTypeId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 157);
            this.btnSave.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(411, 157);
            this.btnExit.TabIndex = 6;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 157);
            this.btnHelp.TabIndex = 7;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.dateToDate);
            this.groupboxMain.Controls.Add(this.dateStartDate);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.CapYear);
            this.groupboxMain.Controls.Add(this.txtCapName);
            this.groupboxMain.Controls.Add(this.txtCapCode);
            this.groupboxMain.Controls.Add(this.lbFullName);
            this.groupboxMain.Controls.Add(this.lbType);
            this.groupboxMain.Controls.Add(this.lbCode);
            this.groupboxMain.Controls.Add(this.capTypeId);
            this.groupboxMain.Location = new System.Drawing.Point(10, 0);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(471, 129);
            // 
            // btnPrintFixAsset
            // 
            this.btnPrintFixAsset.Location = new System.Drawing.Point(84, 260);
            // 
            // lbCode
            // 
            this.lbCode.Location = new System.Drawing.Point(9, 28);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(68, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Mã KH vốn (*)";
            // 
            // lbType
            // 
            this.lbType.Location = new System.Drawing.Point(9, 52);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(72, 13);
            this.lbType.TabIndex = 2;
            this.lbType.Text = "Tên KH vốn (*)";
            // 
            // lbFullName
            // 
            this.lbFullName.Location = new System.Drawing.Point(252, 76);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(56, 13);
            this.lbFullName.TabIndex = 4;
            this.lbFullName.Text = "Loại KH vốn";
            // 
            // txtCapCode
            // 
            this.txtCapCode.Location = new System.Drawing.Point(98, 22);
            this.txtCapCode.Name = "txtCapCode";
            this.txtCapCode.Size = new System.Drawing.Size(177, 20);
            this.txtCapCode.TabIndex = 1;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(6, 134);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(96, 19);
            this.cbIsActive.TabIndex = 4;
            // 
            // txtCapName
            // 
            this.txtCapName.Location = new System.Drawing.Point(98, 47);
            this.txtCapName.Name = "txtCapName";
            this.txtCapName.Size = new System.Drawing.Size(368, 20);
            this.txtCapName.TabIndex = 2;
            // 
            // CapYear
            // 
            this.CapYear.Location = new System.Drawing.Point(98, 74);
            this.CapYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.CapYear.Name = "CapYear";
            this.CapYear.Size = new System.Drawing.Size(141, 21);
            this.CapYear.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Năm KH vốn";
            // 
            // dateStartDate
            // 
            this.dateStartDate.EditValue = null;
            this.dateStartDate.Location = new System.Drawing.Point(98, 101);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStartDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStartDate.Size = new System.Drawing.Size(141, 20);
            this.dateStartDate.TabIndex = 7;
            // 
            // dateToDate
            // 
            this.dateToDate.EditValue = null;
            this.dateToDate.Location = new System.Drawing.Point(324, 101);
            this.dateToDate.Name = "dateToDate";
            this.dateToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateToDate.Size = new System.Drawing.Size(141, 20);
            this.dateToDate.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Từ ngày";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(252, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Đến ngày";
            // 
            // capTypeId
            // 
            this.capTypeId.Location = new System.Drawing.Point(324, 73);
            this.capTypeId.Name = "capTypeId";
            this.capTypeId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.capTypeId.Properties.PopupSizeable = true;
            this.capTypeId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.capTypeId.Size = new System.Drawing.Size(141, 20);
            this.capTypeId.TabIndex = 3;
            this.capTypeId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lukParentID_ButtonClick);
            // 
            // FrmCapitalPlanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 186);
            this.ComponentName = "Hoạt động sự nghiệp";
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2020, 1, 14, 17, 39, 50, 424);
            this.FormCaption = "Hoạt động sự nghiệp";
            this.Name = "FrmCapitalPlanDetail";
            this.Reference = "THÊM HOẠT ĐỘNG SỰ NGHIỆP - ID ";
            this.TableCode = "CareerWork";
            this.Text = "FrmCareerWorkDetail";
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capTypeId.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.LabelControl lbCode;
        private DevExpress.XtraEditors.LabelControl lbType;
        private DevExpress.XtraEditors.TextEdit txtCapCode;
        private DevExpress.XtraEditors.LabelControl lbFullName;
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.TextEdit txtCapName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.NumericUpDown CapYear;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateToDate;
        private DevExpress.XtraEditors.DateEdit dateStartDate;
        private DevExpress.XtraEditors.ComboBoxEdit capTypeId;
    }
}