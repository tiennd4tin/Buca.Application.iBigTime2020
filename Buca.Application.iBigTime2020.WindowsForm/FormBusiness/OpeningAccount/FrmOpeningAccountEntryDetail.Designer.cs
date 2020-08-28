namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount
{
    partial class FrmOpeningAccountEntryDetail
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
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.grdDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenuDetail = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barItemAdd = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.grdDetail);
            this.groupboxMain.Size = new System.Drawing.Size(1108, 493);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(972, 510);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1044, 510);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 510);
            // 
            // grdDetail
            // 
            this.grdDetail.DataSource = this.bindingSourceDetail;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(2, 2);
            this.grdDetail.MainView = this.grdDetailView;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(1104, 489);
            this.grdDetail.TabIndex = 0;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDetailView});
            this.grdDetail.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdDetail_ProcessGridKey);
            // 
            // grdDetailView
            // 
            this.grdDetailView.GridControl = this.grdDetail;
            this.grdDetailView.Name = "grdDetailView";
            this.grdDetailView.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.grdDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdDetailView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdDetailView.OptionsView.ColumnAutoWidth = false;
            this.grdDetailView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdDetailView.OptionsView.ShowGroupPanel = false;
            this.grdDetailView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.grdDetailView.OptionsView.ShowIndicator = false;
            this.grdDetailView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.grdDetailView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdDetailView_PopupMenuShowing);
            this.grdDetailView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdDetailView_InitNewRow);
            this.grdDetailView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdDetailView_CellValueChanged);
            // 
            // popupMenuDetail
            // 
            this.popupMenuDetail.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelete)});
            this.popupMenuDetail.Manager = this.barManager1;
            this.popupMenuDetail.Name = "popupMenuDetail";
            // 
            // barItemDelete
            // 
            this.barItemDelete.Caption = "Xóa dòng";
            this.barItemDelete.Id = 1;
            this.barItemDelete.Name = "barItemDelete";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemAdd,
            this.barItemDelete});
            this.barManager1.MaxItemId = 2;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1122, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 542);
            this.barDockControlBottom.Size = new System.Drawing.Size(1122, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 542);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1122, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 542);
            // 
            // barItemAdd
            // 
            this.barItemAdd.Caption = "Thêm dòng";
            this.barItemAdd.Id = 0;
            this.barItemAdd.Name = "barItemAdd";
            // 
            // FrmOpeningAccountEntryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 542);
            this.ComponentName = "Số dư tài khoản";
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.EventTime = new System.DateTime(2020, 8, 19, 11, 32, 47, 900);
            this.FormCaption = "Số dư tài khoản";
            this.KeyFieldName = "AccountCode";
            this.Name = "FrmOpeningAccountEntryDetail";
            this.Reference = "THÊM SỐ DƯ TÀI KHOẢN - ID ";
            this.Text = "FrmOpeningAccountEntryDetail";
            this.Load += new System.EventHandler(this.FrmOpeningAccountEntryDetail_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        protected DevExpress.XtraGrid.GridControl grdDetail;
        protected DevExpress.XtraGrid.Views.Grid.GridView grdDetailView;
        private DevExpress.XtraBars.PopupMenu popupMenuDetail;
        private DevExpress.XtraBars.BarButtonItem barItemAdd;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}