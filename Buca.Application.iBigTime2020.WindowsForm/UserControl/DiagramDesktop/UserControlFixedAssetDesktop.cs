using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace Buca.Application.iBigTime2020.WindowsForm.UserControl.DiagramDesktop
{

    public partial class UserControlFixedAssetDesktop : DevExpress.XtraEditors.XtraUserControl
    {

        public bool IsContextMenu_Showing = false;
        public Color colorHover { get; set; }

        public int RefTypeVoucher { get; set; }
        public UserControlFixedAssetDesktop()
        {
            InitializeComponent();
            colorHover = Color.FromArgb(225, 225, 225);
            tableLayoutPanel2.BackColor = colorHover;
            textBox2.BackColor = colorHover;
            textBox3.BackColor = colorHover;
            textBox5.BackColor = colorHover;
        }
        // khai báo 1 hàm delegate
        public delegate void GetRefTypeFixedAsset(int RefTypeFixedAsset,bool isDetail);
        // khai báo 1 kiểu hàm delegate
        public GetRefTypeFixedAsset GetRefFixedAsset;


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
         private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }



        #region Context_Menu_Click_Event

        private void addFADecrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(253, true);
        }

        private void listFADecrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(253, false);
        }


        private void addFADevaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(419, true);
        }

        private void listFADevaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(419, false);
        }



        private void listFADepreciationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(255, false);
        }

        private void addFADepreciationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(255, true);
        }
        private void addIncreDecreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(252, true);
        }

        private void listIncreDecreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(252, false);
        }

        private void caPaymentFixedAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(108, true);
        }

        private void baWithDrawFixedAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(159, true);
        }

        private void BUTransferFixedAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(58, true);
        }

        private void PUDetailFixedAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(251, true);
        }


        private void addRevaluationOfFixedAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(254, true);
        }

        private void listRevaluationOfFixedAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(254, false);
        }
        #endregion
        #region Back_Color_Change
        private void picIncreDecre_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            picIncreDecre.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picRevaluationOfFixedAssets_MouseMove(object sender, MouseEventArgs e)
        {
            picRevaluationOfFixedAssets.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picFADecrement_MouseMove(object sender, MouseEventArgs e)
        {
            picFADecrement.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picFADevaluation_MouseMove(object sender, MouseEventArgs e)
        {
            picFADevaluation.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picFADepreciations_MouseMove(object sender, MouseEventArgs e)
        {
            picFADepreciations.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picReport_MouseMove(object sender, MouseEventArgs e)
        {
            picReport.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picFACategory_MouseMove(object sender, MouseEventArgs e)
        {
            picFACategory.BackColor = Color.White;
        }
        private void picFA_MouseMove(object sender, MouseEventArgs e)
        {
            picFA.BackColor = Color.White;
        }
        private void picDepartment_MouseMove(object sender, MouseEventArgs e)
        {
            picDepartment.BackColor = Color.White;
        }
        private void picFADepreciations_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picFADepreciations.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picReport_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picReport.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picDepartment_MouseLeave(object sender, EventArgs e)
        {
            picDepartment.BackColor = colorHover;
        }

        private void picFACategory_MouseLeave(object sender, EventArgs e)
        {
            picFACategory.BackColor = colorHover;
        }

        private void picFADevaluation_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picFADevaluation.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picFA_MouseLeave(object sender, EventArgs e)
        {
                picFA.BackColor = colorHover;        
        }

        private void picIncreDecre_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picIncreDecre.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void picRevaluationOfFixedAssets_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picRevaluationOfFixedAssets.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                pictureBox2.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picFADecrement_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picFADecrement.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }


        #endregion
        #region Pic_Click_Event

        private void picFA_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(3, true);
        }
        private void picFACategory_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(2, true);
        }
        private void picDepartment_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(1, true);
        }
        private void picReport_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(500, true);
        }
        private void picFADepreciations_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(255, true);
        }

        private void picFADevaluation_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(419, true);
        }

        private void picRevaluationOfFixedAssets_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(254, true);
        }
        private void picFADecrement_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(253, true);
        }
        private void picIncreDecre_Click(object sender, EventArgs e)
        {
            //GetRefFixedAsset(252, true);
        }
        #endregion
        #region bo_goc & tao_mui_ten
        private void UserControlFixedAssetDesktop_SizeChanged(object sender, EventArgs e)
        {
            EditPicture(ref pictureBox2,25);
            EditPicture(ref picReport,25);
            EditPicture(ref picDepartment,25);
            EditPicture(ref picFA,25);
            EditPicture(ref picFACategory,25);
            EditPicture(ref picFADecrement,25);
            EditPicture(ref picFADepreciations,25);
            EditPicture(ref picFADevaluation,25);
            EditPicture(ref picIncreDecre,25);
            EditPicture(ref picRevaluationOfFixedAssets,25);

            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox1, 3);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox4, 3);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox5, 3);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox6, 1);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox7, 1);

        }
        #endregion
        #region Hover_Event
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuStrip2.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picIncreDecre_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextMenuStrip1.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picRevaluationOfFixedAssets_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextRevaluationOfFixedAssets.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picFADecrement_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextFADecrement.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picFADevaluation_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextFADevaluation.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }
        private void picFADepreciations_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextFADepreciations.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
            IsContextMenu_Showing = false;
            picIncreDecre.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void contextRevaluationOfFixedAssets_MouseLeave(object sender, EventArgs e)
        {
            contextRevaluationOfFixedAssets.Hide();
            IsContextMenu_Showing = false;
            picRevaluationOfFixedAssets.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextFADecrement_MouseLeave(object sender, EventArgs e)
        {
            contextFADecrement.Hide();
            IsContextMenu_Showing = false;
            picFADecrement.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextFADevaluation_MouseLeave(object sender, EventArgs e)
        {
            contextFADevaluation.Hide();
            IsContextMenu_Showing = false;
            picFADevaluation.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextFADepreciations_MouseLeave(object sender, EventArgs e)
        {
            contextFADepreciations.Hide();
            IsContextMenu_Showing = false;
            picFADepreciations.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextMenuStrip2_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip2.Hide();
            IsContextMenu_Showing = false;
            pictureBox2.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}
