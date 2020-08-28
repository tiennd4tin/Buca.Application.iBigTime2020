namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    partial class FrmDialogCustom
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
            this.lblContent = new System.Windows.Forms.Label();
            this.grpButton = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContent.Location = new System.Drawing.Point(12, 9);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(402, 42);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "fdsafsdafsdafsdafsdaf dsaf dsa fdas fdas fasd fasdf sdaf asdf asdf a fasd fasdf a" +
    "sdf asdf asdf asdf asdf asdf asdf ádsdf asdf ádf fsda fdsa fdsa fasd";
            // 
            // grpButton
            // 
            this.grpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpButton.Location = new System.Drawing.Point(12, 43);
            this.grpButton.Name = "grpButton";
            this.grpButton.Size = new System.Drawing.Size(402, 37);
            this.grpButton.TabIndex = 0;
            // 
            // FrmDialogCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 92);
            this.Controls.Add(this.grpButton);
            this.Controls.Add(this.lblContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialogCustom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDialogCustom_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Panel grpButton;
    }
}