using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternDemo
{
    public class Service3 : IService
    {
        public virtual string GetData()
        {            
            return "Data from service 3";
        }
    }
}
