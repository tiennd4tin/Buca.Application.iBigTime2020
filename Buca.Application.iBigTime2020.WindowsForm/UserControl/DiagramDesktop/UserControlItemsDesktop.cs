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
    public partial class UserControlItemsDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        public Color colorHover { get; set; }

        // khai báo 1 hàm delegate
        public delegate void GetRefTypeTools(int RefTypeTools, bool isDetail);
        // khai báo 1 kiểu hàm delegate
        public GetRefTypeTools GetRefTypeTool;

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
        public UserControlItemsDesktop()
        {
            InitializeComponent();
            colorHover = Color.FromArgb(225, 225, 225);
            tableLayoutPanel2.BackColor = colorHover;
           
            textBox14.BackColor = colorHover;
            textBox5.BackColor = colorHover;
            textBox12.BackColor = colorHover;
          
        }
        public bool IsContextMenuShowing = false;
        private void UserControlItemsDesktop_SizeChanged(object sender, EventArgs e)
        {
            EditPicture(ref picReport, 25);
            EditPicture(ref picDepartment, 25);
            EditPicture(ref picOpeningSupplyEntry, 25);
            EditPicture(ref picSUDecrement, 25);
            EditPicture(ref picSUIncrement, 25);
            EditPicture(ref picSUTransfer, 25);
            EditPicture(ref picStaff, 25);
            EditPicture(ref picTools, 25);

            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 2);
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

        #region BackCorlor_Event
        private void picOpeningSupplyEntry_MouseMove(object sender, MouseEventArgs e)
        {
            picOpeningSupplyEntry.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picSUDecrement_MouseMove(object sender, MouseEventArgs e)
        {
            picSUDecrement.BackColor =colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picReport_MouseMove(object sender, MouseEventArgs e)
        {
            picReport.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picSUIncrement_MouseMove(object sender, MouseEventArgs e)
        {
            picSUIncrement.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picSUTransfer_MouseMove(object sender, MouseEventArgs e)
        {
            picSUTransfer.BackColor = colorHover;
            Cursor.Current = Cursors.Hand;
        }
        private void picStaff_MouseMove(object sender, MouseEventArgs e)
        {
            picStaff.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picDepartment_MouseMove(object sender, MouseEventArgs e)
        {
            picDepartment.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picTools_MouseMove(object sender, MouseEventArgs e)
        {
            picTools.BackColor = Color.White;
            Cursor.Current = Cursors.Hand;
        }
        private void picSUDecrement_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuShowing)
            {
                return;
            }
            else
            {
                picSUDecrement.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picOpeningSupplyEntry_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuShowing)
            {
                return;
            }
            else
            {
                picOpeningSupplyEntry.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picReport_MouseLeave(object sender, EventArgs e)
        {
            picReport.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picSUIncrement_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuShowing)
            {
                return;
            }
            else
            {
                picSUIncrement.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picSUTransfer_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenuShowing)
            {
                return;
            }
            else
            {
                picSUTransfer.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picStaff_MouseLeave(object sender, EventArgs e)
        {
            picStaff.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picDepartment_MouseLeave(object sender, EventArgs e)
        {
            picDepartment.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picTools_MouseLeave(object sender, EventArgs e)
        {
            picTools.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #region Click_Event
        private void addSUIncrementCCDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(205, true);
        }

        private void listSUIncrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(205, false);
        }

        private void picSUIncrement_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(205, true);
        }


        private void picSUDecrement_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(206, true);
        }

        private void addSUDecrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(206, true);
        } 

        private void listSUDecrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(206, false);
        }

      
        private void picOpeningSupplyEntry_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(602, true);
        }

        private void addOpeningSupplyEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(602, true);
        }

        private void listOpeningSupplyEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(602, false);
        }

        private void picSUTransfer_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(207, true);
        }

        private void addSUTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(207, true);
        }

        private void listSUTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(207, false);
        }

        private void picReport_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(500, true);
        }

        private void picStaff_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(1, true);
        }

        private void picDepartment_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(2, true);
        }

        private void picTools_Click(object sender, EventArgs e)
        {
            GetRefTypeTool(3, true);
        }
        #endregion
        #region Hover_Event
        private void picOpeningSupplyEntry_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuOpeningSupplyEntry.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuShowing = true;
        }

        private void picSUDecrement_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextSUDecrement.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuShowing = true;
        }

        private void picSUTransfer_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextSUTransfer.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuShowing = true;
        }

        private void picSUIncrement_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextSUIncrement.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenuShowing = true;

        }

        private void contextSUDecrement_MouseLeave(object sender, EventArgs e)
        {
            contextSUDecrement.Hide();
            IsContextMenuShowing = false;
            picSUDecrement.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextMenuOpeningSupplyEntry_MouseLeave(object sender, EventArgs e)
        {
            contextMenuOpeningSupplyEntry.Hide();
            IsContextMenuShowing = false;
            picOpeningSupplyEntry.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextSUTransfer_MouseLeave(object sender, EventArgs e)
        {
            contextSUTransfer.Hide();
            IsContextMenuShowing = false;
            picSUTransfer.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextSUIncrement_MouseLeave(object sender, EventArgs e)
        {
            contextSUIncrement.Hide();
            IsContextMenuShowing = false;
            picSUIncrement.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}
