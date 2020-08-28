namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmGLVoucherListDetailParamaterReport
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
            this.IsGroupSameRow = new System.Windows.Forms.CheckBox();
            this.IsOriginalCurrency = new System.Windows.Forms.CheckBox();
            this.IsNotShowSingleAccount = new System.Windows.Forms.CheckBox();
            this.IsNotTotalSingleAccount = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.IsViewRefNo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.IsViewRefNo);
            this.groupboxMain.Controls.Add(this.checkBox5);
            this.groupboxMain.Controls.Add(this.IsNotTotalSingleAccount);
            this.groupboxMain.Controls.Add(this.IsNotShowSingleAccount);
            this.groupboxMain.Controls.Add(this.IsOriginalCurrency);
            this.groupboxMain.Controls.Add(this.IsGroupSameRow);
            this.groupboxMain.Size = new System.Drawing.Size(350, 179);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(201, 196);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(282, 196);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 196);
            // 
            // IsGroupSameRow
            // 
            this.IsGroupSameRow.AutoSize = true;
            this.IsGroupSameRow.Location = new System.Drawing.Point(15, 18);
            this.IsGroupSameRow.Name = "IsGroupSameRow";
            this.IsGroupSameRow.Size = new System.Drawing.Size(174, 17);
            this.IsGroupSameRow.TabIndex = 0;
            this.IsGroupSameRow.Text = "Cộng gộp các dòng giống nhau";
            this.IsGroupSameRow.UseVisualStyleBackColor = true;
            // 
            // IsOriginalCurrency
            // 
            this.IsOriginalCurrency.AutoSize = true;
            this.IsOriginalCurrency.Location = new System.Drawing.Point(15, 41);
            this.IsOriginalCurrency.Name = "IsOriginalCurrency";
            this.IsOriginalCurrency.Size = new System.Drawing.Size(152, 17);
            this.IsOriginalCurrency.TabIndex = 1;
            this.IsOriginalCurrency.Text = "Hiển thị số  tiền nguyên tệ";
            this.IsOriginalCurrency.UseVisualStyleBackColor = true;
            // 
            // IsNotShowSingleAccount
            // 
            this.IsNotShowSingleAccount.AutoSize = true;
            this.IsNotShowSingleAccount.Location = new System.Drawing.Point(15, 65);
            this.IsNotShowSingleAccount.Name = "IsNotShowSingleAccount";
            this.IsNotShowSingleAccount.Size = new System.Drawing.Size(201, 17);
            this.IsNotShowSingleAccount.TabIndex = 2;
            this.IsNotShowSingleAccount.Text = "Không hiện các dòng định khoản đơn";
            this.IsNotShowSingleAccount.UseVisualStyleBackColor = true;
            // 
            // IsNotTotalSingleAccount
            // 
            this.IsNotTotalSingleAccount.AutoSize = true;
            this.IsNotTotalSingleAccount.Location = new System.Drawing.Point(15, 89);
            this.IsNotTotalSingleAccount.Name = "IsNotTotalSingleAccount";
            this.IsNotTotalSingleAccount.Size = new System.Drawing.Size(186, 17);
            this.IsNotTotalSingleAccount.TabIndex = 3;
            this.IsNotTotalSingleAccount.Text = "Không cộng các tài khoản ghi đơn";
            this.IsNotTotalSingleAccount.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(15, 112);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(292, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Sắp xếp số chứng từ đồng thời ngay dưới chứng từ gốc";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // IsViewRefNo
            // 
            this.IsViewRefNo.AutoSize = true;
            this.IsViewRefNo.Location = new System.Drawing.Point(15, 136);
            this.IsViewRefNo.Name = "IsViewRefNo";
            this.IsViewRefNo.Size = new System.Drawing.Size(187, 17);
            this.IsViewRefNo.TabIndex = 5;
            this.IsViewRefNo.Text = "Hiển thị số chứng từ ở cột ghi chú";
            this.IsViewRefNo.UseVisualStyleBackColor = true;
            // 
            // FrmGLVoucherListDetailParamaterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 230);
            this.Name = "FrmGLVoucherListDetailParamaterReport";
            this.Text = "Chứng từ ghi sổ";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox IsViewRefNo;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox IsNotTotalSingleAccount;
        private System.Windows.Forms.CheckBox IsNotShowSingleAccount;
        private System.Windows.Forms.CheckBox IsOriginalCurrency;
        private System.Windows.Forms.CheckBox IsGroupSameRow;
    }
}