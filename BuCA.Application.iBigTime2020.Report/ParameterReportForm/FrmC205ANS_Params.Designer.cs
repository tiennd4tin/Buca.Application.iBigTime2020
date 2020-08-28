namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmC205ANS_Params
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
            this.bindingSource = new System.Windows.Forms.BindingSource();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.txtDecisionDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDecisionNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCtmtDa = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtCkcHdth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodeCtmtDa = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCkcHdk = new DevExpress.XtraEditors.TextEdit();
            this.lblAcount = new DevExpress.XtraEditors.LabelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCtmtDa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCkcHdth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeCtmtDa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCkcHdk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Location = new System.Drawing.Point(248, 304);
            this.groupboxMain.Size = new System.Drawing.Size(35, 62);
            this.groupboxMain.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(371, 237);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(452, 237);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 237);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(109, 237);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Xuất XML";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtDecisionDate);
            this.tabGeneral.Controls.Add(this.labelControl3);
            this.tabGeneral.Controls.Add(this.txtDecisionNo);
            this.tabGeneral.Controls.Add(this.labelControl2);
            this.tabGeneral.Controls.Add(this.txtCtmtDa);
            this.tabGeneral.Controls.Add(this.labelControl9);
            this.tabGeneral.Controls.Add(this.txtCkcHdth);
            this.tabGeneral.Controls.Add(this.labelControl4);
            this.tabGeneral.Controls.Add(this.txtCodeCtmtDa);
            this.tabGeneral.Controls.Add(this.labelControl1);
            this.tabGeneral.Controls.Add(this.txtCkcHdk);
            this.tabGeneral.Controls.Add(this.lblAcount);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(512, 198);
            this.tabGeneral.Text = "Thông tin chung";
            // 
            // txtDecisionDate
            // 
            this.txtDecisionDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecisionDate.CausesValidation = false;
            this.txtDecisionDate.EditValue = null;
            this.txtDecisionDate.Location = new System.Drawing.Point(150, 141);
            this.txtDecisionDate.MaximumSize = new System.Drawing.Size(338, 20);
            this.txtDecisionDate.Name = "txtDecisionDate";
            this.txtDecisionDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDecisionDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDecisionDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDecisionDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDecisionDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDecisionDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDecisionDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDecisionDate.Size = new System.Drawing.Size(338, 20);
            this.txtDecisionDate.TabIndex = 25;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 144);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Ngày";
            this.labelControl3.ToolTip = "Số tờ khai/ Quyết định/ Thông báo";
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.Location = new System.Drawing.Point(150, 112);
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.Size = new System.Drawing.Size(338, 20);
            this.txtDecisionNo.TabIndex = 22;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 118);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 21;
            this.labelControl2.Text = "Quyết định số";
            this.labelControl2.ToolTip = "Số tờ khai/ Quyết định/ Thông báo";
            // 
            // txtCtmtDa
            // 
            this.txtCtmtDa.Location = new System.Drawing.Point(150, 8);
            this.txtCtmtDa.Name = "txtCtmtDa";
            this.txtCtmtDa.Size = new System.Drawing.Size(338, 20);
            this.txtCtmtDa.TabIndex = 20;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(10, 11);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(69, 13);
            this.labelControl9.TabIndex = 19;
            this.labelControl9.Text = "Tên CTMT, DA";
            // 
            // txtCkcHdth
            // 
            this.txtCkcHdth.Location = new System.Drawing.Point(150, 86);
            this.txtCkcHdth.Name = "txtCkcHdth";
            this.txtCkcHdth.Size = new System.Drawing.Size(338, 20);
            this.txtCkcHdth.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 92);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Số CKC, HĐTH";
            this.labelControl4.ToolTip = "Số tờ khai/ Quyết định/ Thông báo";
            // 
            // txtCodeCtmtDa
            // 
            this.txtCodeCtmtDa.Location = new System.Drawing.Point(150, 60);
            this.txtCodeCtmtDa.Name = "txtCodeCtmtDa";
            this.txtCodeCtmtDa.Size = new System.Drawing.Size(338, 20);
            this.txtCodeCtmtDa.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Mã CTMT, DA";
            // 
            // txtCkcHdk
            // 
            this.txtCkcHdk.Location = new System.Drawing.Point(150, 34);
            this.txtCkcHdk.Name = "txtCkcHdk";
            this.txtCkcHdk.Size = new System.Drawing.Size(338, 20);
            this.txtCkcHdk.TabIndex = 1;
            // 
            // lblAcount
            // 
            this.lblAcount.Location = new System.Drawing.Point(10, 38);
            this.lblAcount.Name = "lblAcount";
            this.lblAcount.Size = new System.Drawing.Size(63, 13);
            this.lblAcount.TabIndex = 0;
            this.lblAcount.Text = "Số CKC, HĐK";
            this.lblAcount.Click += new System.EventHandler(this.lblAcount_Click);
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(8, 8);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tabGeneral;
            this.tabMain.Size = new System.Drawing.Size(514, 223);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabGeneral});
            // 
            // FrmC205ANS_Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 269);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmC205ANS_Params";
            this.Text = "Tham số";
            this.Load += new System.EventHandler(this.FrmC205ANS_Params_Load);
            this.Controls.SetChildIndex(this.tabMain, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCtmtDa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCkcHdth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeCtmtDa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCkcHdk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource;
        public DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabPage tabGeneral;
        private DevExpress.XtraEditors.TextEdit txtCtmtDa;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtCkcHdth;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCodeCtmtDa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCkcHdk;
        private DevExpress.XtraEditors.LabelControl lblAcount;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDecisionNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtDecisionDate;
    }
}