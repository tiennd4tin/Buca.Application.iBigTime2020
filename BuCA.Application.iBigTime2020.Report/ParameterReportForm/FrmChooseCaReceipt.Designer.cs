﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    partial class FrmChooseCaReceipt
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
            this.groupboxMain = new DevExpress.XtraEditors.GroupControl();
            this.groupVoucher = new DevExpress.XtraEditors.GroupControl();
            this.grdCAReceipt = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceBUCommitment = new System.Windows.Forms.BindingSource();
            this.grdCAReceiptView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCAReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBUCommitment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCAReceiptView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.groupVoucher);
            this.groupboxMain.Location = new System.Drawing.Point(5, 6);
            this.groupboxMain.Name = "groupboxMain";
            this.groupboxMain.ShowCaption = false;
            this.groupboxMain.Size = new System.Drawing.Size(835, 404);
            this.groupboxMain.TabIndex = 5;
            // 
            // groupVoucher
            // 
            this.groupVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupVoucher.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupVoucher.AppearanceCaption.Options.UseFont = true;
            this.groupVoucher.Controls.Add(this.grdCAReceipt);
            this.groupVoucher.Location = new System.Drawing.Point(7, 6);
            this.groupVoucher.Name = "groupVoucher";
            this.groupVoucher.Size = new System.Drawing.Size(820, 393);
            this.groupVoucher.TabIndex = 44;
            this.groupVoucher.Text = "Chọn khoản thu";
            // 
            // grdCAReceipt
            // 
            this.grdCAReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCAReceipt.DataSource = this.bindingSourceBUCommitment;
            this.grdCAReceipt.Location = new System.Drawing.Point(2, 21);
            this.grdCAReceipt.MainView = this.grdCAReceiptView;
            this.grdCAReceipt.Name = "grdCAReceipt";
            this.grdCAReceipt.Size = new System.Drawing.Size(816, 370);
            this.grdCAReceipt.TabIndex = 6;
            this.grdCAReceipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdCAReceiptView});
            // 
            // grdCAReceiptView
            // 
            this.grdCAReceiptView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdCAReceiptView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCAReceiptView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdCAReceiptView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.grdCAReceiptView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdCAReceiptView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdCAReceiptView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdCAReceiptView.FixedLineWidth = 1;
            this.grdCAReceiptView.GridControl = this.grdCAReceipt;
            this.grdCAReceiptView.Name = "grdCAReceiptView";
            this.grdCAReceiptView.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.grdCAReceiptView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdCAReceiptView.OptionsBehavior.FocusLeaveOnTab = true;
            this.grdCAReceiptView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdCAReceiptView.OptionsView.ColumnAutoWidth = false;
            this.grdCAReceiptView.OptionsView.ShowGroupPanel = false;
            this.grdCAReceiptView.OptionsView.ShowIndicator = false;
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
            // FrmChooseCaReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 453);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupboxMain);
            this.Name = "FrmChooseCaReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn phiếu thu";
            this.Load += new System.EventHandler(this.FrmChooseCaReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCAReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBUCommitment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCAReceiptView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl groupboxMain;
        public DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        protected DevExpress.XtraEditors.GroupControl groupVoucher;
        protected DevExpress.XtraGrid.GridControl grdCAReceipt;
        protected DevExpress.XtraGrid.Views.Grid.GridView grdCAReceiptView;
        private System.Windows.Forms.BindingSource bindingSourceBUCommitment;
    }
}