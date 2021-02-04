using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternDemo
{
    public class Adapter2: IAdapter
    {
        IService service2 = new Service2();
        public string GetData()
        {
            return service2.GetData();
        }
    }
}
