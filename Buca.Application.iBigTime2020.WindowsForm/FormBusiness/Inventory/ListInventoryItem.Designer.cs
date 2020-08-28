namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    partial class ListInventoryItem
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
            this.gridInventoryItem = new DevExpress.XtraGrid.GridControl();
            this.gridViewInventoryItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInventoryItem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.gridInventoryItem);
            this.groupboxMain.Size = new System.Drawing.Size(1175, 403);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(1026, 420);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1107, 420);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 420);
            // 
            // gridInventoryItem
            // 
            this.gridInventoryItem.Location = new System.Drawing.Point(0, 0);
            this.gridInventoryItem.MainView = this.gridViewInventoryItem;
            this.gridInventoryItem.Name = "gridInventoryItem";
            this.gridInventoryItem.Size = new System.Drawing.Size(1180, 413);
            this.gridInventoryItem.TabIndex = 0;
            this.gridInventoryItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInventoryItem});
            // 
            // gridViewInventoryItem
            // 
            this.gridViewInventoryItem.GridControl = this.gridInventoryItem;
            this.gridViewInventoryItem.Name = "gridViewInventoryItem";
            this.gridViewInventoryItem.OptionsView.ShowGroupPanel = false;
            this.gridViewInventoryItem.OptionsView.ShowIndicator = false;
            this.gridViewInventoryItem.DoubleClick += new System.EventHandler(this.gridViewInventoryItem_DoubleClick);
            // 
            // ListInventoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 454);
            this.Name = "ListInventoryItem";
            this.Text = "Chọn vật tư (Xuất kho theo phương pháp đích danh)";
            this.Load += new System.EventHandler(this.ListInventoryItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInventoryItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridInventoryItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInventoryItem;
    }
}