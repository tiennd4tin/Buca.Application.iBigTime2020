﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement
{
    partial class FrmSUTransfers
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
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // barTools
            // 
            this.barTools.OptionsBar.DrawBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewDetail.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.gridViewDetail.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewDetail.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDetail.OptionsBehavior.Editable = false;
            this.gridViewDetail.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewDetail.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewDetail.OptionsView.ColumnAutoWidth = false;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewDetail.OptionsView.ShowIndicator = false;
            // 
            // FrmSUTransfers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.EventTime = new System.DateTime(2017, 10, 28, 16, 42, 56, 276);
            this.FormCaption = "Điều chuyển CCDC";
            this.FormDetail = "FrmSUTransferDetail";
            this.Name = "FrmSUTransfers";
            this.NamespaceForm = "Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement";
            this.Reference = "THÊM ĐIỀU CHUYỂN CCDC - ID  - SỐ CT: ";
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
