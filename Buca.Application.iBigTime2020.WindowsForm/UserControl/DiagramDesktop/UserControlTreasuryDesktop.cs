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
    public partial class UserControlTreasuryDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        public Color colorHover { get; set; }

        public delegate void GetRefTreasury(int RefTypeTreasury, bool isDetail);
        // khai báo 1 kiểu hàm delegate
        public GetRefTreasury GetRefTypeTreasury;
        public bool IsContextMenu_Showing = false;
        public UserControlTreasuryDesktop()
        {
            InitializeComponent();
            colorHover = Color.FromArgb(225, 225, 225);
            tableLayoutPanel2.BackColor = colorHover;
            textBox2.BackColor = colorHover;
            textBox14.BackColor = colorHover;
            textBox5.BackColor = colorHover;
            textBox12.BackColor = colorHover;
            textBox13.BackColor = colorHover;
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

        #region BackCorlor_Event
        private void picBUPlanReceipt_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picBUPlanReceipt.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picBUPlanAdjustment_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picBUPlanAdjustment.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picBUPlanCancel_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picBUPlanCancel.BackColor = Color.Transparent;
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
        private void picBudgetSource_MouseLeave(object sender, EventArgs e)
        {
            picBudgetSource.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picBudgetChapter_MouseLeave(object sender, EventArgs e)
        {
            picBudgetChapter.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picBUBudgetReserve_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picBUBudgetReserve.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picBuTransfer_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picBuTransfer.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picBuPlanWitthDraw_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picBuPlanWitthDraw.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picCommitment_MouseLeave(object sender, EventArgs e)
        {
            if (IsContextMenu_Showing)
            {
                return;
            }
            else
            {
                picCommitment.BackColor = Color.Transparent;
                Cursor.Current = Cursors.Default;
            }
        }
        private void picBank_MouseLeave(object sender, EventArgs e)
        {
            picBank.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picBudgetItems_MouseLeave(object sender, EventArgs e)
        {
            picBudgetItems.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        private void picBudgetKindItem_MouseLeave(object sender, EventArgs e)
        {
            picBudgetKindItem.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void picBUPlanReceipt_MouseMove(object sender, MouseEventArgs e)
        {
            picBUPlanReceipt.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picBUPlanAdjustment_MouseMove(object sender, MouseEventArgs e)
        {
            picBUPlanAdjustment.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picBUPlanCancel_MouseMove(object sender, MouseEventArgs e)
        {
            picBUPlanCancel.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picBuPlanWitthDraw_MouseMove(object sender, MouseEventArgs e)
        {
            picBuPlanWitthDraw.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }
        private void picCommitment_MouseMove(object sender, MouseEventArgs e)
        {
            picCommitment.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picBuTransfer_MouseMove(object sender, MouseEventArgs e)
        {
            picBuTransfer.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picBUBudgetReserve_MouseMove(object sender, MouseEventArgs e)
        {
            picBUBudgetReserve.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picReport_MouseMove(object sender, MouseEventArgs e)
        {
            picReport.BackColor = colorHover;
            Cursor.Current = Cursors.Default;
        }

        private void picBudgetSource_MouseMove(object sender, MouseEventArgs e)
        {
            picBudgetSource.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }
        private void picBudgetChapter_MouseMove(object sender, MouseEventArgs e)
        {
            picBudgetChapter.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }

        private void picBudgetItems_MouseMove(object sender, MouseEventArgs e)
        {
            picBudgetItems.BackColor =Color.White;
            Cursor.Current = Cursors.Default;
        }
        private void picBank_MouseMove(object sender, MouseEventArgs e)
        {
            picBank.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }
        private void picBudgetKindItem_MouseMove(object sender, MouseEventArgs e)
        {
            picBudgetKindItem.BackColor = Color.White;
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #region Pic_Click_event
        private void picBUPlanReceipt_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(51, true);
        }
        private void picBUBudgetReserve_Click(object sender, EventArgs e)
        {
          //  GetRefTypeTreasury(73, true);
        }
        private void picBUPlanCancel_Click(object sender, EventArgs e)
        {
            //GetRefTypeTreasury(69, true);
        }
        private void picBUPlanAdjustment_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(53, true);
        }
        private void picBudgetSource_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(1, false);
        }

        private void picBudgetChapter_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(2, false);
        }

        private void picBudgetKindItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(3, false);
        }

        private void picBudgetItems_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(4, false);
        }

        private void picBank_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(5, false);
        }
        #endregion
        #region CotextMenu_click_event
        private void CommitmentRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(71, true);

        }
        private void CommitmentAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(72, true);

        }
        private void OpeningCommitmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(606, true);
        }
        private void listBUPlanReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(51, false);
        }

        private void addBUPlanAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(53, true);
        }
        private void addBUPlanReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(51, true);
        }

        private void listBUPlanAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(53, false);
        }
        private void addBUPlanCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(69, true);
        }

        private void listBUPlanCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(69, false);
        }

        private void BUPlanWithdrawCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(54, true);
        }

        private void BUPlanWithdrawDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(562, true);
        }

        private void BUPlanWithdrawTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(55, true);
        }

        private void BUPlanWithdrawTransferInsurranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(563, true);
        }

        private void BUTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(56, true);

        }

        private void BUTransferDepositsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(561, true);
        }

        private void BUTransfersPayWageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(60, true);
        }

        private void BUTransfersPayInsurranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(61, true);
        }
        private void addBUBudgetReserveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(73, true);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(73, false);
        }

        private void no01SDKPĐVDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(500, true);
        }

        private void no02SDKPĐVDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRefTypeTreasury(500, false);
        }
        #endregion
        private void UserControlTreasuryDesktop_SizeChanged(object sender, EventArgs e)
        {
            EditPicture(ref picReport,25);
            EditPicture(ref picBUBudgetReserve,25);
            EditPicture(ref picBUPlanAdjustment,25);
            EditPicture(ref picBUPlanCancel,25);
            EditPicture(ref picBUPlanReceipt,25);
            EditPicture(ref picBank,25);
            EditPicture(ref picBuPlanWitthDraw,25);
            EditPicture(ref picBuTransfer,25);
            EditPicture(ref picBudgetChapter,25);
            EditPicture(ref picBudgetItems,25);
            EditPicture(ref picBUBudgetReserve,25);
            EditPicture(ref picBUPlanAdjustment,25);
            EditPicture(ref picBUPlanCancel,25);
            EditPicture(ref picBUPlanReceipt,25);
            EditPicture(ref picBudgetKindItem,25);
            EditPicture(ref picBudgetSource,25);
            EditPicture(ref picCommitment,25);

            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox1, 3);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox3, 1);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox2, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox4, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox5, 2);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox6, 3);
            Change_RetanglePicBox_To_TrianglePicBox(ref pictureBox7, 1);
        }
        #region Hover_event
        private void picBUPlanAdjustment_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextBUPlanAdjustment.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picBUPlanReceipt_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextBUPlanReceipt.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picBUPlanCancel_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextBUPlanCancel.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picBuPlanWitthDraw_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextBuPlanWitthDraw.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picCommitment_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextCommitment.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picBuTransfer_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextBuTransfer.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picBUBudgetReserve_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextBUBudgetReserve.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void picReport_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            contextReport.Show(MousePosition.X - 10, MousePosition.Y - 10);
            IsContextMenu_Showing = true;
        }

        private void contextBUPlanReceipt_MouseLeave(object sender, EventArgs e)
        {
            contextBUPlanReceipt.Hide();
            IsContextMenu_Showing = false;
            picBUPlanReceipt.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextBUPlanAdjustment_MouseLeave(object sender, EventArgs e)
        {
            contextBUPlanAdjustment.Hide();
            IsContextMenu_Showing = false;
            picBUPlanAdjustment.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextBUPlanCancel_MouseLeave(object sender, EventArgs e)
        {
            contextBUPlanCancel.Hide();
            IsContextMenu_Showing = false;
            picBUPlanCancel.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextBuPlanWitthDraw_MouseLeave(object sender, EventArgs e)
        {
            contextBuPlanWitthDraw.Hide();
            IsContextMenu_Showing = false;
            picBuPlanWitthDraw.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextCommitment_MouseLeave(object sender, EventArgs e)
        {
            contextCommitment.Hide();
            IsContextMenu_Showing = false;
            picCommitment.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextBuTransfer_MouseLeave(object sender, EventArgs e)
        {
            contextBuTransfer.Hide();
            IsContextMenu_Showing = false;
            picBuTransfer.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextBUBudgetReserve_MouseLeave(object sender, EventArgs e)
        {
            contextBUBudgetReserve.Hide();
            IsContextMenu_Showing = false;
            picBUBudgetReserve.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }

        private void contextReport_MouseLeave(object sender, EventArgs e)
        {
            contextReport.Hide();
            IsContextMenu_Showing = false;
            picReport.BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}
