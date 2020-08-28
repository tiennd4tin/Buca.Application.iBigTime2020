using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormUtility
{
    public partial class FrmAutoBusiness : Form, IAutoBusinessesView
    {
        private readonly AutoBusinessesPresenter _autoBusinessesPresenter;

        public delegate void EventPostAutoBusinessHandler(object sender, AutoBusinessModel autoBusinessModel);
        public event EventPostAutoBusinessHandler PostAutoBusinessHandler;

        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <value>The automatic businesses.</value>
        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                var autoBusinesses = value.Where(v => v.RefTypeId == RefTypeId).ToList();
                grdAutoBusiness.DataSource = autoBusinesses;
                grdAutoBusinessView.PopulateColumns(autoBusinesses);
                grdAutoBusinessView.BestFitColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AutoBusinessId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AutoBusinessCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AutoBusinessName",
                        ColumnVisible = true,
                        ColumnWith = grdAutoBusiness.Width - 100 - 100,
                        ColumnCaption = "Tên định khoản",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 3,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                    },
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };
                grdAutoBusinessView.InitGridLayout(columnsCollection);
            }
        }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAutoBusiness" /> class.
        /// </summary>
        public FrmAutoBusiness()
        {
            InitializeComponent();
            _autoBusinessesPresenter = new AutoBusinessesPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmAutoBusiness control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmAutoBusiness_Load(object sender, EventArgs e)
        {
            try
            {
                _autoBusinessesPresenter.DisplayByRefTypeId(RefTypeId, true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnApply control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdAutoBusinessView.RowCount > 0)
                {
                    CloseForm();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm()
        {
            using (new FrmXtraBaseVoucherDetail())
            {
                var autoBusinessModel = (AutoBusinessModel)grdAutoBusinessView.GetFocusedRow();
                // ReSharper disable once UseNullPropagation
                if (PostAutoBusinessHandler != null) PostAutoBusinessHandler(this, autoBusinessModel);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void grdAutoBusinessView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdAutoBusinessView.RowCount > 0)
                {
                    CloseForm();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
