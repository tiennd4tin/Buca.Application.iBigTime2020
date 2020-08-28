using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess
{
    public class ConvertCashWithdrawType
    {
        public int ConvertCash(int? CashWithdrawID)
        {
            switch (CashWithdrawID)
            {
                case 2:
                    return 1;
                case 3:
                    return 2;
                case 4:
                    return 3;
                case 6:
                    return 4;
                case 7:
                    return 20;
                case 8:
                    return 21;
                case 9:
                    return 5;
                case 10:
                    return 22;
                case 12:
                    return 6;
                case 13:
                    return 7;
                case 15:
                    return 8;
                case 16:
                    return 9;
                case 24:
                    return 10;
                case 30:
                    return 11;
                case 31:
                    return 12;
                case 33:
                    return 13;
                case 36:
                    return 14;
                case 39:
                    return 15;
                case 42:
                    return 16;
                case 45:
                    return 17;
                case 46:
                    return 23;
                case 50:
                    return 24;
            }
            return 0;
        }
    }
}
