﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;

namespace Buca.Application.iBigTime2020.View.System
{
    public interface IDashBoardCashView : IView
    {
        IList<DashBoardCashModel> DashBoardCash { set; }
    }
}
