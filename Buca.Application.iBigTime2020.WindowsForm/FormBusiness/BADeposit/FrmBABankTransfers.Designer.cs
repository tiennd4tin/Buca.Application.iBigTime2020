﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit
{
    partial class FrmBABankTransfers
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
            this.components = new System.ComponentModel.Container();
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
            // FrmCAReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.EventTime = new System.DateTime(2017, 10, 9, 20, 52, 55, 208);
            this.FormCaption = "Chuyển tiền nội bộ";
            this.FormDetail = "FrmBABankTransferDetail";
            this.Name = "FrmBABankTransfers";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit";
          //  this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "THÊM CHUYỂN TIỀN NỘI BỘ - ID  - SỐ CT: ";
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
           // ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       // private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}

