using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternDemo
{
    public class Adapter3 : Service3, IService
    {
        public override string GetData()
        {
            var data = base.GetData();

            data = data + " ... some extra data added by Adapter3";

            return data;
        }
    }
}
