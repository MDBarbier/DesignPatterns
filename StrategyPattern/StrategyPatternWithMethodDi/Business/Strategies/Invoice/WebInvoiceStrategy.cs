using Newtonsoft.Json;
using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace StrategyPatternWithMethodDi.Business.Strategies.Invoice
{
    /// <summary>
    /// In this strategy we implement the interface rather than inherit the base class because we don't need the text based order functionality, we want to display the order as JSON
    /// </summary>
    class WebInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(order);

                //This is an example of posting to a fictional web service
                //client.PostAsync("https://somewebservice/upload", new StringContent(json));

                Console.WriteLine($"This is the json that would be sent: {json.ToString()}");
            }
        }
    }
}
