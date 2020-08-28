namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate.AutoVoucher
{
    partial class FrmAutoVoucher
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
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.rbt_BUTransfersPayWage = new System.Windows.Forms.RadioButton();
            this.rbt_BUTransfersPayWageBH = new System.Windows.Forms.RadioButton();
            this.bt_ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(17, 60);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(87, 23);
            this.bt_Cancel.TabIndex = 0;
            this.bt_Cancel.Text = "Hủy bỏ";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // rbt_BUTransfersPayWage
            // 
            this.rbt_BUTransfersPayWage.AutoSize = true;
            this.rbt_BUTransfersPayWage.Location = new System.Drawing.Point(14, 30);
            this.rbt_BUTransfersPayWage.Name = "rbt_BUTransfersPayWage";
            this.rbt_BUTransfersPayWage.Size = new System.Drawing.Size(212, 17);
            this.rbt_BUTransfersPayWage.TabIndex = 1;
            this.rbt_BUTransfersPayWage.TabStop = true;
            this.rbt_BUTransfersPayWage.Text = "Sinh chứng từ chuyển khoản trả lương?";
            this.rbt_BUTransfersPayWage.UseVisualStyleBackColor = true;
            this.rbt_BUTransfersPayWage.CheckedChanged += new System.EventHandler(this.rbt_BUTransfersPayWage_CheckedChanged);
            // 
            // rbt_BUTransfersPayWageBH
            // 
            this.rbt_BUTransfersPayWageBH.AutoSize = true;
            this.rbt_BUTransfersPayWageBH.Location = new System.Drawing.Point(15, 67);
            this.rbt_BUTransfersPayWageBH.Name = "rbt_BUTransfersPayWageBH";
            this.rbt_BUTransfersPayWageBH.Size = new System.Drawing.Size(214, 17);
            this.rbt_BUTransfersPayWageBH.TabIndex = 2;
            this.rbt_BUTransfersPayWageBH.TabStop = true;
            this.rbt_BUTransfersPayWageBH.Text = "Sinh chứng từ chuyển khoản bảo hiểm?";
            this.rbt_BUTransfersPayWageBH.UseVisualStyleBackColor = true;
            this.rbt_BUTransfersPayWageBH.CheckedChanged += new System.EventHandler(this.rbt_BUTransfersPayWageBH_CheckedChanged);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(17, 19);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(87, 23);
            this.bt_ok.TabIndex = 3;
            this.bt_ok.Text = "Đồng ý";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbt_BUTransfersPayWage);
            this.groupBox1.Controls.Add(this.rbt_BUTransfersPayWageBH);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 101);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bạn có muốn sinh chứng từ sau không?";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_Cancel);
            this.groupBox2.Controls.Add(this.bt_ok);
            this.groupBox2.Location = new System.Drawing.Point(317, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 101);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // FrmAutoVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 113);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAutoVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AutoVoucher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.RadioButton rbt_BUTransfersPayWage;
        private System.Windows.Forms.RadioButton rbt_BUTransfersPayWageBH;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}