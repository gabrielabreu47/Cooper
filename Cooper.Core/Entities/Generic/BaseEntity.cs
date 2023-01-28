using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Core.Entities.Generic
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
