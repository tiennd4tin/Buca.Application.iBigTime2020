namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList
{
    partial class FrmBaseList
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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseList));
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            this.barToolManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.barButtonAddNewItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEditItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDeleteItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPrintItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFind = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefeshItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHelpItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPrintFixedAssetItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRole = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageToobarCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.ListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // barToolManager
            // 
            this.barToolManager.AllowCustomization = false;
            this.barToolManager.AllowMoveBarOnToolbar = false;
            this.barToolManager.AllowQuickCustomization = false;
            this.barToolManager.AllowShowToolbarsPopup = false;
            this.barToolManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools});
            this.barToolManager.DockControls.Add(this.barDockControlTop);
            this.barToolManager.DockControls.Add(this.barDockControlBottom);
            this.barToolManager.DockControls.Add(this.barDockControlLeft);
            this.barToolManager.DockControls.Add(this.barDockControlRight);
            this.barToolManager.Form = this;
            this.barToolManager.Images = this.imageToobarCollection;
            this.barToolManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonAddNewItem,
            this.barButtonEditItem,
            this.barButtonDeleteItem,
            this.barButtonPrintItem,
            this.barButtonHelpItem,
            this.barButtonRefeshItem,
            this.barButtonItem1,
            this.barButtonPrintFixedAssetItem,
            this.barButtonFind,
            this.barButtonItemRole});
            this.barToolManager.MaxItemId = 12;
            this.barToolManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barToolManager_ItemClick);
            // 
            // barTools
            // 
            this.barTools.BarItemHorzIndent = 7;
            this.barTools.BarName = "Tools";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.FloatLocation = new System.Drawing.Point(46, 122);
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonAddNewItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonDeleteItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonPrintItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonFind, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonRefeshItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonHelpItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPrintFixedAssetItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRole)});
            this.barTools.OptionsBar.DrawBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            this.barTools.Text = "Tools";
            // 
            // barButtonAddNewItem
            // 
            this.barButtonAddNewItem.Caption = "Thêm";
            this.barButtonAddNewItem.Id = 0;
            this.barButtonAddNewItem.ImageIndex = 22;
            this.barButtonAddNewItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.barButtonAddNewItem.Name = "barButtonAddNewItem";
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem1.Text = "<b>Thêm mới dữ liệu (Ctrl + N)</b>";
            superToolTip1.Items.Add(toolTipItem1);
            this.barButtonAddNewItem.SuperTip = superToolTip1;
            // 
            // barButtonEditItem
            // 
            this.barButtonEditItem.Caption = "Sửa";
            this.barButtonEditItem.Id = 1;
            this.barButtonEditItem.ImageIndex = 23;
            this.barButtonEditItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.barButtonEditItem.Name = "barButtonEditItem";
            superToolTip2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem2.Text = "<b>Sửa dữ liệu (Ctrl + E)</b>";
            superToolTip2.Items.Add(toolTipItem2);
            this.barButtonEditItem.SuperTip = superToolTip2;
            // 
            // barButtonDeleteItem
            // 
            this.barButtonDeleteItem.Caption = "Xóa";
            this.barButtonDeleteItem.Id = 2;
            this.barButtonDeleteItem.ImageIndex = 24;
            this.barButtonDeleteItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.barButtonDeleteItem.Name = "barButtonDeleteItem";
            superToolTip3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem3.Text = "<b>Xóa dữ liệu (Delete)</b>";
            superToolTip3.Items.Add(toolTipItem3);
            this.barButtonDeleteItem.SuperTip = superToolTip3;
            // 
            // barButtonPrintItem
            // 
            this.barButtonPrintItem.Caption = "In";
            this.barButtonPrintItem.Id = 3;
            this.barButtonPrintItem.ImageIndex = 25;
            this.barButtonPrintItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.barButtonPrintItem.Name = "barButtonPrintItem";
            superToolTip4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem4.Text = "<b>In danh sách (Ctrl + P)</b>";
            superToolTip4.Items.Add(toolTipItem4);
            this.barButtonPrintItem.SuperTip = superToolTip4;
            // 
            // barButtonFind
            // 
            this.barButtonFind.Caption = "Tìm kiếm";
            this.barButtonFind.Id = 9;
            this.barButtonFind.ImageIndex = 26;
            this.barButtonFind.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.barButtonFind.Name = "barButtonFind";
            // 
            // barButtonRefeshItem
            // 
            this.barButtonRefeshItem.Caption = "Nạp";
            this.barButtonRefeshItem.Id = 5;
            this.barButtonRefeshItem.ImageIndex = 27;
            this.barButtonRefeshItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barButtonRefeshItem.Name = "barButtonRefeshItem";
            superToolTip5.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem5.Text = "<b>Làm mới dữ liệu (F5)</b>";
            superToolTip5.Items.Add(toolTipItem5);
            this.barButtonRefeshItem.SuperTip = superToolTip5;
            // 
            // barButtonHelpItem
            // 
            this.barButtonHelpItem.Caption = "Giúp";
            this.barButtonHelpItem.Id = 4;
            this.barButtonHelpItem.ImageIndex = 28;
            this.barButtonHelpItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.barButtonHelpItem.Name = "barButtonHelpItem";
            superToolTip6.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem6.Text = "<b>Tài liệu trợ giúp (F1)</b>";
            superToolTip6.Items.Add(toolTipItem6);
            this.barButtonHelpItem.SuperTip = superToolTip6;
            // 
            // barButtonPrintFixedAssetItem
            // 
            this.barButtonPrintFixedAssetItem.Caption = "In thẻ TSCĐ";
            this.barButtonPrintFixedAssetItem.Id = 7;
            this.barButtonPrintFixedAssetItem.ImageIndex = 29;
            this.barButtonPrintFixedAssetItem.Name = "barButtonPrintFixedAssetItem";
            this.barButtonPrintFixedAssetItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonPrintFixedAssetItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonPrintFixedAssetItem_ItemClick);
            // 
            // barButtonItemRole
            // 
            this.barButtonItemRole.Caption = "Phân quyền";
            this.barButtonItemRole.Id = 11;
            this.barButtonItemRole.ImageIndex = 30;
            this.barButtonItemRole.Name = "barButtonItemRole";
            this.barButtonItemRole.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(789, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 560);
            this.barDockControlBottom.Size = new System.Drawing.Size(789, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 529);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(789, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 529);
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            this.imageToobarCollection.Images.SetKeyName(0, "list-add.png");
            this.imageToobarCollection.Images.SetKeyName(1, "list-delete.png");
            this.imageToobarCollection.Images.SetKeyName(2, "list-edit.png");
            this.imageToobarCollection.Images.SetKeyName(3, "list-search.png");
            this.imageToobarCollection.Images.SetKeyName(4, "document-update.png");
            this.imageToobarCollection.Images.SetKeyName(5, "help2.png");
            this.imageToobarCollection.Images.SetKeyName(6, "print.png");
            this.imageToobarCollection.Images.SetKeyName(7, "document_refresh.png");
            this.imageToobarCollection.Images.SetKeyName(8, "0.1.dau.png");
            this.imageToobarCollection.Images.SetKeyName(9, "0.2.truoc.png");
            this.imageToobarCollection.Images.SetKeyName(10, "0.3.sau.png");
            this.imageToobarCollection.Images.SetKeyName(11, "1.them.png");
            this.imageToobarCollection.Images.SetKeyName(12, "2.sua.png");
            this.imageToobarCollection.Images.SetKeyName(13, "3.xoa.png");
            this.imageToobarCollection.Images.SetKeyName(14, "4.tim-kiem.png");
            this.imageToobarCollection.Images.SetKeyName(15, "5.in.png");
            this.imageToobarCollection.Images.SetKeyName(16, "6.nap.png");
            this.imageToobarCollection.Images.SetKeyName(17, "7.tro-giup.png");
            this.imageToobarCollection.Images.SetKeyName(18, "8.phan-quyen.png");
            this.imageToobarCollection.Images.SetKeyName(19, "9.luu.png");
            this.imageToobarCollection.Images.SetKeyName(20, "10.thoat.png");
            this.imageToobarCollection.Images.SetKeyName(21, "11.dong.png");
            this.imageToobarCollection.Images.SetKeyName(22, "1.them.png");
            this.imageToobarCollection.Images.SetKeyName(23, "2.sua.png");
            this.imageToobarCollection.Images.SetKeyName(24, "3.xoa.png");
            this.imageToobarCollection.Images.SetKeyName(25, "4.in.png");
            this.imageToobarCollection.Images.SetKeyName(26, "5.tim-kiem.png");
            this.imageToobarCollection.Images.SetKeyName(27, "6.nap.png");
            this.imageToobarCollection.Images.SetKeyName(28, "7.giup.png");
            this.imageToobarCollection.Images.SetKeyName(29, "8.in - Copy.png");
            this.imageToobarCollection.Images.SetKeyName(30, "9.phan-quyen.png");
            this.imageToobarCollection.Images.SetKeyName(31, "10.nhan-ban.png");
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddNewItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonEditItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDeleteItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefeshItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPrintItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonHelpItem)});
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // grdList
            // 
            this.grdList.DataSource = this.ListBindingSource;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 31);
            this.grdList.MainView = this.gridView;
            this.grdList.MenuManager = this.barToolManager;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(789, 529);
            this.grdList.TabIndex = 4;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.grdList.DoubleClick += new System.EventHandler(this.grdList_DoubleClick);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.grdList;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "In";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.ImageIndex = 6;
            this.barButtonItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.barButtonItem2.Name = "barButtonItem2";
            superToolTip7.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem7.Text = "<b>In danh sách (Ctrl + P)</b>";
            superToolTip7.Items.Add(toolTipItem7);
            this.barButtonItem2.SuperTip = superToolTip7;
            // 
            // FrmBaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmBaseList";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Size = new System.Drawing.Size(789, 560);
            this.Load += new System.EventHandler(this.BaseListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.BarButtonItem barButtonAddNewItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonHelpItem;
        private DevExpress.XtraBars.BarButtonItem barButtonRefeshItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        public System.Windows.Forms.BindingSource ListBindingSource;
        public DevExpress.XtraGrid.GridControl grdList;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        protected DevExpress.Utils.ImageCollection imageToobarCollection;
        protected DevExpress.XtraBars.BarButtonItem barButtonDeleteItem;
        protected DevExpress.XtraBars.BarButtonItem barButtonEditItem;
        protected DevExpress.XtraBars.BarButtonItem barButtonPrintItem;
        public DevExpress.XtraBars.BarButtonItem barButtonPrintFixedAssetItem;
        protected DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarButtonItem barButtonFind;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        protected DevExpress.XtraBars.BarButtonItem barButtonItemRole;
        protected DevExpress.XtraBars.PopupMenu popupMenu;
        protected DevExpress.XtraBars.BarManager barToolManager;
    }
}
