namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt
{
    partial class FrmCAReceipts
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
            //this.popupMenu = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
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
            this.EventTime = new System.DateTime(2018, 1, 2, 17, 9, 37, 41);
            this.FormCaption = "Phiếu thu";
            this.FormDetail = "FrmCAReceiptDetail";
            this.Name = "FrmCAReceipts";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt";
            // 
            // popupMenu
            // 
            //this.popupMenu.Manager = this.barToolManager;
            //this.popupMenu.Name = "popupMenu";
            //this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "THÊM PHIẾU THU - ID  - SỐ CT: ";
            this.RefTypeId = BuCA.Enum.RefType.CAReceipt;
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}
