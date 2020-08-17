using FacadePattern.Component.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.Component.Implementation
{
    internal class ServiceOne : IServiceOne
    {
        string IServiceOne.GetUserName(int userId)
        {
            return $"Username for {userId}";
        }
    }
}
