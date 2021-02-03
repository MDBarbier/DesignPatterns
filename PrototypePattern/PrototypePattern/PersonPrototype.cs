using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public abstract class PersonPrototype
    {
        public abstract PersonPrototype ShallowCopy();
        public abstract PersonPrototype DeepCopy();
        public abstract void Debug();
    }
}
