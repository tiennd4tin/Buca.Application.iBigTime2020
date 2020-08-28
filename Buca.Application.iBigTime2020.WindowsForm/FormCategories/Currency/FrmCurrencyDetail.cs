using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Currency
{
    public partial class FrmCurrencyDetail : FrmXtraBaseCategoryDetail, ICurrencyView
    {
        private readonly CurrencyPresenter _currencyPresenter;
        public FrmCurrencyDetail()
        {
            InitializeComponent();
            _currencyPresenter = new CurrencyPresenter(this);
        }
        protected override void InitData()
        {
            if (KeyValue != null)
                _currencyPresenter.Display(KeyValue);
            else
                chkIsActive.Checked = true;
        }
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(CurrencyCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCurrencyCode"),
                              ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(CurrencyName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCurrencyName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyName.Focus();
                return false;
            }
            return true;
        }
        protected override string SaveData()
        {
            return _currencyPresenter.Save();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtCurrencyCode.Focus();
        }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode
        {
            get
            {
                return txtCurrencyCode.Text;
            }
            set
            {
                txtCurrencyCode.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>The name of the currency.</value>
        public string CurrencyName
        {
            get
            {
                return txtCurrencyName.Text;
            }
            set
            {
                txtCurrencyName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix
        {
            get
            {
                return txtPrefix.Text;
            }
            set
            {
                txtPrefix.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        public string Suffix
        {
            get
            {
                return txtSuffix.Text;
            }
            set
            {
                txtSuffix.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is main.
        /// </summary>
        /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        public bool IsMain
        {
            get
            {
                return chkMain.Checked;
            }
            set
            {
                chkMain.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get
            {
                return chkIsActive.Checked;
            }
            set
            {
                chkIsActive.Checked = value;
            }
        }

    }
}
