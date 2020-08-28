using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory
{

    public class FixedAssetCategoriesPresenter : Presenter<IFixedAssetCategoriesView>
    {
        public FixedAssetCategoriesPresenter(IFixedAssetCategoriesView view) : base(view)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public void Display()
            {
            View.FixedAssetCategories = Model.GetFixedAssetCategories();
            }
    }

}