using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate.AutoVoucher
{
    public partial class FrmAutoInsurrance : Form
    {
        public List<BUTransferDetailModel> ListSendSourceDetail1;
        public List<BUTransferDetailModel> ListSendSourceDetail2;

        public bool IsOpenFrmBUTransferPayWageDetail;
        public BUTransferModel buTTransferModel;
        private ActionModeVoucherEnum _actionMode;


        public FrmAutoInsurrance()
        {
            InitializeComponent();
        }

        private void AutoVoucher_Load(object sender, EventArgs e)
        {
            ischeck = true;
        }
        public ActionModeVoucherEnum ActionMode
        {
            get { return _actionMode; }
            set
            {
                _actionMode = value;

                switch (_actionMode)
                {
                    case ActionModeVoucherEnum.None:

                        break;
                    case ActionModeVoucherEnum.Edit:

                        break;
                    case ActionModeVoucherEnum.AddNew:

                        break;
                    case ActionModeVoucherEnum.DuplicateVoucher:

                        break;
                }
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PayWageRefID))
            {
                DialogResult dialog = DialogResult.No;
                switch (ActionMode)
                {
                    case ActionModeVoucherEnum.AddNew:
                        dialog = XtraMessageBox.Show("Bạn có muốn tạo chứng từ chuyển khoản trả lương không?", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    case ActionModeVoucherEnum.Edit:
                        if (!string.IsNullOrEmpty(PayWageRefID))
                            dialog = XtraMessageBox.Show("Bạn có muốn đồng bộ các thông tin đã cập nhật trên giấy rút với chuyển khoản trả lương?", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            dialog = XtraMessageBox.Show("Bạn có muốn tạo chứng từ chuyển khoản trả lương không?", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                }
            }
            if (rbt_BUTransfersPayWage.Checked ==true)
            {
                var frmBUTransfersPayWageDetail = new FrmBUTransfersPayWageDetail();
                frmBUTransfersPayWageDetail.ActionMode = string.IsNullOrEmpty(PayWageRefID) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                frmBUTransfersPayWageDetail.KeyValue = string.IsNullOrEmpty(PayWageRefID) ? null : PayWageRefID;
                frmBUTransfersPayWageDetail.ListSendSourceDetail = ListSendSourceDetail1;
                frmBUTransfersPayWageDetail.IsOpenFrmBUTransferPayWageDetail = true;
                frmBUTransfersPayWageDetail.buTTransferModel = buTTransferModel;
                frmBUTransfersPayWageDetail.ShowDialog();
            }
            if (rbt_BUTransfersPayWageBH.Checked == true)
            {
                var frmBUTransfersPayWageDetail = new FrmBUTransfersPayWageDetail();
                frmBUTransfersPayWageDetail.ActionMode = string.IsNullOrEmpty(PayWageRefID) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                frmBUTransfersPayWageDetail.KeyValue = string.IsNullOrEmpty(PayWageRefID) ? null : PayWageRefID;
                frmBUTransfersPayWageDetail.ListSendSourceDetail = ListSendSourceDetail2;
                frmBUTransfersPayWageDetail.IsOpenFrmBUTransferPayWageDetail = true;
                frmBUTransfersPayWageDetail.buTTransferModel = buTTransferModel;
                frmBUTransfersPayWageDetail.ShowDialog();
            }

        }

        public string PayWageRefID { get; set; }

        public bool ischeck { get; set; }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbt_BUTransfersPayWage_CheckedChanged(object sender, EventArgs e)
        {
            ischeck = true;
        }

        private void rbt_BUTransfersPayWageBH_CheckedChanged(object sender, EventArgs e)
        {
            ischeck = false;
        }
        //protected override bool ValidEdit()
        //{
        //    if (!string.IsNullOrEmpty(PayWageRefID))
        //        return XtraMessageBox.Show("Giấy rút dự toán hiện tại đã sinh chứng từ chuyển khoản kho bạc trả lương. Bạn có muốn sửa giấy rút này không?", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
        //    return true;
        //}
    }
}
