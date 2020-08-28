namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{
    internal partial class FrmTargetProgram
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
            this.txtProjectCode = new DevExpress.XtraEditors.TextEdit();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.lbFullName = new DevExpress.XtraEditors.LabelControl();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lukTargetProgram = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lukTargetProgram.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.lukTargetProgram);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtProjectName);
            this.groupboxMain.Controls.Add(this.lbFullName);
            this.groupboxMain.Controls.Add(this.txtProjectCode);
            this.groupboxMain.Controls.Add(this.lbCode);
            this.groupboxMain.Location = new System.Drawing.Point(8, 2);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(471, 105);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(335, 136);
            this.btnSave.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(409, 136);
            this.btnExit.TabIndex = 6;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 136);
            this.btnHelp.TabIndex = 7;
            // 
            // lbCode
            // 
            this.lbCode.Location = new System.Drawing.Point(8, 28);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(61, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Mã CTMT (*)";
            this.lbCode.ToolTip = "Mã chương trình mục tiêu";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(76, 25);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(175, 20);
            this.txtProjectCode.TabIndex = 1;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(76, 51);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(390, 20);
            this.txtProjectName.TabIndex = 2;
            // 
            // lbFullName
            // 
            this.lbFullName.Location = new System.Drawing.Point(8, 55);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(65, 13);
            this.lbFullName.TabIndex = 4;
            this.lbFullName.Text = "Tên CTMT (*)";
            this.lbFullName.ToolTip = "Tên chương trình mục tiêu";
            // 
            // cbIsActive
            // 
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(6, 112);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(96, 19);
            this.cbIsActive.TabIndex = 4;
            this.cbIsActive.CheckedChanged += new System.EventHandler(this.cbIsActive_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Thuộc CTMT";
            this.labelControl1.ToolTip = "Thuộc chương trình mục tiêu";
            // 
            // lukTargetProgram
            // 
            this.lukTargetProgram.Location = new System.Drawing.Point(76, 77);
            this.lukTargetProgram.Name = "lukTargetProgram";
            this.lukTargetProgram.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lukTargetProgram.Properties.NullText = "";
            this.lukTargetProgram.Size = new System.Drawing.Size(390, 20);
            this.lukTargetProgram.TabIndex = 7;
            this.lukTargetProgram.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lukTargetProgram_ButtonClick);
            // 
            // FrmTargetProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 166);
            this.ComponentName = "Chương trình mục tiêu";
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2019, 10, 9, 15, 5, 50, 286);
            this.FormCaption = "Chương trình mục tiêu";
            this.Name = "FrmTargetProgram";
            this.Reference = "THÊM CHƯƠNG TRÌNH MỤC TIÊU - ID ";
            this.TableCode = "Project";
            this.Text = "FrmTargetProgram";
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lukTargetProgram.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.LabelControl lbCode;
        private DevExpress.XtraEditors.TextEdit txtProjectCode;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.LabelControl lbFullName;
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lukTargetProgram;
    }
}