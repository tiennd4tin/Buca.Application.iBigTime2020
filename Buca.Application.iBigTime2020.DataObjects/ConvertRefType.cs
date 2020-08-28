using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess
{
    public class ConvertRefType
    {
        public int ConvRefType(int? reftype)
        {
            switch (reftype)
            {
                case 56:
                    return 56;
                case 59:
                    return 56;
                case 101:
                    return 101;
                case 102:
                    return 202;
                case 103:
                    return 253;
                case 104:
                    return 101;
                case 106:
                    return 106;
                case 109:
                    return 106;
                case 110:
                    return 106;
                case 153:
                    return 153;
                case 154:
                    return 202;
                case 155:
                    return 253;
                case 156:
                    return 153;
                case 157:
                    return 157;
                case 160:
                    return 157;
                case 163:
                    return 157;
                case 201:
                    return 201;
                case 211:
                    return 201;
                case 213:
                    return 201;
                case 301:
                    return 201;
                case 352:
                    return 201;
                case 202:
                    return 202;
                case 212:
                    return 202;
                case 214:
                    return 202;
                case 351:
                    return 202;
                case 253:
                    return 253;
                case 256:
                    return 253;
                case 401:
                    return 401;
                case 405:
                    return 401;
                case 151:
                    return 401;
                case 152:
                    return 401;
                case 551: return 1002;
                case 552: return 1002;
                case 553: return 1002;
                case 554: return 1002;
                case 555: return 1002;
                case 556: return 1002;
                case 557: return 1002;
                case 558: return 1002;
                case 559: return 1002;
            }
            return reftype ?? 0;
        }
    }
}
