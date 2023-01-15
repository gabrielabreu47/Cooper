using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Bills.Enums
{
    public enum BillStatus
    {
        [Description("Facturada")]
        Invoiced,
        [Description("Pendiente de pago")]
        Pending,
        [Description("Eliminada")]
        Deleted
    }
}
