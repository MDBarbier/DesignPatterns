using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies.SalesTax;
using StrategyPatternWithMethodDi.Business.Strategies.Invoice;
using System;
using static StrategyPattern.Business.Models.Order;

namespace StrategyPattern
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

            //Select strategy depending on the order, in this case where the shipping destination is
            SetupStrategies(order);

            //Exercise our strategy by calling the order.GetTax() method, which uses the chosen strategy to calculate tax
            Console.WriteLine($"The tax for the order in {order.ShippingDetails.DestinationCountry} is: {order.GetTax()}");

            //Finalize order using two of our different strategies as examples
            order.FinaliseOrder();
            order.FinaliseOrder();
        }

        /// <summary>
        /// Select the strategy depending on the desination country of the order
        /// </summary>
        /// <param name="order"></param>
        private static void SetupStrategies(Order order)
        {
            switch (order.ShippingDetails.DestinationCountry.ToLower())
            {
                case "us":
                    order.SalesTaxStrategy = new UsSalesTaxStretegy();
                    break;
                case "sweden":
                    order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
                    break;
                default:
                    throw new Exception("There is no implemented sales tax strategy for that destination");
            }
            
            switch (order.SelectedInvoiceMethod)
            {
                case InvoiceMethod.Email:
                    order.InvoiceStrategy = new EmailInvoiceStrategy();
                    break;
                case InvoiceMethod.Web:
                    order.InvoiceStrategy = new WebInvoiceStrategy();
                    break;
                case InvoiceMethod.File:
                    order.InvoiceStrategy = new FileInvoiceStrategy();
                    break;
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

            order.SelectedInvoiceMethod = Order.InvoiceMethod.Web;
            return order;
        }
    }
}
