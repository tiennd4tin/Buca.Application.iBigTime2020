
using System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.View.System;

namespace Buca.Application.iBigTime2020.Presenter.System.Lock
{
   public class LockPresenter: Presenter<ILockView>
    {
       public LockPresenter(ILockView view)
            : base(view)
        {

        }
       public void Display()
       {
            var site = Model.GetLock();
            View.Content = site.Content;
            View.IsLock = site.IsLock;
            View.LockDate = site.LockDate;

        }

       public string Save()
       {
            var model = new LockModel
            {
                Content = View.Content,
                LockDate = View.LockDate,
                IsLock = View.IsLock
            };
            return Model.SaveLock(model);
            //return null;
       }

       public bool CheckLockDate (string refId,int refTypeId)
       {
            var obj = Model.CheckLock(refId, refTypeId);
            return obj.IsLock;
            //return false;
       }

       public bool CheckLockDate(string refId, int refTypeId,DateTime refDate)
       {
            var obj = Model.CheckLock(refId, refTypeId, refDate);
            return obj.IsLock;
            //return false;
       }

    }
}
