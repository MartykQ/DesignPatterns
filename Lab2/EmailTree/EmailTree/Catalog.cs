using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTree
{
    class Catalog : IComponent
    {
        private List<IComponent> _childList;
        private string _name;

        public List<IComponent> ChildList { get => _childList; set => _childList = value; }
        public string Name { get => _name; set => _name = value; }

        public Catalog(string name)
        {
            this._name = name;
            this._childList = new List<IComponent>();
        }
        public Catalog(string name, List<IComponent> childList)
        {
            this._name = name;
            this._childList = childList;
        }
        public decimal CalculateSize()
        {
            decimal totalSize = 0;
            foreach (IComponent comp in ChildList)
            {
                totalSize += comp.CalculateSize();
            }
            return totalSize;
        }

        public string DisplayStructure(string prefix="")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{prefix}******");
            sb.AppendLine();
            sb.AppendLine($"{prefix}Catalog: {this._name}");
            sb.AppendLine();
            sb.AppendLine();

            foreach (IComponent comp in this._childList)
            {
                string newPrefix = prefix + "             ";
                sb.AppendLine($"{prefix}|");
                sb.AppendLine($"{prefix}|");
                sb.AppendLine($"{prefix}|___");
                sb.AppendLine($"{comp.DisplayStructure(newPrefix)}");
            }

            return sb.ToString();

        }
    }
}
