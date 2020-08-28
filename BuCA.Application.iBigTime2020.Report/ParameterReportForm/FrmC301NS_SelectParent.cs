using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmC301NS_SelectParent : Form
    {
        public bool IsParent
        {
            get { return rad1.Checked ? true : false; }
        }

        public FrmC301NS_SelectParent()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
