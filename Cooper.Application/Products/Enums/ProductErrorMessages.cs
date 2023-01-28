using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Products.Enums
{
    internal enum ProductErrorMessages
    {
        [Description("El producto con el Id {ID} no existe")]
        ProductDosntExists
    }

    internal enum ProductErrorMessageKeys
    {
        [Description("{ID}")]
        Id
    }
}
