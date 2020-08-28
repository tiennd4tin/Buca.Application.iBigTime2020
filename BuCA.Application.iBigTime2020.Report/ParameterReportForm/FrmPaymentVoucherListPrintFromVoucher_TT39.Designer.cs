namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmPaymentVoucherListPrintFromVoucher_TT39
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
            this.checkNotShowDateAndRefNo = new System.Windows.Forms.CheckBox();
            this.checkCurenRefNo = new System.Windows.Forms.CheckBox();
            this.checkReContentInPage = new System.Windows.Forms.CheckBox();
            this.checkPrintDateVoucher = new System.Windows.Forms.CheckBox();
            this.gridDetailTT39 = new DevExpress.XtraGrid.GridControl();
            this.ListBindingSource = new System.Windows.Forms.BindingSource();
            this.gridDetailViewTT39 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEvictionNumber = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailTT39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailViewTT39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvictionNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.txtEvictionNumber);
            this.groupboxMain.Controls.Add(this.label2);
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Controls.Add(this.txtSourceCode);
            this.groupboxMain.Controls.Add(this.checkCurenRefNo);
            this.groupboxMain.Controls.Add(this.checkNotShowDateAndRefNo);
            this.groupboxMain.Controls.Add(this.checkReContentInPage);
            this.groupboxMain.Controls.Add(this.checkPrintDateVoucher);
            this.groupboxMain.Location = new System.Drawing.Point(8, 4);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(534, 103);
            this.groupboxMain.Text = "Tùy chọn in";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(386, 370);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(467, 370);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 370);
            // 
            // checkNotShowDateAndRefNo
            // 
            this.checkNotShowDateAndRefNo.AutoSize = true;
            this.checkNotShowDateAndRefNo.Location = new System.Drawing.Point(8, 48);
            this.checkNotShowDateAndRefNo.Name = "checkNotShowDateAndRefNo";
            this.checkNotShowDateAndRefNo.Size = new System.Drawing.Size(204, 17);
            this.checkNotShowDateAndRefNo.TabIndex = 3;
            this.checkNotShowDateAndRefNo.Text = "Không hiển thị cột ngày, số chứng từ";
            this.checkNotShowDateAndRefNo.UseVisualStyleBackColor = true;
            // 
            // checkCurenRefNo
            // 
            this.checkCurenRefNo.AutoSize = true;
            this.checkCurenRefNo.Location = new System.Drawing.Point(218, 48);
            this.checkCurenRefNo.Name = "checkCurenRefNo";
            this.checkCurenRefNo.Size = new System.Drawing.Size(315, 17);
            this.checkCurenRefNo.TabIndex = 2;
            this.checkCurenRefNo.Text = "Không hiển thị cột ngày, số chứng từ khi có số chứng từ gốc";
            this.checkCurenRefNo.UseVisualStyleBackColor = true;
            // 
            // checkReContentInPage
            // 
            this.checkReContentInPage.AutoSize = true;
            this.checkReContentInPage.Location = new System.Drawing.Point(218, 28);
            this.checkReContentInPage.Name = "checkReContentInPage";
            this.checkReContentInPage.Size = new System.Drawing.Size(199, 17);
            this.checkReContentInPage.TabIndex = 2;
            this.checkReContentInPage.Text = "Lặp lại tiêu đề và chữ ký ở mỗi trang";
            this.checkReContentInPage.UseVisualStyleBackColor = true;
            // 
            // checkPrintDateVoucher
            // 
            this.checkPrintDateVoucher.AutoSize = true;
            this.checkPrintDateVoucher.Location = new System.Drawing.Point(139, 28);
            this.checkPrintDateVoucher.Name = "checkPrintDateVoucher";
            this.checkPrintDateVoucher.Size = new System.Drawing.Size(46, 17);
            this.checkPrintDateVoucher.TabIndex = 0;
            this.checkPrintDateVoucher.Text = "NCT";
            this.checkPrintDateVoucher.UseVisualStyleBackColor = true;
            // 
            // gridDetailTT39
            // 
            this.gridDetailTT39.DataSource = this.ListBindingSource;
            this.gridDetailTT39.Location = new System.Drawing.Point(4, 113);
            this.gridDetailTT39.MainView = this.gridDetailViewTT39;
            this.gridDetailTT39.Name = "gridDetailTT39";
            this.gridDetailTT39.Size = new System.Drawing.Size(534, 251);
            this.gridDetailTT39.TabIndex = 1;
            this.gridDetailTT39.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDetailViewTT39});
            // 
            // gridDetailViewTT39
            // 
            this.gridDetailViewTT39.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridDetailViewTT39.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDetailViewTT39.GridControl = this.gridDetailTT39;
            this.gridDetailViewTT39.GroupPanelText = "\"\"";
            this.gridDetailViewTT39.Name = "gridDetailViewTT39";
            this.gridDetailViewTT39.OptionsView.ColumnAutoWidth = false;
            this.gridDetailViewTT39.OptionsView.ShowGroupPanel = false;
            this.gridDetailViewTT39.OptionsView.ShowIndicator = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(89, 370);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 96;
            this.btnExport.Text = "Xuất XML";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Location = new System.Drawing.Point(69, 26);
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.Size = new System.Drawing.Size(132, 21);
            this.txtSourceCode.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã nguồn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số thu hồi:";
            // 
            // txtEvictionNumber
            // 
            this.txtEvictionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEvictionNumber.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtEvictionNumber.Location = new System.Drawing.Point(69, 71);
            this.txtEvictionNumber.Name = "txtEvictionNumber";
            this.txtEvictionNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtEvictionNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtEvictionNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEvictionNumber.Properties.Mask.BeepOnError = true;
            this.txtEvictionNumber.Properties.Mask.EditMask = "n0";
            this.txtEvictionNumber.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEvictionNumber.Size = new System.Drawing.Size(132, 20);
            this.txtEvictionNumber.TabIndex = 8;
            this.txtEvictionNumber.Tag = "";
            // 
            // FrmPaymentVoucherListPrintFromVoucher_TT39
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 404);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gridDetailTT39);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPaymentVoucherListPrintFromVoucher_TT39";
            this.Load += new System.EventHandler(this.FrmPaymentVoucherListPrintFromVoucher_TT39_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.gridDetailTT39, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailTT39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailViewTT39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvictionNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkPrintDateVoucher;
        private System.Windows.Forms.CheckBox checkNotShowDateAndRefNo;
        private System.Windows.Forms.CheckBox checkCurenRefNo;
        private System.Windows.Forms.CheckBox checkReContentInPage;
        private DevExpress.XtraGrid.GridControl gridDetailTT39;
        public System.Windows.Forms.BindingSource ListBindingSource;
        public DevExpress.XtraGrid.Views.Grid.GridView gridDetailViewTT39;
        public DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.CalcEdit txtEvictionNumber;
    }
}