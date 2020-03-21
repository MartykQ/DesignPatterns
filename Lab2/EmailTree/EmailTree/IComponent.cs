using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTree
{
    public interface IComponent
    {
        string DisplayStructure(string prefix);
        decimal CalculateSize();
    }
}
