using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    public class GLPaymentListPresenter : Presenter<IGLPaymentListView>
    {
        public GLPaymentListPresenter(IGLPaymentListView view) : base(view)
        {

        }

        public void Display(string refId)
        {
            var glVoucherList =
                Model.GetGLPaymentListByRefId(refId) ?? new GLPaymentListModel();
            View.RefId = glVoucherList.RefId;
            View.RefType = glVoucherList.RefType;
            View.RefDate = glVoucherList.RefDate;
            View.PostedDate = glVoucherList.PostedDate;
            View.RefNo = glVoucherList.RefNo;
            View.VoucherTypeId = glVoucherList.VoucherTypeId;
            View.SetupType = glVoucherList.SetupType;
            View.FromDate = glVoucherList.FromDate;
            View.ToDate = glVoucherList.ToDate;
            View.Description = glVoucherList.Description;
            View.TotalAmount = glVoucherList.TotalAmount;
            View.EditVersion = glVoucherList.EditVersion;
            View.GLPaymentListDetails = glVoucherList.GLPaymentListDetails ?? new List<GLPaymentListDetailModel>();
        }

        public string Save()
        {
            var glPaymentList = new GLPaymentListModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                VoucherTypeId = View.VoucherTypeId,
                SetupType = View.SetupType,
                FromDate = View.FromDate,
                ToDate = View.ToDate,
                Description = View.Description,
                TotalAmount = View.TotalAmount,
                EditVersion = View.EditVersion,
                GLPaymentListDetails = View.GLPaymentListDetails

            };
            if (View.RefId == null)
                return Model.InsertGLPaymentList(glPaymentList);
            return Model.UpDateGLPaymentList(glPaymentList);
        }
        public string Delete(string refId)
        {
            return Model.DeleteGLPaymentList(refId);
        }
    }
}
