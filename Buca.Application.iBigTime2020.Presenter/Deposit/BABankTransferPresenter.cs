using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.View.Deposit;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Deposit
{
    public class BABankTransferPresenter : Presenter<IBABankTransferView>
    {
        public BABankTransferPresenter(IBABankTransferView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {

            var bABankTransfer = Model.GetBABankTransfer(refId) ?? new BABankTransferModel();

            View.RefId = bABankTransfer.RefId;
            View.RefType = bABankTransfer.RefType;
            View.RefDate = bABankTransfer.RefDate;
            View.PostedDate = bABankTransfer.PostedDate;
            View.RefNo = bABankTransfer.RefNo;
            View.ParalellRefNo = bABankTransfer.ParalellRefNo;
            View.JournalMemo = bABankTransfer.JournalMemo;
            View.Posted = bABankTransfer.Posted;
            View.PostVersion = bABankTransfer.PostVersion;
            View.EditVersion = bABankTransfer.EditVersion;
            View.TotalAmountOC = bABankTransfer.TotalAmountOC;
            View.BABankTransferDetails = bABankTransfer.BABankTransferDetail;
            View.BABankTransferDetailParallels = bABankTransfer.BABankTransferDetailParallels;
            View.CurrencyCode = bABankTransfer.CurrencyCode;
            View.ExchangeRate = bABankTransfer.ExchangeRate;
            View.TotalAmount = bABankTransfer.TotalAmount;

        }
        public string Save()
        {
            var bABankTransfer = new BABankTransferModel
            {

                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOC = View.TotalAmountOC,
                BABankTransferDetail = View.BABankTransferDetails

            };
            return View.RefId == null ? Model.InsertBABankTransfer(bABankTransfer) : Model.UpdateBABankTransfer(bABankTransfer);
        }

        /// <summary>
        /// Saves the specified .
        /// </summary>
        /// <param name="isAutoGenerateParallel">The is automatic generate parallel.</param>
        /// <returns>System.String.</returns>
        public string Save(bool isAutoGenerateParallel)
        {
            var bABankTransfer = new BABankTransferModel
            {

                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                Posted = View.Posted,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOC = View.TotalAmountOC,
                BABankTransferDetail = View.BABankTransferDetails,
                BABankTransferDetailParallels = View.BABankTransferDetailParallels
            };
            return View.RefId == null ? Model.InsertBABankTransfer(bABankTransfer, isAutoGenerateParallel) :
                Model.UpdateBABankTransfer(bABankTransfer, isAutoGenerateParallel);
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteBABankTransfer(refId);
        }

        /// <summary>
        /// References the no is exist.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RefNoIsExist(string refId, string refNo, int refType)
        {
            var bankTranfer = Model.GetBABankTransfers()
                .Where(x => x.RefId != refId && x.RefNo == refNo && x.RefType == refType).ToList();
            return bankTranfer.Any();
        }
    }


}
