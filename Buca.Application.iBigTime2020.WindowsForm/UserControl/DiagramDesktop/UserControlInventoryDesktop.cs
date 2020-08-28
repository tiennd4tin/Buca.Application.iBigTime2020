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
    public partial class UserControlInventoryDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        // khai báo 1 hàm delegate
        public delegate void GetRefTypeInventory(int refInventory, bool isDetail);
        // khai báo 1 kiểu hàm delegate
        public GetRefTypeInventory GetRefInventory;
        public Color colorHover { get; set; }
        public bool IsContextMenu_Showing = false;
        public UserControlInventoryDesktop()
        {
            InitializeComponent();

            colorHover = Color.FromArgb(225, 225, 225);
            tableLayoutPanel2.BackColor = colorHover;
            textBox2.BackColor = colorHover;
            textBox3.BackColor = colorHover;
            textBox5.BackColor = colorHover;
            textBox4.BackColor = colorHover;
            textBox1.BackColor = colorHover;

        }
        public void EditPicture(ref PictureBox pictureEdit, int Curvature)
        {
            Rectangle r = new Rectangle(0, 0, pictureEdit.Width, pictureEdit.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(r.X, r.Y, Curvature, Curvature, 180, 90);
            gp.AddArc(r.X + r.Width - Curvature, r.Y, Curvature, Curvature, 270, 90);
            gp.AddArc(r.X + r.Width - Curvature, r.Y + r.Height - Curvature, Curvature, Curvature, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - Curvature, Curvature, Curvature, 90, 90);
            pictureEdit.Region = new Region(gp);
        }
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

        private void UserControlInventoryDesktop_SizeChanged(object sender, EventArgs e)
        {
            EditPicture(ref pictureBox9, 25);
            EditPicture(ref picAccountingObject, 25);
            EditPicture(ref picCalPrice, 25);
            EditPicture(ref picInventory, 25);
            EditPicture(ref picInward, 25);
            EditPicture(ref picOutward, 25);
            EditPicture(ref picStaff, 25);
            EditPicture(ref picStock, 25);
            EditPicture(ref picTool, 25);

            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 2);
        }
        #region ContextMenu_&_Picture_Click_Event

        private void caPaymentInward_Click(object sender, EventArgs e)
        {
            GetRefInventory(107, true);
        }

        private void baWithDrawPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefInventory(158, true);
        }

        private void buTransferPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefInventory(57, true);
        }

        private void inInwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefInventory(201, true);
        }


        private void picOutward_Click(object sender, EventArgs e)
        {
            GetRefInventory(202, true);
        }

        private void addOutWardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefInventory(202, true);
        }

        private void listOutWardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefInventory(202, false);
        }

        private void picCalPrice_Click(object sender, EventArgs e)
        {
            GetRefInventory(6, true);
        }

        private void picAccountingObject_Click(object sender, EventArgs e)
        {
            GetRefInventory(1, true);
        }

        private void picStaff_Click(object sender, EventArgs e)
        {
            GetRefInventory(2, true);
        }

        private void picStock_Click(object sender, EventArgs e)
        {
            GetRefInventory(3, true);
        }

        private void picInventory_Click_1(object sender, EventArgs e)
        {
            GetRefInventory(4, true);
        }

        private void picTool_Click(object sender, EventArgs e)
        {
            GetRefInventory(5, true);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            GetRefInventory(500, true);
        }
        #endregion
        #region BackCorlor_Change
        private void picInward_MouseMove(object sender, MouseEventArgs e)
        {
            picInward.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picOutward_MouseMove(object sender, MouseEventArgs e)
        {
            picOutward.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picTool_MouseMove(object sender, MouseEventArgs e)
        {

            picTool.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picAccountingObject_MouseMove(object sender, MouseEventArgs e)
        {
            picAccountingObject.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picStaff_MouseMove(object sender, MouseEventArgs e)
        {
            picStaff.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picCalPrice_MouseMove(object sender, MouseEventArgs e)
        {
            picCalPrice.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picStock_MouseMove(object sender, MouseEventArgs e)
        {
            picStock.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox9.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;

        }
        private void picInventory_MouseMove(object sender, MouseEventArgs e)
        {
            picInventory.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picAccountingObject_MouseLeave(object sender, EventArgs e)
        {
            picAccountingObject.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picStaff_MouseLeave(object sender, EventArgs e)
        {
            picStaff.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picStock_MouseLeave(object sender, EventArgs e)
        {
            picStock.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picInventory_MouseLeave(object sender, EventArgs e)
        {
            picInventory.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picTool_MouseLeave(object sender, EventArgs e)
        {
            picTool.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picInward_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picInward.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picOutward_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picOutward.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picCalPrice_MouseLeave(object sender, EventArgs e)
        {
            picCalPrice.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }



        #endregion

        #region Hover_event
        private void contextOutward_MouseLeave(object sender, EventArgs e)
        {
            contextOutward.Hide();
            IsContextMenu_Showing = false;
            picOutward.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
            IsContextMenu_Showing = false;
            picInward.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picInward_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuStrip1.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picOutward_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextOutward.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }
        #endregion
    }
}
