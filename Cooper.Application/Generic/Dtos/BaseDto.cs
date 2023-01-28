using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Generic.Dtos
{
    public interface IBaseDto
    {
        int? Id { get; set;}
    }
    public class BaseDto : IBaseDto
    {
        public int? Id { get ; set; }
    }
}
