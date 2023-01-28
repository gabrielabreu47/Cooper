using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }
    }
}
