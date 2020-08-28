using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.CommonControl;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BAWithDraw;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset
{
    public partial class FrmSelectVoucher : Form
    {
        private string _fixedAssetId;
        public int ValueReturn;
        public int _source;
        public FrmSelectVoucher(string fixedAssetId,int source)
        {
            _fixedAssetId = fixedAssetId;
            _source = source;
            InitializeComponent();
            InitData();
        }

        private void FrmSelectVoucher_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void InitData()
        {
             if(_source == 3)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(1, "Mua tài sản cố định bằng chuyển khoản kho bạc"));
            }
            if (_source == 4 || _source == 5 || _source == 6 || _source == 7)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(2, "Mua tài sản cố định bằng tiền mặt"));
            }
            if (_source == 1 || _source == 4 || _source == 5 || _source == 6 || _source == 7)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(3, "Mua tài sản cố định bằng tiền gửi"));
            }
            if ( _source == 6 || _source == 7)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(4, "Mua tài sản cố định chưa thanh toán"));
            }
            if (_source == 8)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(5, "TSCĐ được biếu tặng"));
            }
            if (_source == 9)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(6, "TSCĐ được cấp trên cấp"));
            }
            if (_source == 2 || _source == 6)
            {
                rndOption.Properties.Items.Add(new RadioGroupItem(7, "Qua đầu tư XDCB"));
            }
            rndOption.EditValue = rndOption.Properties.Items[0].Value;
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            ValueReturn = Convert.ToInt32(rndOption.EditValue);
            DialogResult = DialogResult.OK;
            //switch (rndOption.EditValue.ToString())
            //{
            //    case "1":
            //        break;
            //    case "2":
            //        FrmCAPaymentFixedAssetDetail frmDetail = new FrmCAPaymentFixedAssetDetail(_fixedAssetId);
            //        frmDetail.ActionMode = ActionModeVoucherEnum.AddNew;
            //        frmDetail.ShowDialog();
            //        break;
            //    case "3":
            //        break;
            //    case "4":
            //        break;
            //    case "5":
            //        break;

            //}
            Close();
        }
    }
}
