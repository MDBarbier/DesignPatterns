using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternDemo
{
    class Service2 : IService
    {
        public string GetData()
        {
            return "Data from service 2";
        }
    }
}
