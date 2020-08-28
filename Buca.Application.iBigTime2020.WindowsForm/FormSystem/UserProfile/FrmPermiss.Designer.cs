namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem.UserProfile
{
    partial class FrmPermiss
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridPermission = new DevExpress.XtraGrid.GridControl();
            this.gridViewPermission = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.radioButtonALL = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.treeList);
            this.groupboxMain.Location = new System.Drawing.Point(3, 4);
            this.groupboxMain.Size = new System.Drawing.Size(687, 610);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(896, 620);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(968, 620);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 620);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gridPermission);
            this.panel1.Location = new System.Drawing.Point(695, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 141);
            this.panel1.TabIndex = 4;
            // 
            // gridPermission
            // 
            this.gridPermission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPermission.Location = new System.Drawing.Point(0, -1);
            this.gridPermission.MainView = this.gridViewPermission;
            this.gridPermission.Name = "gridPermission";
            this.gridPermission.Size = new System.Drawing.Size(339, 139);
            this.gridPermission.TabIndex = 1;
            this.gridPermission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPermission});
            // 
            // gridViewPermission
            // 
            this.gridViewPermission.GridControl = this.gridPermission;
            this.gridViewPermission.Name = "gridViewPermission";
            this.gridViewPermission.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewPermission.OptionsView.ShowGroupPanel = false;
            this.gridViewPermission.OptionsView.ShowIndicator = false;
            // 
            // treeList
            // 
            this.treeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeList.Appearance.Row.BorderColor = System.Drawing.Color.Silver;
            this.treeList.Appearance.Row.Options.UseBorderColor = true;
            this.treeList.DataSource = this.bindingSource1;
            this.treeList.KeyFieldName = "FeatureID";
            this.treeList.Location = new System.Drawing.Point(-6, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.EnableFiltering = true;
            this.treeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.treeList.OptionsFind.ShowClearButton = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeList.Size = new System.Drawing.Size(692, 608);
            this.treeList.TabIndex = 5;
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle);
            this.treeList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.radioButtonSelect);
            this.panel2.Controls.Add(this.radioButtonALL);
            this.panel2.Location = new System.Drawing.Point(696, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 464);
            this.panel2.TabIndex = 8;
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSelect.Location = new System.Drawing.Point(200, 10);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(69, 17);
            this.radioButtonSelect.TabIndex = 9;
            this.radioButtonSelect.TabStop = true;
            this.radioButtonSelect.Text = "Bỏ chọn";
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            this.radioButtonSelect.CheckedChanged += new System.EventHandler(this.radioButtonSelect_CheckedChanged);
            // 
            // radioButtonALL
            // 
            this.radioButtonALL.AutoSize = true;
            this.radioButtonALL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonALL.Location = new System.Drawing.Point(51, 10);
            this.radioButtonALL.Name = "radioButtonALL";
            this.radioButtonALL.Size = new System.Drawing.Size(89, 17);
            this.radioButtonALL.TabIndex = 8;
            this.radioButtonALL.TabStop = true;
            this.radioButtonALL.Text = "Chọn tất cả";
            this.radioButtonALL.UseVisualStyleBackColor = true;
            this.radioButtonALL.CheckedChanged += new System.EventHandler(this.radioButtonALL_CheckedChanged);
            // 
            // FrmPermiss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 651);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.EventTime = new System.DateTime(2018, 7, 10, 14, 39, 55, 345);
            this.Name = "FrmPermiss";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.FrmPermiss_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraGrid.GridControl gridPermission;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPermission;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.RadioButton radioButtonALL;
    }
}