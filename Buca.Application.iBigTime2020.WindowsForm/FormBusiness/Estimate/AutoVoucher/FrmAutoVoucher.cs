
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using Buca.Application.iBigTime2020.Model;
using BuCA.Enum;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate.AutoVoucher
{

    public partial class FrmAutoVoucher : Form
    {
        public List<BUTransferDetailModel> ListSendSourceDetail1;
        public List<BUTransferDetailModel> ListSendSourceDetail2;

        public bool IsOpenFrmBUTransferPayWageDetail;
        public BUTransferModel buTTransferModel;
        private ActionModeVoucherEnum _actionMode;
        public int RefType { get; set; }


        public FrmAutoVoucher()
        {
            InitializeComponent();
        }

        private void AutoVoucher_Load(object sender, EventArgs e)
        {
            ischeck = true;
            IModel model = new Model.Model();
            var payWage = model.GetBUTransferbyRefId(PayWageRefID);
            int refType = 0;
            if (payWage != null)
            {
                refType = payWage.RefType;
            }

            switch (refType)
            {
                case (int)BuCA.Enum.RefType.BUTransferPayWage:

                    rbt_BUTransfersPayWage.Checked = true;
                    rbt_BUTransfersPayWageBH.Enabled = false;
                   
                    break;

                case (int)BuCA.Enum.RefType.BUTransferPayInsurrance:
                    rbt_BUTransfersPayWage.Enabled = false;
                    rbt_BUTransfersPayWageBH.Checked = true;

                   
                    break;
            }

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
            DialogResult dialog = DialogResult.No;
            IModel model = new Model.Model();

            var payWage = model.GetBUTransferbyRefId(PayWageRefID);
            int refType = 0;
            if (payWage != null)
            {
                refType=payWage.RefType ;
            }

            if (ActionMode == ActionModeVoucherEnum.Edit)
            {
                //DialogResult dialog = DialogResult.No;

                switch (refType)
                {
                    case (int)BuCA.Enum.RefType.BUTransferPayWage:


                        if (!string.IsNullOrEmpty(PayWageRefID))
                            dialog = XtraMessageBox.Show(
                                "Bạn có muốn đồng bộ các thông tin đã cập nhật trên giấy rút với chuyển khoản trả lương?",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            dialog = XtraMessageBox.Show(
                                "Bạn có muốn tạo chứng từ chuyển khoản trả lương không?",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    case (int)BuCA.Enum.RefType.BUTransferPayInsurrance:


                        if (!string.IsNullOrEmpty(PayWageRefID))
                            dialog = XtraMessageBox.Show(
                                "Bạn có muốn đồng bộ các thông tin đã cập nhật trên giấy rút với chuyển khoản trả bảo hiểm?",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            dialog = XtraMessageBox.Show(
                                "Bạn có muốn tạo chứng từ chuyển khoản trả lương bảo hiểm?",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                }
            }
            else if(ActionMode == ActionModeVoucherEnum.AddNew)
            {
                if (rbt_BUTransfersPayWage.Checked == true)
                {
                    dialog = XtraMessageBox.Show("Bạn có muốn tạo chứng từ chuyển khoản trả lương không?",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                }
                else if (rbt_BUTransfersPayWageBH.Checked == true)
                {
                    dialog = XtraMessageBox.Show("Bạn có muốn tạo chứng từ chuyển khoản trả bảo hiểm không?",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                }
            }

            if (rbt_BUTransfersPayWage.Checked == true && dialog == DialogResult.Yes && (refType == (int)BuCA.Enum.RefType.BUTransferPayWage||string.IsNullOrEmpty(PayWageRefID)))
            {
                var frmBUTransfersPayWageDetail = new FrmBUTransfersPayWageDetail();
                frmBUTransfersPayWageDetail.ActionMode = string.IsNullOrEmpty(PayWageRefID) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                frmBUTransfersPayWageDetail.KeyValue = string.IsNullOrEmpty(PayWageRefID) ? null : PayWageRefID;
                frmBUTransfersPayWageDetail.ListSendSourceDetail = ListSendSourceDetail1;
                frmBUTransfersPayWageDetail.IsOpenFrmBUTransferPayWageDetail = true;
                frmBUTransfersPayWageDetail.buTTransferModel = buTTransferModel;
                frmBUTransfersPayWageDetail.ShowDialog();
            }
            if (rbt_BUTransfersPayWageBH.Checked == true && dialog == DialogResult.Yes && (refType == (int)BuCA.Enum.RefType.BUTransferPayInsurrance||string.IsNullOrEmpty(PayWageRefID)))
            {
                var frmBUTransfersPayInsurranceDetail = new FrmBUTransfersPayInsurranceDetail();
                frmBUTransfersPayInsurranceDetail.ActionMode = string.IsNullOrEmpty(PayWageRefID) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                frmBUTransfersPayInsurranceDetail.KeyValue = string.IsNullOrEmpty(PayWageRefID) ? null : PayWageRefID;
                frmBUTransfersPayInsurranceDetail.ListSendSourceDetail = ListSendSourceDetail2;
                frmBUTransfersPayInsurranceDetail.IsOpenFrmBUTransferPayWageDetail = true;
                frmBUTransfersPayInsurranceDetail.buTTransferModel = buTTransferModel;
                frmBUTransfersPayInsurranceDetail.ShowDialog();

            }
            this.Close();
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
