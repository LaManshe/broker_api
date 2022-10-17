using borker_api.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_apiTests
{
    public class MyRateComparer : IEqualityComparer<Rate>
    {
        public bool Equals(Rate x, Rate y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.Date == y.Date && x.RUB == y.RUB;
        }

        public int GetHashCode(Rate obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeDate = obj.Date == null ? 0 : obj.Date.GetHashCode();
            int hasCodeRub = obj.RUB.GetHashCode();

            return hashCodeDate ^ hasCodeRub;
        }
    }
}
