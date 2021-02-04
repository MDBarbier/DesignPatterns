using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternDemo
{
    public class Adapter1 : IAdapter
    {
        IService service1 = new Service1();
        public string GetData()
        {
            return service1.GetData();
        }
    }
}
