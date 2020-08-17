using StrategyPattern;
using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies.SalesTax;
using StrategyPatternWithMethodDi.Business.Strategies.Invoice;
using System;

namespace StrategyPatternWithMethodDi
{
    /// <summary>
    /// Demo app for the Strategy Pattern
    /// 
    /// In essence this pattern just uses an abstraction of a service of some type, by means of an interface, so that different strategies can be selected at runtime.
    /// 
    /// In this demo, Tax is calculated for an order at runtime based on the country the order is detined for - the strategies represent the tax calulations for Sweden and the US
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Preparation, set up an order with some dummy data, and set the Destination country as Sweden
            Order order = SetupOrder();

            //Exercise our strategy by calling the order.GetTax() method, which uses the chosen strategy to calculate tax
            Console.WriteLine($"The tax for the order in {order.ShippingDetails.DestinationCountry} is: {order.GetTax(SelectStrategy(order))}");

            //Finalize order using two of our different strategies as examples
            order.FinaliseOrder(new EmailInvoiceStrategy());
            order.FinaliseOrder(new WebInvoiceStrategy());            
        }

        /// <summary>
        /// Select the strategy depending on the desination country of the order
        /// </summary>
        /// <param name="order"></param>
        private static ISalesTaxStrategy SelectStrategy(Order order)
        {
            switch (order.ShippingDetails.DestinationCountry.ToLower())
            {
                case "us":
                   return new UsSalesTaxStretegy();                    
                case "sweden":
                    return new SwedenSalesTaxStrategy();                    
                default:
                    throw new Exception("There is no implemented sales tax strategy for that destination");
            }
        }

        /// <summary>
        /// Setup order with dummy data
        /// </summary>
        /// <returns></returns>
        private static Order SetupOrder()
        {
            var order = new Order()
            {
                ShippingDetails = new ShippingDetails()
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("C_SHARP_SHMORG", "C Sharp Shmorgasbord", 147m, ItemType.Literature));
            order.LineItems.Add(new Item("REACT_JS", "React Js Manual", 84m, ItemType.Literature));
            return order;
        }
    }
}
