using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset
{
    public partial class FrmFixedAssetParameter : FrmXtraBaseParameter
    {
        public FrmFixedAssetParameter()
        {
            InitializeComponent();
        }

        public int SelectedValue
        {
            get { return (int)cboSource.SelectedIndex ; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
