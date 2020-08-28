namespace BuCA.Application.iBigTime2020.Report.BaseParameterForm
{
    partial class FrmGetProject
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
            this.grdProject = new DevExpress.XtraGrid.GridControl();
            this.gridviewProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewProject)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.grdProject);
            this.groupboxMain.Size = new System.Drawing.Size(788, 399);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(639, 416);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(720, 416);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 416);
            // 
            // grdProject
            // 
            this.grdProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProject.Location = new System.Drawing.Point(2, 2);
            this.grdProject.MainView = this.gridviewProject;
            this.grdProject.Name = "grdProject";
            this.grdProject.Size = new System.Drawing.Size(784, 395);
            this.grdProject.TabIndex = 1;
            this.grdProject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridviewProject});
            // 
            // gridviewProject
            // 
            this.gridviewProject.GridControl = this.grdProject;
            this.gridviewProject.Name = "gridviewProject";
            this.gridviewProject.OptionsView.ShowAutoFilterRow = true;
            // 
            // FrmGetProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmGetProject";
            this.Text = "Chọn dự án";
            this.Load += new System.EventHandler(this.FrmGetProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdProject;
        private DevExpress.XtraGrid.Views.Grid.GridView gridviewProject;
    }
}