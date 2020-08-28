using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.UserControl.DiagramDesktop
{
    public partial class UserControlSalaryDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        // khai báo 1 hàm delegate
        public delegate void GetRefTypeSalary(int refSalary, bool isDetail);
        // khai báo 1 kiểu hàm delegate
        public GetRefTypeSalary GetRefSalary;
        public Color colorHover { get; set; }

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
        public UserControlSalaryDesktop()
        {

            InitializeComponent();
            colorHover = Color.FromArgb(207, 208, 209);
            tableLayoutPanel2.BackColor = colorHover;
            textBox2.BackColor = colorHover;
            textBox3.BackColor = colorHover;
            textBox5.BackColor = colorHover;
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void picTimeSheet_MouseLeave(object sender, EventArgs e)
        {
            picTimeSheet.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picTimeSheet_MouseMove(object sender, MouseEventArgs e)
        {
            picTimeSheet.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void pictOTSheet_MouseLeave(object sender, EventArgs e)
        {
            pictOTSheet.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void pictOTSheet_MouseMove(object sender, MouseEventArgs e)
        {
            pictOTSheet.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picEditSalary_MouseLeave(object sender, EventArgs e)
        {
            picEditSalary.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picEditSalary_MouseMove(object sender, MouseEventArgs e)
        {
            picEditSalary.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picPaySalary_MouseLeave(object sender, EventArgs e)
        {
            picPaySalary.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picPaySalary_MouseMove(object sender, MouseEventArgs e)
        {
            picPaySalary.BackColor = colorHover;
            Cursor.Current = Cursors.Default;

        }

        private void picEditTreasuary_MouseLeave(object sender, EventArgs e)
        {
            picEditTreasuary.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picEditTreasuary_MouseMove(object sender, MouseEventArgs e)
        {
            picEditTreasuary.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picPayTreasuary_MouseLeave(object sender, EventArgs e)
        {
            picPayTreasuary.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picPayTreasuary_MouseMove(object sender, MouseEventArgs e)
        {
            picPayTreasuary.BackColor = colorHover;
            Cursor.Current = Cursors.Default;

        }

        private void picCalSalary_MouseLeave(object sender, EventArgs e)
        {
            picCalSalary.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picCalSalary_MouseMove(object sender, MouseEventArgs e)
        {
            picCalSalary.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void tableLayoutPanel1_StyleChanged(object sender, EventArgs e)
        {
            EditPicture(ref picStaff, 25);
            EditPicture(ref picCalSalary, 25);
            EditPicture(ref picDepartment, 25);
            EditPicture(ref picEditSalary, 25);
            EditPicture(ref picEditTreasuary, 25);
            EditPicture(ref picPaySalary, 25);
            EditPicture(ref picPayTreasuary, 25);
            EditPicture(ref picSalary, 25);
            EditPicture(ref picTimeSheet, 25);
            EditPicture(ref pictOTSheet, 25);
        }

        private void picStaff_MouseLeave(object sender, EventArgs e)
        {
            picStaff.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picStaff_MouseMove(object sender, MouseEventArgs e)
        {
            picStaff.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }

        private void picDepartment_MouseLeave(object sender, EventArgs e)
        {
            picDepartment.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picDepartment_MouseMove(object sender, MouseEventArgs e)
        {
            picDepartment.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }

        private void picSalary_MouseLeave(object sender, EventArgs e)
        {
            picSalary.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picSalary_MouseMove(object sender, MouseEventArgs e)
        {
            picSalary.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }

        private void picStaff_Click(object sender, EventArgs e)
        {
            GetRefSalary(1, true);
        }

        private void picDepartment_Click(object sender, EventArgs e)
        {
            GetRefSalary(2, true);
        }

        private void UserControlSalaryDesktop_SizeChanged(object sender, EventArgs e)
        {
            EditPicture(ref picStaff, 25);
            EditPicture(ref picCalSalary, 25);
            EditPicture(ref picDepartment, 25);
            EditPicture(ref picEditSalary, 25);
            EditPicture(ref picEditTreasuary, 25);
            EditPicture(ref picPaySalary, 25);
            EditPicture(ref picPayTreasuary, 25);
            EditPicture(ref picSalary, 25);
            EditPicture(ref picTimeSheet, 25);
            EditPicture(ref pictOTSheet, 25);

            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox1, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox2, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox4, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox5, 2);

        }
    }

}
