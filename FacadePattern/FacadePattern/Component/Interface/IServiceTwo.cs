using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.Component.Interface
{
    internal interface IServiceTwo
    {
        internal void SendNotification(string message, int id);
    }
}
