﻿namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    partial class XtraAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraAboutForm));
            this.pictureLeft = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabAboutPage = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblWarning = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.lblCompanyAddress = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.LinkLabel();
            this.lblWebsite = new System.Windows.Forms.LinkLabel();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.xtraTabContactPage = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.rtbSupportInfo = new System.Windows.Forms.RichTextBox();
            this.xtraTabVersionInfoPage = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.richVersionInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnContact = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnVersionInfo = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.xtraTabAboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraTabContactPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.xtraTabVersionInfoPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLeft
            // 
            this.pictureLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureLeft.EditValue = ((object)(resources.GetObject("pictureLeft.EditValue")));
            this.pictureLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pictureLeft.Name = "pictureLeft";
            this.pictureLeft.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureLeft.Properties.ShowMenu = false;
            this.pictureLeft.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureLeft.Size = new System.Drawing.Size(156, 391);
            this.pictureLeft.TabIndex = 0;
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl.Location = new System.Drawing.Point(159, 2);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabAboutPage;
            this.xtraTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl.Size = new System.Drawing.Size(462, 357);
            this.xtraTabControl.TabIndex = 1;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabAboutPage,
            this.xtraTabContactPage,
            this.xtraTabVersionInfoPage});
            this.xtraTabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl_SelectedPageChanged);
            // 
            // xtraTabAboutPage
            // 
            this.xtraTabAboutPage.Controls.Add(this.groupControl2);
            this.xtraTabAboutPage.Controls.Add(this.groupControl1);
            this.xtraTabAboutPage.Controls.Add(this.panelControl1);
            this.xtraTabAboutPage.Name = "xtraTabAboutPage";
            this.xtraTabAboutPage.Size = new System.Drawing.Size(456, 351);
            this.xtraTabAboutPage.Text = "xtraTabPage1";
            // 
            // groupControl2
            // 
            this.groupControl2.AllowHtmlText = true;
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.lblWarning);
            this.groupControl2.Location = new System.Drawing.Point(3, 258);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(450, 90);
            this.groupControl2.TabIndex = 20;
            this.groupControl2.Text = "<b>Lưu ý</b>";
            // 
            // lblWarning
            // 
            this.lblWarning.Location = new System.Drawing.Point(8, 21);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(440, 67);
            this.lblWarning.TabIndex = 2;
            this.lblWarning.Text = "Sản phẩm đã được đăng ký bản quyền sở hữu trí tuệ. Việc sử dụng, sao chép và chuy" +
    "ển giao thương mại mà không được sự cho phép của tác giả là vi phạm pháp luật củ" +
    "a nước CHXHCN Việt Nam.";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControl1
            // 
            this.groupControl1.AllowHtmlText = true;
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.lblLicenseNumber);
            this.groupControl1.Controls.Add(this.lblCompanyAddress);
            this.groupControl1.Controls.Add(this.lblCompanyName);
            this.groupControl1.Location = new System.Drawing.Point(3, 153);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(450, 100);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "<b>Sản phẩm được đăng ký cho </b>";
            // 
            // lblLicenseNumber
            // 
            this.lblLicenseNumber.AutoSize = true;
            this.lblLicenseNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLicenseNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(20)))));
            this.lblLicenseNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLicenseNumber.Location = new System.Drawing.Point(10, 73);
            this.lblLicenseNumber.Name = "lblLicenseNumber";
            this.lblLicenseNumber.Size = new System.Drawing.Size(54, 13);
            this.lblLicenseNumber.TabIndex = 3;
            this.lblLicenseNumber.Text = "Phiên bản";
            this.lblLicenseNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompanyAddress
            // 
            this.lblCompanyAddress.AutoSize = true;
            this.lblCompanyAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCompanyAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(20)))));
            this.lblCompanyAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCompanyAddress.Location = new System.Drawing.Point(10, 53);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(54, 13);
            this.lblCompanyAddress.TabIndex = 3;
            this.lblCompanyAddress.Text = "Phiên bản";
            this.lblCompanyAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCompanyName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(20)))));
            this.lblCompanyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCompanyName.Location = new System.Drawing.Point(10, 33);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(54, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Phiên bản";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.Label2);
            this.panelControl1.Controls.Add(this.lblDescription);
            this.panelControl1.Controls.Add(this.lblEmail);
            this.panelControl1.Controls.Add(this.lblWebsite);
            this.panelControl1.Controls.Add(this.Label5);
            this.panelControl1.Controls.Add(this.lblTitle);
            this.panelControl1.Controls.Add(this.lblVersion);
            this.panelControl1.Controls.Add(this.lblCopyright);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(450, 146);
            this.panelControl1.TabIndex = 18;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(8, 119);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(185, 13);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Hỗ trợ khách hàng: 1900 6419 |";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(8, 43);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(81, 13);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "(Description)";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(192, 119);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 13);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.TabStop = true;
            this.lblEmail.Text = "head@buca.vn";
            this.lblEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEmail_LinkClicked);
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(64, 100);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(106, 13);
            this.lblWebsite.TabIndex = 22;
            this.lblWebsite.TabStop = true;
            this.lblWebsite.Text = "http://www.buca.vn";
            this.lblWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWebsite_LinkClicked);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(8, 100);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(56, 13);
            this.Label5.TabIndex = 21;
            this.Label5.Text = "Website:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(8, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(202, 29);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "(Product name)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(8, 62);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(62, 13);
            this.lblVersion.TabIndex = 19;
            this.lblVersion.Text = "Phiên bản";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCopyright.Location = new System.Drawing.Point(8, 81);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(72, 13);
            this.lblCopyright.TabIndex = 20;
            this.lblCopyright.Text = "(Copyright)";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xtraTabContactPage
            // 
            this.xtraTabContactPage.Controls.Add(this.groupControl3);
            this.xtraTabContactPage.Name = "xtraTabContactPage";
            this.xtraTabContactPage.Size = new System.Drawing.Size(456, 351);
            this.xtraTabContactPage.Text = "xtraTabPage2";
            // 
            // groupControl3
            // 
            this.groupControl3.AllowHtmlText = true;
            this.groupControl3.Controls.Add(this.rtbSupportInfo);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(456, 351);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "<b>Thông tin liên hệ</b>";
            // 
            // rtbSupportInfo
            // 
            this.rtbSupportInfo.BackColor = System.Drawing.Color.White;
            this.rtbSupportInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSupportInfo.Location = new System.Drawing.Point(2, 21);
            this.rtbSupportInfo.Name = "rtbSupportInfo";
            this.rtbSupportInfo.ReadOnly = true;
            this.rtbSupportInfo.Size = new System.Drawing.Size(452, 328);
            this.rtbSupportInfo.TabIndex = 6;
            this.rtbSupportInfo.Text = resources.GetString("rtbSupportInfo.Text");
            // 
            // xtraTabVersionInfoPage
            // 
            this.xtraTabVersionInfoPage.Controls.Add(this.groupControl4);
            this.xtraTabVersionInfoPage.Name = "xtraTabVersionInfoPage";
            this.xtraTabVersionInfoPage.Size = new System.Drawing.Size(456, 351);
            this.xtraTabVersionInfoPage.Text = "xtraTabVersionInfoPage";
            // 
            // groupControl4
            // 
            this.groupControl4.AllowHtmlText = true;
            this.groupControl4.Controls.Add(this.richVersionInfoTextBox);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(456, 351);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "<b>Thông tin cập nhật</b>";
            // 
            // richVersionInfoTextBox
            // 
            this.richVersionInfoTextBox.BackColor = System.Drawing.Color.White;
            this.richVersionInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richVersionInfoTextBox.Location = new System.Drawing.Point(2, 21);
            this.richVersionInfoTextBox.Name = "richVersionInfoTextBox";
            this.richVersionInfoTextBox.ReadOnly = true;
            this.richVersionInfoTextBox.Size = new System.Drawing.Size(452, 328);
            this.richVersionInfoTextBox.TabIndex = 6;
            this.richVersionInfoTextBox.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageIndex = 1;
            this.btnClose.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(545, 364);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "dong-y.png");
            this.imageCollection.Images.SetKeyName(1, "huy-bo.png");
            this.imageCollection.Images.SetKeyName(2, "tro-giup.png");
            this.imageCollection.Images.SetKeyName(3, "2.thongtin-chuongtrinh.png");
            // 
            // btnContact
            // 
            this.btnContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContact.ImageIndex = 3;
            this.btnContact.ImageList = this.imageCollection;
            this.btnContact.Location = new System.Drawing.Point(159, 364);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(112, 23);
            this.btnContact.TabIndex = 23;
            this.btnContact.Text = "Thông tin liên hệ";
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(159, 364);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Về trước";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnVersionInfo
            // 
            this.btnVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVersionInfo.ImageIndex = 0;
            this.btnVersionInfo.ImageList = this.imageCollection;
            this.btnVersionInfo.Location = new System.Drawing.Point(382, 364);
            this.btnVersionInfo.Name = "btnVersionInfo";
            this.btnVersionInfo.Size = new System.Drawing.Size(156, 23);
            this.btnVersionInfo.TabIndex = 23;
            this.btnVersionInfo.Text = "Thỏa thuận quyền sử dụng";
            this.btnVersionInfo.Click += new System.EventHandler(this.btnVersionInfo_Click);
            // 
            // XtraAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 391);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnVersionInfo);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.pictureLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(636, 423);
            this.Name = "XtraAboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giới thiệu chương trình";
            this.Load += new System.EventHandler(this.XtraAboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.xtraTabAboutPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.xtraTabContactPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.xtraTabVersionInfoPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureLeft;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabAboutPage;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        internal System.Windows.Forms.Label lblWarning;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal System.Windows.Forms.Label lblCompanyName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblDescription;
        internal System.Windows.Forms.LinkLabel lblEmail;
        internal System.Windows.Forms.LinkLabel lblWebsite;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label lblCopyright;
        private DevExpress.XtraTab.XtraTabPage xtraTabContactPage;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        internal System.Windows.Forms.RichTextBox rtbSupportInfo;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnContact;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        internal System.Windows.Forms.Label lblLicenseNumber;
        internal System.Windows.Forms.Label lblCompanyAddress;
        private DevExpress.XtraTab.XtraTabPage xtraTabVersionInfoPage;
        private DevExpress.XtraEditors.SimpleButton btnVersionInfo;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        internal System.Windows.Forms.RichTextBox richVersionInfoTextBox;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}