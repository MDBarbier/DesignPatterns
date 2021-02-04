using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternDemo
{
    public class Service1: IService
    {
        public string GetData()
        {
            return "Data from service 1";
        }
    }
}
