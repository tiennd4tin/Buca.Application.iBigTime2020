namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmB01KB_Param
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.txtTGTTN = new System.Windows.Forms.TextBox();
            this.txtTBHNN = new System.Windows.Forms.TextBox();
            this.txtTBHTN = new System.Windows.Forms.TextBox();
            this.txtTGTNN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource();
            this.tabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(294, 198);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 98;
            this.btnExport.Text = "Hủy bỏ";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(202, 198);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 25);
            this.simpleButton1.TabIndex = 99;
            this.simpleButton1.Text = "Đồng ý";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Location = new System.Drawing.Point(3, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(371, 175);
            this.tabControl1.TabIndex = 102;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.txtTGTTN);
            this.tabInfo.Controls.Add(this.txtTBHNN);
            this.tabInfo.Controls.Add(this.txtTBHTN);
            this.tabInfo.Controls.Add(this.txtTGTNN);
            this.tabInfo.Controls.Add(this.label6);
            this.tabInfo.Controls.Add(this.label5);
            this.tabInfo.Controls.Add(this.label4);
            this.tabInfo.Controls.Add(this.label3);
            this.tabInfo.Controls.Add(this.label2);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(363, 149);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Thông tin chung";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // txtTGTTN
            // 
            this.txtTGTTN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTGTTN.Location = new System.Drawing.Point(103, 67);
            this.txtTGTTN.Multiline = true;
            this.txtTGTTN.Name = "txtTGTTN";
            this.txtTGTTN.Size = new System.Drawing.Size(139, 28);
            this.txtTGTTN.TabIndex = 112;
            this.txtTGTTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTGTTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyDown);
            this.txtTGTTN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormatNumber_KeyPress);
            this.txtTGTTN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyUp);
            // 
            // txtTBHNN
            // 
            this.txtTBHNN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTBHNN.Location = new System.Drawing.Point(241, 94);
            this.txtTBHNN.Multiline = true;
            this.txtTBHNN.Name = "txtTBHNN";
            this.txtTBHNN.Size = new System.Drawing.Size(116, 27);
            this.txtTBHNN.TabIndex = 110;
            this.txtTBHNN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTBHNN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyDown);
            this.txtTBHNN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormatNumber_KeyPress);
            this.txtTBHNN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyUp);
            // 
            // txtTBHTN
            // 
            this.txtTBHTN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTBHTN.Location = new System.Drawing.Point(241, 67);
            this.txtTBHTN.Multiline = true;
            this.txtTBHTN.Name = "txtTBHTN";
            this.txtTBHTN.Size = new System.Drawing.Size(116, 28);
            this.txtTBHTN.TabIndex = 109;
            this.txtTBHTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTBHTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyDown);
            this.txtTBHTN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormatNumber_KeyPress);
            this.txtTBHTN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyUp);
            // 
            // txtTGTNN
            // 
            this.txtTGTNN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTGTNN.Location = new System.Drawing.Point(103, 94);
            this.txtTGTNN.Multiline = true;
            this.txtTGTNN.Name = "txtTGTNN";
            this.txtTGTNN.Size = new System.Drawing.Size(139, 27);
            this.txtTGTNN.TabIndex = 108;
            this.txtTGTNN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTGTNN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyDown);
            this.txtTGTNN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormatNumber_KeyPress);
            this.txtTGTNN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormatNumber_KeyUp);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 27);
            this.label6.TabIndex = 106;
            this.label6.Text = "Vốn ngoài nước";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 28);
            this.label5.TabIndex = 105;
            this.label5.Text = "Vốn trong nước";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 30);
            this.label4.TabIndex = 104;
            this.label4.Text = "Tiền bảo hành";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 30);
            this.label3.TabIndex = 103;
            this.label3.Text = "Thuế GTGT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 30);
            this.label2.TabIndex = 102;
            // 
            // FrmB01KB_Param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 235);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnExport);
            this.Name = "FrmB01KB_Param";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tham số báo cáo";
            this.tabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btnExport;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfo;
        protected System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.TextBox txtTBHNN;
        private System.Windows.Forms.TextBox txtTBHTN;
        private System.Windows.Forms.TextBox txtTGTNN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTGTTN;
    }
}