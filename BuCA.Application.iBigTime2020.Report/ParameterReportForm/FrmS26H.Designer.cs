namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    partial class FrmS26H
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.gridInventoryControl = new DevExpress.XtraGrid.GridControl();
            this.inventoryItemBindingSource = new System.Windows.Forms.BindingSource();
            this._I_BIGTIME_2020DataSet = new BuCA.Application.iBigTime2020.Report._I_BIGTIME_2020DataSet();
            this.gridInventoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInventoryItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConvertUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConvertRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMadeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaultStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOGSAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountingObjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTool = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTaxable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.inventoryItemTableAdapter = new BuCA.Application.iBigTime2020.Report._I_BIGTIME_2020DataSetTableAdapters.InventoryItemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._I_BIGTIME_2020DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.gridInventoryControl);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Size = new System.Drawing.Size(472, 490);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(323, 505);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(404, 505);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 505);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "Chọn kỳ báo cáo";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.White;
            this.dateTimeRangeV1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.Appearance.Options.UseForeColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.Reduce;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(0, -3);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(250, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(394, 100);
            this.dateTimeRangeV1.TabIndex = 22;
            this.dateTimeRangeV1.ToDate = new System.DateTime(1, 12, 31, 0, 0, 0, 0);
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // gridInventoryControl
            // 
            this.gridInventoryControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInventoryControl.DataSource = this.inventoryItemBindingSource;
            this.gridInventoryControl.Location = new System.Drawing.Point(5, 109);
            this.gridInventoryControl.MainView = this.gridInventoryView;
            this.gridInventoryControl.Name = "gridInventoryControl";
            this.gridInventoryControl.Size = new System.Drawing.Size(460, 370);
            this.gridInventoryControl.TabIndex = 24;
            this.gridInventoryControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInventoryView});
            // 
            // inventoryItemBindingSource
            // 
            this.inventoryItemBindingSource.DataMember = "InventoryItem";
            this.inventoryItemBindingSource.DataSource = this._I_BIGTIME_2020DataSet;
            // 
            // _I_BIGTIME_2020DataSet
            // 
            this._I_BIGTIME_2020DataSet.DataSetName = "_I_BIGTIME_2020DataSet";
            this._I_BIGTIME_2020DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridInventoryView
            // 
            this.gridInventoryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInventoryItemID,
            this.colInventoryCategoryID,
            this.colInventoryItemCode,
            this.colInventoryItemName,
            this.colDescription,
            this.colUnit,
            this.colConvertUnit,
            this.colConvertRate,
            this.colUnitPrice,
            this.colMadeIn,
            this.colSalePrice,
            this.colDefaultStockID,
            this.colDepartmentID,
            this.colInventoryAccount,
            this.colCOGSAccount,
            this.colSaleAccount,
            this.colCostMethod,
            this.colAccountingObjectID,
            this.colTaxRate,
            this.colIsTool,
            this.colIsService,
            this.colIsActive,
            this.colIsTaxable,
            this.colIsStock});
            this.gridInventoryView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridInventoryView.GridControl = this.gridInventoryControl;
            this.gridInventoryView.Name = "gridInventoryView";
            this.gridInventoryView.OptionsDetail.EnableMasterViewMode = false;
            this.gridInventoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridInventoryView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridInventoryView.OptionsView.ShowAutoFilterRow = true;
            this.gridInventoryView.OptionsView.ShowGroupPanel = false;
            this.gridInventoryView.OptionsView.ShowIndicator = false;
            // 
            // colInventoryItemID
            // 
            this.colInventoryItemID.FieldName = "InventoryItemID";
            this.colInventoryItemID.Name = "colInventoryItemID";
            this.colInventoryItemID.Visible = true;
            this.colInventoryItemID.VisibleIndex = 0;
            // 
            // colInventoryCategoryID
            // 
            this.colInventoryCategoryID.FieldName = "InventoryCategoryID";
            this.colInventoryCategoryID.Name = "colInventoryCategoryID";
            this.colInventoryCategoryID.Visible = true;
            this.colInventoryCategoryID.VisibleIndex = 1;
            // 
            // colInventoryItemCode
            // 
            this.colInventoryItemCode.FieldName = "InventoryItemCode";
            this.colInventoryItemCode.Name = "colInventoryItemCode";
            this.colInventoryItemCode.Visible = true;
            this.colInventoryItemCode.VisibleIndex = 2;
            // 
            // colInventoryItemName
            // 
            this.colInventoryItemName.FieldName = "InventoryItemName";
            this.colInventoryItemName.Name = "colInventoryItemName";
            this.colInventoryItemName.Visible = true;
            this.colInventoryItemName.VisibleIndex = 3;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colUnit
            // 
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 5;
            // 
            // colConvertUnit
            // 
            this.colConvertUnit.FieldName = "ConvertUnit";
            this.colConvertUnit.Name = "colConvertUnit";
            this.colConvertUnit.Visible = true;
            this.colConvertUnit.VisibleIndex = 6;
            // 
            // colConvertRate
            // 
            this.colConvertRate.FieldName = "ConvertRate";
            this.colConvertRate.Name = "colConvertRate";
            this.colConvertRate.Visible = true;
            this.colConvertRate.VisibleIndex = 7;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 8;
            // 
            // colMadeIn
            // 
            this.colMadeIn.FieldName = "MadeIn";
            this.colMadeIn.Name = "colMadeIn";
            this.colMadeIn.Visible = true;
            this.colMadeIn.VisibleIndex = 9;
            // 
            // colSalePrice
            // 
            this.colSalePrice.FieldName = "SalePrice";
            this.colSalePrice.Name = "colSalePrice";
            this.colSalePrice.Visible = true;
            this.colSalePrice.VisibleIndex = 10;
            // 
            // colDefaultStockID
            // 
            this.colDefaultStockID.FieldName = "DefaultStockID";
            this.colDefaultStockID.Name = "colDefaultStockID";
            this.colDefaultStockID.Visible = true;
            this.colDefaultStockID.VisibleIndex = 11;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 12;
            // 
            // colInventoryAccount
            // 
            this.colInventoryAccount.FieldName = "InventoryAccount";
            this.colInventoryAccount.Name = "colInventoryAccount";
            this.colInventoryAccount.Visible = true;
            this.colInventoryAccount.VisibleIndex = 13;
            // 
            // colCOGSAccount
            // 
            this.colCOGSAccount.FieldName = "COGSAccount";
            this.colCOGSAccount.Name = "colCOGSAccount";
            this.colCOGSAccount.Visible = true;
            this.colCOGSAccount.VisibleIndex = 14;
            // 
            // colSaleAccount
            // 
            this.colSaleAccount.FieldName = "SaleAccount";
            this.colSaleAccount.Name = "colSaleAccount";
            this.colSaleAccount.Visible = true;
            this.colSaleAccount.VisibleIndex = 15;
            // 
            // colCostMethod
            // 
            this.colCostMethod.FieldName = "CostMethod";
            this.colCostMethod.Name = "colCostMethod";
            this.colCostMethod.Visible = true;
            this.colCostMethod.VisibleIndex = 16;
            // 
            // colAccountingObjectID
            // 
            this.colAccountingObjectID.FieldName = "AccountingObjectID";
            this.colAccountingObjectID.Name = "colAccountingObjectID";
            this.colAccountingObjectID.Visible = true;
            this.colAccountingObjectID.VisibleIndex = 17;
            // 
            // colTaxRate
            // 
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            this.colTaxRate.Visible = true;
            this.colTaxRate.VisibleIndex = 18;
            // 
            // colIsTool
            // 
            this.colIsTool.FieldName = "IsTool";
            this.colIsTool.Name = "colIsTool";
            this.colIsTool.Visible = true;
            this.colIsTool.VisibleIndex = 19;
            // 
            // colIsService
            // 
            this.colIsService.FieldName = "IsService";
            this.colIsService.Name = "colIsService";
            this.colIsService.Visible = true;
            this.colIsService.VisibleIndex = 20;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 21;
            // 
            // colIsTaxable
            // 
            this.colIsTaxable.FieldName = "IsTaxable";
            this.colIsTaxable.Name = "colIsTaxable";
            this.colIsTaxable.Visible = true;
            this.colIsTaxable.VisibleIndex = 22;
            // 
            // colIsStock
            // 
            this.colIsStock.FieldName = "IsStock";
            this.colIsStock.Name = "colIsStock";
            this.colIsStock.Visible = true;
            this.colIsStock.VisibleIndex = 23;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.dateTimeRangeV1);
            this.groupControl2.Location = new System.Drawing.Point(5, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(460, 101);
            this.groupControl2.TabIndex = 23;
            // 
            // inventoryItemTableAdapter
            // 
            this.inventoryItemTableAdapter.ClearBeforeFill = true;
            // 
            // FrmS26H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 537);
            this.Name = "FrmS26H";
            this.Text = "S26-H: Sổ theo dõi công cụ, dụng cụ tại nơi sử dụng";
            this.Load += new System.EventHandler(this.FrmS26H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._I_BIGTIME_2020DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraGrid.GridControl gridInventoryControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInventoryView;
        public DevExpress.XtraEditors.GroupControl groupControl2;
        private _I_BIGTIME_2020DataSet _I_BIGTIME_2020DataSet;
        private System.Windows.Forms.BindingSource inventoryItemBindingSource;
        private _I_BIGTIME_2020DataSetTableAdapters.InventoryItemTableAdapter inventoryItemTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryCategoryID;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colConvertUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colConvertRate;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMadeIn;
        private DevExpress.XtraGrid.Columns.GridColumn colSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultStockID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colCOGSAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colCostMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountingObjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTool;
        private DevExpress.XtraGrid.Columns.GridColumn colIsService;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTaxable;
        private DevExpress.XtraGrid.Columns.GridColumn colIsStock;
    }
}