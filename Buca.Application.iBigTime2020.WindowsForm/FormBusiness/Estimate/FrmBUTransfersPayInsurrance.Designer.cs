﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    partial class FrmBUTransfersPayInsurrance
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
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // popupMenu
            // 
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // FrmBUTransfersPayInsurrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Content = "Chuyển khoản trả bảo hiểm";
            this.EventTime = new System.DateTime(2019, 2, 22, 16, 46, 39, 770);
            this.FormCaption = "Chuyển khoản trả bảo hiểm";
            this.FormDetail = "FrmBUTransfersPayInsurranceDetail";
            this.Name = "FrmBUTransfersPayInsurrance";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "THÊM CHUYỂN KHOẢN TRẢ BẢO HIỂM - ID  - SỐ CT: ";
            this.RefTypeId = BuCA.Enum.RefType.BUTransferPayInsurrance;
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}