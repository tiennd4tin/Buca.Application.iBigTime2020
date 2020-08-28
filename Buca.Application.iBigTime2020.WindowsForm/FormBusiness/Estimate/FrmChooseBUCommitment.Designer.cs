namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    partial class FrmChooseBUCommitment
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
            this.groupboxMain = new DevExpress.XtraEditors.GroupControl();
            this.lookupBUCommitment = new DevExpress.XtraEditors.LookUpEdit();
            this.groupVoucher = new DevExpress.XtraEditors.GroupControl();
            this.grdBUCommitment = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceBUCommitment = new System.Windows.Forms.BindingSource(this.components);
            this.grdBUCommitmentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBUCommitment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBUCommitment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBUCommitment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBUCommitmentView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.lookupBUCommitment);
            this.groupboxMain.Controls.Add(this.groupVoucher);
            this.groupboxMain.Controls.Add(this.labelControl12);
            this.groupboxMain.Location = new System.Drawing.Point(5, 6);
            this.groupboxMain.Name = "groupboxMain";
            this.groupboxMain.ShowCaption = false;
            this.groupboxMain.Size = new System.Drawing.Size(835, 404);
            this.groupboxMain.TabIndex = 5;
            // 
            // lookupBUCommitment
            // 
            this.lookupBUCommitment.EditValue = "";
            this.lookupBUCommitment.Location = new System.Drawing.Point(111, 9);
            this.lookupBUCommitment.Name = "lookupBUCommitment";
            this.lookupBUCommitment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookupBUCommitment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupBUCommitment.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.lookupBUCommitment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.lookupBUCommitment.Properties.NullText = "";
            this.lookupBUCommitment.Properties.PopupSizeable = false;
            this.lookupBUCommitment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupBUCommitment.Size = new System.Drawing.Size(374, 20);
            this.lookupBUCommitment.TabIndex = 45;
            this.lookupBUCommitment.EditValueChanged += new System.EventHandler(this.lookupBUCommitment_EditValueChanged);
            // 
            // groupVoucher
            // 
            this.groupVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupVoucher.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupVoucher.AppearanceCaption.Options.UseFont = true;
            this.groupVoucher.Controls.Add(this.grdBUCommitment);
            this.groupVoucher.Location = new System.Drawing.Point(7, 38);
            this.groupVoucher.Name = "groupVoucher";
            this.groupVoucher.Size = new System.Drawing.Size(820, 361);
            this.groupVoucher.TabIndex = 44;
            this.groupVoucher.Text = "Chi tiết cam kết chi còn lại";
            // 
            // grdBUCommitment
            // 
            this.grdBUCommitment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBUCommitment.DataSource = this.bindingSourceBUCommitment;
            this.grdBUCommitment.Location = new System.Drawing.Point(2, 21);
            this.grdBUCommitment.MainView = this.grdBUCommitmentView;
            this.grdBUCommitment.Name = "grdBUCommitment";
            this.grdBUCommitment.Size = new System.Drawing.Size(816, 338);
            this.grdBUCommitment.TabIndex = 6;
            this.grdBUCommitment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBUCommitmentView});
            // 
            // grdBUCommitmentView
            // 
            this.grdBUCommitmentView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdBUCommitmentView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdBUCommitmentView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdBUCommitmentView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.grdBUCommitmentView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdBUCommitmentView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdBUCommitmentView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdBUCommitmentView.FixedLineWidth = 1;
            this.grdBUCommitmentView.GridControl = this.grdBUCommitment;
            this.grdBUCommitmentView.Name = "grdBUCommitmentView";
            this.grdBUCommitmentView.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.grdBUCommitmentView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdBUCommitmentView.OptionsBehavior.FocusLeaveOnTab = true;
            this.grdBUCommitmentView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdBUCommitmentView.OptionsView.ColumnAutoWidth = false;
            this.grdBUCommitmentView.OptionsView.ShowGroupPanel = false;
            this.grdBUCommitmentView.OptionsView.ShowIndicator = false;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(7, 12);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(98, 13);
            this.labelControl12.TabIndex = 42;
            this.labelControl12.Text = "Chọn cam kết chi (*)";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(684, 416);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(765, 416);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Hủy bỏ";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Location = new System.Drawing.Point(5, 416);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 25);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // FrmChooseBUCommitment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 453);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupboxMain);
            this.Name = "FrmChooseBUCommitment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn cam kết chi";
            this.Load += new System.EventHandler(this.FrmChooseBUCommitment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBUCommitment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBUCommitment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBUCommitment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBUCommitmentView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl groupboxMain;
        public DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        protected DevExpress.XtraEditors.GroupControl groupVoucher;
        protected DevExpress.XtraGrid.GridControl grdBUCommitment;
        protected DevExpress.XtraGrid.Views.Grid.GridView grdBUCommitmentView;
        private DevExpress.XtraEditors.LookUpEdit lookupBUCommitment;
        private System.Windows.Forms.BindingSource bindingSourceBUCommitment;
    }
}