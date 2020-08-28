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
    public partial class UserControlCashDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlCashDesktop()
        {
            InitializeComponent();
        }
        public delegate void GetRefTypeCash(int refCash);
        public GetRefTypeCash GetRefCash;
        private bool IsContextMenuShowing = false;
        public static Color BackCorlor = Color.FromArgb(225,225,225);
        #region Pic_Mouse_Click_Event
        private void picCACash_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefCash(500);
        }

        private void picBank_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefCash(3);
        }

        private void picEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefCash(2);
        }

        private void picAccountingObject_MouseClick(object sender, MouseEventArgs e)
        {
            GetRefCash(1);
        }
        private void picCAReceipt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuCAReceipt.Show(MousePosition);
                return;
            }
            else if (e.Button == MouseButtons.Left)
            {
                GetRefCash(101);
                return;
            }
            else return;
        }
        private void picCAPayment_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuCAPayment.Show(MousePosition);
                return;
            }
            else if (e.Button == MouseButtons.Left)
            {
                GetRefCash(106);
                return;
            }
            else return;
        }
#endregion

        #region Pic_Backcolor_event

        
        private void picCAReceipt_MouseMove(object sender, MouseEventArgs e)
        {
            picCAReceipt.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;

        }

        private void picCAPayment_MouseMove(object sender, MouseEventArgs e)
        {
            picCAPayment.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;
        }

        private void picCACash_MouseMove(object sender, MouseEventArgs e)
        {
            picCACash.BackColor = BackCorlor;
            Cursor.Current = Cursors.Hand;
        }

        private void picCAReceipt_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuShowing)
            {
                return;
            }
            else
            {
                picCAReceipt.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picCAPayment_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuShowing)
            {
                return;
            }
            else
            {
                picCAPayment.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picCACash_MouseLeave(object sender, EventArgs e)
        {
            picCACash.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picAccountingObject_MouseMove(object sender, MouseEventArgs e)
        {
            picAccountingObject.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }

        private void picEmployee_MouseMove(object sender, MouseEventArgs e)
        {
            picEmployee.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }

        private void picBank_MouseMove(object sender, MouseEventArgs e)
        {
            picBank.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
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

        #region ContextMenu__Click_Event
        private void CAReceipt_Click(object sender, EventArgs e)
        {
            GetRefCash(101);
        }
        private void CAPaymentTreasury_Click(object sender, EventArgs e)
        {
            GetRefCash(114);
        }
        private void CAReceiptEstimate_Click(object sender, EventArgs e)
        {
            GetRefCash(105);
        }
        private void listCAReceipt_Click(object sender, EventArgs e)
        {
            GetRefCash(4);
        }
        private void CAPayment_Click(object sender, EventArgs e)
        {
            GetRefCash(106);
        }
        private void CAPaymentEstimate_Click(object sender, EventArgs e)
        {
            GetRefCash(113);
        }
        private void listCAPayment_Click(object sender, EventArgs e)
        {
            GetRefCash(5);
        }



        #endregion

        #region HoverEvent_For_Receipt_And_Payment
        private void picCAReceipt_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            picCAReceipt.ContextMenuStrip.Show(MousePosition.X-10, MousePosition.Y-10);
            IsContextMenuShowing = true;
        }

        private void picCAPayment_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuCAPayment.Show(MousePosition.X-10, MousePosition.Y-10);
            IsContextMenuShowing = true;
        }

        private void contextMenuCAReceipt_MouseLeave(object sender, EventArgs e)
        {
            picCAReceipt.ContextMenuStrip.Hide();
            IsContextMenuShowing = false;
            picCAReceipt.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextMenuCAPayment_MouseLeave(object sender, EventArgs e)
        {
            picCAPayment.ContextMenuStrip.Hide();
            IsContextMenuShowing = false;
            picCAPayment.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Bo_góc & tạo mũi tên
        private void UserControlCashDesktop_SizeChanged(object sender, EventArgs e)
        {
            //Rectangle r1 = new Rectangle(0, 0, picCACash.Width, picCACash.Height);
            //System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            //int d = 25;
            //gp1.AddArc(r1.X, r1.Y, d, d, 180, 90);
            //gp1.AddArc(r1.X + r1.Width - d, r1.Y, d, d, 270, 90);
            //gp1.AddArc(r1.X + r1.Width - d, r1.Y + r1.Height - d, d, d, 0, 90);
            //gp1.AddArc(r1.X, r1.Y + r1.Height - d, d, d, 90, 90);
            //picCAReceipt.Region = new Region(gp1);
            //picCACash.Region = new Region(gp1);
            //picCAPayment.Region = new Region(gp1);

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
            fix_picture(ref picCAReceipt, 25);
            fix_picture(ref picCACash, 25);
            fix_picture(ref picCAPayment, 25);
            fix_picture(ref picBank, 25);
            fix_picture(ref picAccountingObject, 25);
            fix_picture(ref picEmployee, 25);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 2);

        }

        /// <summary>
        /// Bo goc
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
        /// Change Retangle_PictureEdit to Triangle_PictureEdit
        /// </summary>
        /// <param name="pictureEdit"></param>
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
    }
}
