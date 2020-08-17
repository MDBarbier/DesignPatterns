using FacadePattern.Component.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.Component.Implementation
{
    internal class ServiceTwo : IServiceTwo
    {
        void IServiceTwo.SendNotification(string message, int id)
        {
            //no action
        }
    }
}
