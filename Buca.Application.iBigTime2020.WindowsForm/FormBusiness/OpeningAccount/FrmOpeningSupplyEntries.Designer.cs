namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount
{
    partial class FrmOpeningSupplyEntries
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl.SplitterPosition = 509;
            // 
            // FrmOpeningSupplyEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.EventTime = new System.DateTime(2018, 1, 9, 11, 40, 34, 652);
            this.FormCaption = "Số dư Công cụ dụng cụ";
            this.FormDetail = "";
            this.Name = "FrmOpeningSupplyEntries";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount";
            this.Reference = "THÊM SỐ DƯ CÔNG CỤ DỤNG CỤ - ID  - SỐ CT: ";
            this.RefTypeId = BuCA.Enum.RefType.OpeningSupplyEntry;
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