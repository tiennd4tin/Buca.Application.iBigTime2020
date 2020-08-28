using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace Buca.Application.iBigTime2020.WindowsForm.UserControl.DiagramDesktop
{
    public partial class UserControlDepositDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlDepositDesktop()
        {
            InitializeComponent();
        }
        private bool IsContextMenuStripShowing = false;
        // khai báo 1 hàm delegate
        public delegate void GetRefTypeDeposit(int refCash);
        // khai báo 1 kiểu hàm delegate
        public GetRefTypeDeposit GetRefDeposit;
        public static Color BackCorlor = Color.FromArgb(225, 225, 225);
        #region mouse_click_event
        private void picAccountingObject_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefDeposit(1);
        }
        private void picEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefDeposit(2);
        }
        private void picBank_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefDeposit(3);
        }
        private void picBABankTransfer_MouseDown(object sender, MouseEventArgs e)
        {
            GetRefDeposit(162);
        }
        private void picBAWithDraw_MouseDown(object sender, MouseEventArgs e)
        {
            GetRefDeposit(157);
        }
        private void picBADeposit_MouseDown(object sender, MouseEventArgs e)
        {
            GetRefDeposit(153);
        }

        private void picDepositReport_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefDeposit(500);
        }
        #endregion
        #region Back_color_event
        private void picBank_MouseMove(object sender, MouseEventArgs e)
        {
            picBank.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }

        private void picEmployee_MouseMove(object sender, MouseEventArgs e)
        {
            picEmployee.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picAccountingObject_MouseMove(object sender, MouseEventArgs e)
        {
            picAccountingObject.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picBAWithDraw_MouseMove(object sender, MouseEventArgs e)
        {
            picBAWithDraw.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;
        }

        private void picBABankTransfer_MouseMove(object sender, MouseEventArgs e)
        {
            picBABankTransfer.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;
        }

        private void picBADeposit_MouseMove(object sender, MouseEventArgs e)
        {
            picBADeposit.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;
        }
        private void picDepositReport_MouseMove(object sender, MouseEventArgs e)
        {
            picDepositReport.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;
        }

        private void picDepositReport_MouseLeave(object sender, EventArgs e)
        {
            picDepositReport.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picBADeposit_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuStripShowing)
            {
                return;
            }
            else
            {
                picBADeposit.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picBAWithDraw_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuStripShowing)
            {
                return;
            }
            else
            {
                picBAWithDraw.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picBABankTransfer_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuStripShowing)
            {
                return;
            }
            else
            {
                picBABankTransfer.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picAccountingObject_MouseLeave(object sender, EventArgs e)
        {
            picAccountingObject.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picEmployee_MouseLeave(object sender, EventArgs e)
        {
            picEmployee.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picBank_MouseLeave(object sender, EventArgs e)
        {
            picBank.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #region ContextMenu_Click_event
        private void BADeposit_Click(object sender, EventArgs e)
        {
            GetRefDeposit(153);
        }

        private void listBADeposit_Click(object sender, EventArgs e)
        {
            GetRefDeposit(4);
        }

        private void BAWithDraw_Click(object sender, EventArgs e)
        {
            GetRefDeposit(157);
        }

        private void listBAWithDraw_Click(object sender, EventArgs e)
        {
            GetRefDeposit(6);
        }
        private void BABankTransfer_Click(object sender, EventArgs e)
        {
            GetRefDeposit(162);
        }
        private void listBABankTransfer_Click(object sender, EventArgs e)
        {
            GetRefDeposit(5);
        }
        #endregion
        #region Hover_ContextMenuStrip_BADeposit_And_BAWithdraw
        private void contextMenuBADeposit_MouseLeave(object sender, EventArgs e)
        {
            contextMenuBADeposit.Hide();
            IsContextMenuStripShowing = false;
            picBADeposit.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;

        }
        private void contextMenuBAWithdraw_MouseLeave(object sender, EventArgs e)
        {
            contextMenuBAWithdraw.Hide();
            IsContextMenuStripShowing = false;
            picBAWithDraw.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picBADeposit_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuBADeposit.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuStripShowing = true;
        }

        private void picBAWithDraw_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuBAWithdraw.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuStripShowing = true;
        }
        private void contextMenuBABankTransfer_MouseLeave(object sender, EventArgs e)
        {
            contextMenuBABankTransfer.Hide();
            IsContextMenuStripShowing = false;
            picBABankTransfer.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picBABankTransfer_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuBABankTransfer.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuStripShowing = true;
        }

        #endregion

        #region Bo_góc
        private void UserControlDepositDesktop_SizeChanged(object sender, EventArgs e)
        {
            //Rectangle r1 = new Rectangle(0, 0, picBADeposit.Width, picBADeposit.Height);
            //System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            //int d = 25;
            //gp1.AddArc(r1.X, r1.Y, d, d, 180, 90);
            //gp1.AddArc(r1.X + r1.Width - d, r1.Y, d, d, 270, 90);
            //gp1.AddArc(r1.X + r1.Width - d, r1.Y + r1.Height - d, d, d, 0, 90);
            //gp1.AddArc(r1.X, r1.Y + r1.Height - d, d, d, 90, 90);
            //picBABankTransfer.Region = new Region(gp1);
            //picBADeposit.Region = new Region(gp1);
            //picBAWithDraw.Region = new Region(gp1);
            //picDepositReport.Region = new Region(gp1);

            //Rectangle r2 = new Rectangle(0, 0, picBank.Width, picBank.Height);
            //System.Drawing.Drawing2D.GraphicsPath gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            //int d2 = 25;
            //gp2.AddArc(r2.X, r2.Y, d2, d2, 180, 90);
            //gp2.AddArc(r2.X + r2.Width - d2, r2.Y, d2, d2, 270, 90);
            //gp2.AddArc(r2.X + r2.Width - d2, r2.Y + r2.Height - d2, d2, d2, 0, 90);
            //gp2.AddArc(r2.X, r2.Y + r2.Height - d2, d2, d2, 90, 90);
            //picBank.Region = new Region(gp2);
            //picAccountingObject.Region = new Region(gp2);
            //picEmployee.Region = new Region(gp2);
            fix_picture(ref picBank, 25);
            fix_picture(ref picAccountingObject, 25);
            fix_picture(ref picEmployee, 25);
            fix_picture(ref picBADeposit, 25);
            fix_picture(ref picBAWithDraw, 25);
            fix_picture(ref picBABankTransfer, 25);
            fix_picture(ref picDepositReport, 25);

            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 2);

        }
        /// <summary>
        /// Bo_goc
        /// </summary>
        /// <param name="PictureEdit"></param>
        /// <param name="Curvature"></param>
        public void fix_picture(ref PictureEdit PictureEdit, int Curvature)
        {
            Rectangle r = new Rectangle(0, 0, PictureEdit.Width, PictureEdit.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(r.X, r.Y, Curvature, Curvature, 180, 90);
            gp.AddArc(r.X + r.Width - Curvature, r.Y, Curvature, Curvature, 270, 90);
            gp.AddArc(r.X + r.Width - Curvature, r.Y + r.Height - Curvature, Curvature, Curvature, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - Curvature, Curvature, Curvature, 90, 90);
            PictureEdit.Region = new Region(gp);
        }
        /// <summary>
        /// Change RetanglePicbox_To_TrianglePicBox
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triangleTop"></param>
        public void Change_RetanglePicBox_To_TrianglePicBox(ref PictureBox p, int triangleTop)
        {
            Rectangle r = new Rectangle(0, 0, p.Width, p.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            switch (triangleTop)
            {
                case 1: //top
                    gp.AddPolygon(new Point[] {
                new Point(r.Width/2, 0),
                new Point(r.Width,r.Height),
                new Point(0, r.Height)
                });
                    p.Region = new Region(gp);
                    break;
                case 2: // right
                    gp.AddPolygon(new Point[] {
                new Point(0, 0),
                new Point(r.Width, r.Height/2),
                new Point(0,r.Height)
                });
                    p.Region = new Region(gp);
                    break;
                case 3: // bot
                    gp.AddPolygon(new Point[] {
                new Point(0, 0),
                new Point(r.Width,0),
                new Point(r.Width/2,r.Height)
                });
                    p.Region = new Region(gp);
                    break;
                case 4: // left
                    gp.AddPolygon(new Point[] {
                new Point(0, r.Height/2),
                new Point(r.Width,0),
                new Point(r.Width,r.Height)
                });
                    p.Region = new Region(gp);
                    break;


            }

        }

        #endregion

        private void picBABankTransfer_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}