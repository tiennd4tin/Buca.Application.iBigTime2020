using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.PurchasePurpose
{
    public partial class FrmPurchasePurposeDetail : FrmXtraBaseCategoryDetail, IPurchasePurposeView
    {
        /// <summary>
        /// The _purchasePurpose presenter
        /// </summary>
        private readonly PurchasePurposePresenter _purchasePurposePresenter;

        #region Property PurchasePurpose
        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string PurchasePurposeId { get; set; }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string PurchasePurposeCode
        {
            get { return txtPurchasePurposeCode.Text.Trim(); }
            set { txtPurchasePurposeCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string PurchasePurposeName
        {
            get { return txtPurchasePurposeName.Text.Trim(); }
            set { txtPurchasePurposeName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public bool IsActive
        {
            get { return chkActive.Checked; }
            set { chkActive.Checked = value; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmPurchasePurposeDetail"/> class.
        /// </summary>
        public FrmPurchasePurposeDetail()
        {
            InitializeComponent();
            _purchasePurposePresenter = new PurchasePurposePresenter(this);

        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _purchasePurposePresenter.Display(KeyValue);
            else
                txtPurchasePurposeCode.Text = GetAutoNumber();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtPurchasePurposeCode.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            return _purchasePurposePresenter.Save();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(PurchasePurposeCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPurchasePurposeCode"),
                                ResourceHelper.GetResourceValueByName("ResPurchasePurposeCode"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurchasePurposeCode.Focus();
                return false;
            }

            if (_purchasePurposePresenter.GetPurchasePurposeByCode(KeyValue, PurchasePurposeCode) != null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPurchasePurposeCodeDuplicate"),
                    ResourceHelper.GetResourceValueByName("ResPurchasePurposeCodeDuplicate"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurchasePurposeCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(PurchasePurposeName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPurchasePurposeName"),
                                ResourceHelper.GetResourceValueByName("ResPurchasePurposeName"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurchasePurposeName.Focus();
                return false;
            }

            return true;
        }
    }
}
