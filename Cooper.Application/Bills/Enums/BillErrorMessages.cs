using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Bills.Enums
{
    internal enum BillErrorMessages
    {
        [Description("No existen suficientes {PRODUCT} en el inventario")]
        InsufficientStock
    }

    internal enum BillErrorMessageKeys
    { 
        [Description("{PRODUCT}")]
        Product
    }
}
