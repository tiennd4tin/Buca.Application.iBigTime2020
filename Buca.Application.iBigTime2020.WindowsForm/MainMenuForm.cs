using System.Drawing;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using DevExpress.XtraNavBar;

namespace Buca.Application.iBigTime2020.WindowsForm
{
    public partial class MainMenuForm : DevExpress.XtraEditors.XtraForm
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void navBarControl1_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            var navBar = sender as NavBarControl;
            if (navBar == null)
                return;
            Cursor.Current = Cursors.WaitCursor;
            if (!e.Group.Expanded)
            {
                e.Group.Expanded = true;
            }
            if (e.Group.Caption == "")
            {
               
            }
        }

        private void navBarControl1_MouseDown(object sender, MouseEventArgs e)
        {
            navBarControl1.ActiveGroup = null;
            if (e.Button != MouseButtons.Left)
                return;
            var navBar = sender as NavBarControl;
            if (navBar == null)
                return;
            var hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
            if (!hitInfo.InLink)
                return;
            switch (hitInfo.Link.ItemName)
            {
                case "navBarItem3":
                    var xtraUser = new FrmBaseList {Dock = DockStyle.Fill};
                    panelControl4.Controls.Add(xtraUser);
                    break;
                case "":
                    break;
            }
        }
    }
}