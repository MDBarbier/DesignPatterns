using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class PrototypeManager
    {
        private Dictionary<string, PersonPrototype> PrototypeLibrary = new Dictionary<string, PersonPrototype>();

        public PersonPrototype this[string key]
        {
            get { return PrototypeLibrary[key]; }
            set { PrototypeLibrary.Add(key,value); }
        }
    }
}
