using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.IncrementDecrement;

namespace Buca.Application.iBigTime2020.Presenter.IncrementDecrement
{
  public  class SUTransfersPresenter : Presenter<ISUTransfersView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SUIncrementDecrementsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
      public SUTransfersPresenter(ISUTransfersView view)
          : base(view)
        {
        }
        
        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.SUTransfers = Model.GetSUTransfers();
        }

        /// <summary>
        /// Displays the specified reference type.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void Display(int refType)
        {
            View.SUTransfers = Model.GetSUTransfersByRefTypeId(refType);
        }
    }
}
