﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General
{
    partial class FrmGLVouchersEarlyYear
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // FrmGLVouchersEarlyYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.EventTime = new System.DateTime(2018, 5, 29, 17, 21, 44, 66);
            this.FormCaption = "Kết chuyển chi phí ĐTXDCB chờ quyết toán";
            this.FormDetail = "FrmGLVouchersEarlyYearDetail";
            this.Name = "FrmGLVouchersEarlyYear";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General";
            this.Reference = "THÊM KẾT CHUYỂN CHI PHÍ ĐTXDCB CHỜ QUYẾT TOÁN - ID  - SỐ CT: ";
            this.RefTypeId = BuCA.Enum.RefType.GLVoucherEarlyYear;
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
