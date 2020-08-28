namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account
{
    partial class FrmAccounts
    {
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
            this.popupMenu = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddNewItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonEditItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDeleteItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPrintItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefeshItem)});
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // FrmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ComponentName = "Hệ thống tài khoản";
            this.EventAction = 4;
            this.EventTime = new System.DateTime(2017, 10, 14, 15, 1, 7, 445);
            this.ExpandAll = true;
            this.FormCaption = "Hệ thống tài khoản";
            this.FormDetail = "FrmAccountDetail";
            this.Name = "FrmAccounts";
            this.ParentFieldName = "ParentId";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "XEM HỆ THỐNG TÀI KHOẢN - ID ";
            this.TablePrimaryKey = "AccountId";
            this.VisibleButtonAddNew = true;
            this.VisibleButtonDelete = true;
            this.VisibleButtonEdit = true;
            this.VisibleButtonFind = true;
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}
