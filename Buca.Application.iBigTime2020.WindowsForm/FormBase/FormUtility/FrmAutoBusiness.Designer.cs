namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormUtility
{
    partial class FrmAutoBusiness
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoBusiness));
            this.imgMain = new DevExpress.Utils.ImageCollection(this.components);
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.grdAutoBusiness = new DevExpress.XtraGrid.GridControl();
            this.grdAutoBusinessView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoBusiness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoBusinessView)).BeginInit();
            this.SuspendLayout();
            // 
            // imgMain
            // 
            this.imgMain.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgMain.ImageStream")));
            this.imgMain.Images.SetKeyName(0, "LUU.png");
            this.imgMain.Images.SetKeyName(1, "THOAT.png");
            this.imgMain.Images.SetKeyName(2, "TRO-GIUP.png");
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ImageIndex = 0;
            this.btnApply.ImageList = this.imgMain;
            this.btnApply.Location = new System.Drawing.Point(419, 393);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(70, 25);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Lưu";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ImageIndex = 1;
            this.btnExit.ImageList = this.imgMain;
            this.btnExit.Location = new System.Drawing.Point(495, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.ImageIndex = 2;
            this.btnHelp.ImageList = this.imgMain;
            this.btnHelp.Location = new System.Drawing.Point(12, 393);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(70, 25);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // grdAutoBusiness
            // 
            this.grdAutoBusiness.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAutoBusiness.Location = new System.Drawing.Point(12, 8);
            this.grdAutoBusiness.MainView = this.grdAutoBusinessView;
            this.grdAutoBusiness.Name = "grdAutoBusiness";
            this.grdAutoBusiness.Size = new System.Drawing.Size(553, 379);
            this.grdAutoBusiness.TabIndex = 7;
            this.grdAutoBusiness.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAutoBusinessView});
            // 
            // grdAutoBusinessView
            // 
            this.grdAutoBusinessView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdAutoBusinessView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdAutoBusinessView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdAutoBusinessView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.grdAutoBusinessView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdAutoBusinessView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdAutoBusinessView.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdAutoBusinessView.FixedLineWidth = 1;
            this.grdAutoBusinessView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdAutoBusinessView.GridControl = this.grdAutoBusiness;
            this.grdAutoBusinessView.Name = "grdAutoBusinessView";
            this.grdAutoBusinessView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdAutoBusinessView.OptionsBehavior.Editable = false;
            this.grdAutoBusinessView.OptionsBehavior.FocusLeaveOnTab = true;
            this.grdAutoBusinessView.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdAutoBusinessView.OptionsView.ShowGroupPanel = false;
            this.grdAutoBusinessView.OptionsView.ShowIndicator = false;
            this.grdAutoBusinessView.DoubleClick += new System.EventHandler(this.grdAutoBusinessView_DoubleClick);
            // 
            // FrmAutoBusiness
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(577, 430);
            this.Controls.Add(this.grdAutoBusiness);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Name = "FrmAutoBusiness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách định khoản tự động";
            this.Load += new System.EventHandler(this.FrmAutoBusiness_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoBusiness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutoBusinessView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgMain;
        public DevExpress.XtraEditors.SimpleButton btnApply;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraGrid.GridControl grdAutoBusiness;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAutoBusinessView;
    }
}