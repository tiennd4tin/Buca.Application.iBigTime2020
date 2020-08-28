namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Activity
{
    internal partial class FrmActivityDetail
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
            this.lbType = new DevExpress.XtraEditors.LabelControl();
            this.lbFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtCareerWorkCode = new DevExpress.XtraEditors.TextEdit();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtCareerWorkName = new DevExpress.XtraEditors.TextEdit();
            this.lukParentID = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCareerWorkCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCareerWorkName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lukParentID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 113);
            this.btnSave.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(411, 113);
            this.btnExit.TabIndex = 6;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 113);
            this.btnHelp.TabIndex = 7;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.lukParentID);
            this.groupboxMain.Controls.Add(this.txtCareerWorkName);
            this.groupboxMain.Controls.Add(this.txtCareerWorkCode);
            this.groupboxMain.Controls.Add(this.lbFullName);
            this.groupboxMain.Controls.Add(this.lbType);
            this.groupboxMain.Controls.Add(this.lbCode);
            this.groupboxMain.Location = new System.Drawing.Point(10, 0);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(471, 77);
            // 
            // btnPrintFixAsset
            // 
            this.btnPrintFixAsset.Location = new System.Drawing.Point(84, 218);
            // 
            // lbCode
            // 
            this.lbCode.Location = new System.Drawing.Point(9, 28);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(76, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Mã công việc(*)";
            // 
            // lbType
            // 
            this.lbType.Location = new System.Drawing.Point(9, 52);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(80, 13);
            this.lbType.TabIndex = 2;
            this.lbType.Text = "Tên công việc(*)";
            // 
            // lbFullName
            // 
            this.lbFullName.Location = new System.Drawing.Point(9, 76);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(97, 13);
            this.lbFullName.TabIndex = 4;
            this.lbFullName.Text = "Thuộc hoạt động SN";
            this.lbFullName.Visible = false;
            // 
            // txtCareerWorkCode
            // 
            this.txtCareerWorkCode.Location = new System.Drawing.Point(114, 24);
            this.txtCareerWorkCode.Name = "txtCareerWorkCode";
            this.txtCareerWorkCode.Size = new System.Drawing.Size(168, 20);
            this.txtCareerWorkCode.TabIndex = 1;
            // 
            // cbIsActive
            // 
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(6, 87);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(96, 19);
            this.cbIsActive.TabIndex = 4;
            // 
            // txtCareerWorkName
            // 
            this.txtCareerWorkName.Location = new System.Drawing.Point(114, 49);
            this.txtCareerWorkName.Name = "txtCareerWorkName";
            this.txtCareerWorkName.Size = new System.Drawing.Size(350, 20);
            this.txtCareerWorkName.TabIndex = 2;
            // 
            // lukParentID
            // 
            this.lukParentID.Location = new System.Drawing.Point(114, 74);
            this.lukParentID.Name = "lukParentID";
            this.lukParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lukParentID.Properties.NullText = "";
            this.lukParentID.Size = new System.Drawing.Size(350, 20);
            this.lukParentID.TabIndex = 3;
            this.lukParentID.Visible = false;
            this.lukParentID.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lukParentID_ButtonClick);
            // 
            // FrmActivityDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 144);
            this.ComponentName = "Công việc";
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2020, 7, 1, 8, 5, 23, 379);
            this.FormCaption = "Công việc";
            this.Name = "FrmActivityDetail";
            this.Reference = "THÊM CÔNG VIỆC - ID ";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtCareerWorkCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCareerWorkName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lukParentID.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.LabelControl lbCode;
        private DevExpress.XtraEditors.LabelControl lbType;
        private DevExpress.XtraEditors.TextEdit txtCareerWorkCode;
        private DevExpress.XtraEditors.LabelControl lbFullName;
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.TextEdit txtCareerWorkName;
        private DevExpress.XtraEditors.LookUpEdit lukParentID;
    }
}