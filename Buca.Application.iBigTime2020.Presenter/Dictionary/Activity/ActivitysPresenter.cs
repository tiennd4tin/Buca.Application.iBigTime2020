using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Activity
{
    public class ActivitysPresenter : Presenter<IActivitysView>
    {
        /// <param name="view">The view.</param>
        public ActivitysPresenter(IActivitysView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Activitys = Model.GetActivitys();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive(bool isActive)
        {
            View.Activitys = Model.GetActivitysActive(isActive);
        }
    }
}
