using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropiaWebAuc.Domain.Entities
{
    public interface IItem
    {

        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
