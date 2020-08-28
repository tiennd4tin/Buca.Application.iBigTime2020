/***********************************************************************
 * <copyright file="FrmEmployeeTypes.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 2, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.EmployeeType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.EmployeeType
{
    /// <summary>
    ///     FrmEmployeeTypes
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IEmployeeTypesView" />
    public partial class FrmEmployeeTypes : FrmBaseList, IEmployeeTypesView
    {
        private readonly EmployeeTypesPresenter _employeeTypesPresenter;

        public FrmEmployeeTypes()
        {
            InitializeComponent();
            _employeeTypesPresenter = new EmployeeTypesPresenter(this);
        }

        /// <summary>
        ///     Gets or sets the employee models.
        /// </summary>
        /// <value>
        ///     The employee models.
        /// </value>
        public IList<EmployeeTypeModel> EmployeeTypes
        {
            set
            {
                grdList.DataSource = value;
                gridView.PopulateColumns();

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "EmployeeTypeId",
                    ColumnVisible = false,
                    ColumnPosition = 1,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "EmployeeTypeCode",
                    ColumnCaption = "Mã loại cán bộ",
                    ColumnVisible = true,
                    ColumnPosition = 1,
                    ColumnWith = 50,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "EmployeeTypeName",
                    ColumnCaption = "Tên loại cán bộ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 70,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = true,
                    ColumnPosition = 3,
                    ColumnWith = 100,
                    AllowEdit = false,
                    ColumnCaption = @"Diễn giải"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Được sử dụng",
                    ColumnVisible = true,
                    ColumnPosition = 4,
                    ColumnWith = 20,
                    AllowEdit = false
                });
            }
        }

        #region override methods

        /// <summary>
        ///     Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _employeeTypesPresenter.Display();
        }

        /// <summary>
        ///     Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new EmployeeTypePresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        ///     Gets the form detail.
        ///     LinhMC comment method này lại.
        /// </summary>
        /// <returns>
        ///     FrmXtraBaseCategoryDetail.
        /// </returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmEmployeeTypeDetail();
        }

        #endregion
    }
}