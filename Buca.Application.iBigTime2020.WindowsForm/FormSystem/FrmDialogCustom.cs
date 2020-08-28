using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// AnhNT
    /// Custom messenge box
    /// Truyền vào nội dung và số lượng tùy chọn
    /// Trả về giá trị là thứ tự của button truyển vào: 1, 2, 3, 4....., 0 = cancel
    /// </summary>
    public partial class FrmDialogCustom : Form
    {
        public int Result { get; set; }
        public FrmDialogCustom(string content, string[] choiceName)
        {
            InitializeComponent();
            lblContent.Text = content;
            var sizeXButton = (new Button().Size.Width);
            RefreshSizeControls((choiceName.Length + 2) * sizeXButton);
            var startPoint = this.Size.Width / 2 - (sizeXButton * (choiceName.Length+1) / 2) - 15;
            for (sbyte i = 0; i <= choiceName.Length; i++)
            {
                var newButton = new Button();
                if (i.Equals((sbyte)choiceName.Length))
                {
                    newButton.Text = "Hủy bỏ";
                    newButton.TabIndex = 0;
                }
                else
                {
                    newButton.Text = choiceName[i];
                    newButton.TabIndex = i + 1;
                }
                newButton.Click += (s, e) =>
                {
                    ReturnResult((sbyte)newButton.TabIndex);
                };
                newButton.Location = new Point(startPoint + (newButton.Size.Width * i), grpButton.Size.Height / 2 - newButton.Size.Height / 2);
                grpButton.Controls.Add(newButton);
            }
        }

        /// <summary>
        /// Thay đổi kích thước messenge box
        /// </summary>
        private void RefreshSizeControls(int width)
        {
            this.Size = new Size(width, this.Size.Height);
        }

        /// <summary>
        /// Trả về giá trị theo thứ tự button
        /// </summary>
        private void ReturnResult(sbyte index)
        {
            Result = index;
            this.Close();
        }

        /// <summary>
        /// Đóng form khi bấm ESC 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDialogCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
