using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    public class GLVoucherListPresenter : Presenter<IGLVoucherListView>
    {
        public GLVoucherListPresenter(IGLVoucherListView view) : base(view)
        {

        }

        public void Display(string refId)
        {
            var glVoucherList =
                Model.GetGLVoucherListByRefId(refId) ?? new GLVoucherListModel();
            View.RefId = glVoucherList.RefId;
            View.RefType = glVoucherList.RefType;
            View.RefDate = glVoucherList.RefDate;
            View.RefNo = glVoucherList.RefNo;
            View.VoucherTypeId = glVoucherList.VoucherTypeId;
            View.SetupType = glVoucherList.SetupType;
            View.FromDate = glVoucherList.FromDate;
            View.ToDate = glVoucherList.ToDate;
            View.Description = glVoucherList.Description;
            View.TotalAmount = glVoucherList.TotalAmount;
            View.EditVersion = glVoucherList.EditVersion;
            View.GlVoucherListDetails = glVoucherList.GlVoucherListDetails ?? new List<GLVoucherListDetailModel>();
        }

        public string Save()
        {
            var glVoucherList = new GLVoucherListModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                RefNo = View.RefNo,
                VoucherTypeId = View.VoucherTypeId,
                SetupType = View.SetupType,
                FromDate = View.FromDate,
                ToDate = View.ToDate,
                Description = View.Description,
                TotalAmount = View.TotalAmount,
                EditVersion = View.EditVersion,
                GlVoucherListDetails = View.GlVoucherListDetails

            };
            if (View.RefId == null)
                return Model.InsertGLVoucherList(glVoucherList);
            return Model.UpDateGLVoucherList(glVoucherList);
        }
        public string Delete(string refId)
        {
            return Model.DeleteGLVoucherList(refId);
        }
    }
}
