
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Activity
{
    public class ActivityPresenter : Presenter<IActivityView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ActivityPresenter(IActivityView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified bank identifier.
        /// </summary>
        /// <param name="careerWorkId">The bank identifier.</param>
        public void Display(string activityId)
        {
            if (activityId == null) { View.ActivityId = null; return; }

            var activity = Model.GetActivity(activityId);

            View.ActivityId = activity.ActivityId;
            View.ActivityCode = activity.ActivityCode;
            View.ActivityName = activity.ActivityName;
            View.ParentID = activity.ParentID;
            View.IsActive = activity.IsActive;
            View.IsSystem = activity.IsSystem;
            View.IsParent = activity.IsParent;
            View.Grade = activity.Grade;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var Activity = new ActivityModel
            {
                ActivityId = View.ActivityId,
                ActivityCode = View.ActivityCode,
                ActivityName = View.ActivityName,
                ParentID = View.ParentID,
                IsActive = View.IsActive,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsSystem = View.IsSystem
            };

            if (View.ActivityId == null)
                return Model.AddActivity(Activity);
            return Model.UpdateActivity(Activity);
        }

        /// <summary>
        /// Deletes the specified bank identifier.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        public string Delete(string careerWorkId)
        {
            return Model.DeleteActivity(careerWorkId);
        }
        public bool CodeIsExist(string activityId, string activityCode)
        {
            var activity = Model.GetActivitys()
                .Where(x => x.ActivityId != activityId && x.ActivityCode == activityCode).ToList();
            return activity.Any();
        }
    }
}
