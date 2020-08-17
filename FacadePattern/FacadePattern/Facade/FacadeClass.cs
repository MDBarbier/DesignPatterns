using FacadePattern.Component.Implementation;
using FacadePattern.Component.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.Facade
{
    /// <summary>
    /// This facade class gives a client the ability to access the functionality of the two services without having direct access to the services
    /// </summary>
    public class FacadeClass
    {        
        private IServiceOne ServiceOne { get; set; }
        private IServiceTwo ServiceTwo { get; set; }

        public FacadeClass()
        {
            ServiceOne = new ServiceOne();
            ServiceTwo = new ServiceTwo();
        }

        public string GetUserNameById(int id)
        {
            return ServiceOne.GetUserName(id);
        }

        public void SendNotification(string content, int id)
        {
            ServiceTwo.SendNotification(content, id);
        }
    }
}
