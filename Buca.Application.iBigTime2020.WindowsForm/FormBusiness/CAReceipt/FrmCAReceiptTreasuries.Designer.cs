namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt
{
    partial class FrmCAReceiptTreasuries
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
            //this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
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
            // popupMenu
            // 
           // this.popupMenu.Manager = this.barToolManager;
           // this.popupMenu.Name = "popupMenu";
            // 
            // FrmCAReceiptTreasuries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.EventTime = new System.DateTime(2017, 10, 27, 20, 40, 3, 679);
            this.FormCaption = "Phiếu thu rút tiền gửi KB - NH";
            this.FormDetail = "FrmCAReceiptTreasuryDetail";
            this.Name = "FrmCAReceiptTreasuries";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt";
           // this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "THÊM PHIẾU THU RÚT TIỀN GỬI KB - NH - ID  - SỐ CT: ";
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
