using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternWithMethodDi.Business.Strategies.Invoice
{
    /// <summary>
    /// This BaseInvoiceStrategy class implements our interface and specifies some commonly used functionality.
    /// 
    /// The Generate method is abstract so classes inheriting from this base class must implement it themselves
    /// </summary>
    public abstract class BaseInvoiceStrategy : IInvoiceStrategy
    {
        public abstract void Generate(Order order);

        public string GenerateTextInvoice(Order order)
        {
            var total = 0.0m;

            foreach (var item in order.LineItems)
            {
                total += item.ItemPrice;
            }

            var tax = order.GetTax(SelectTaxStrategy(order));

            return $"DESTINATION: {order.ShippingDetails.DestinationCountry}, NET PRICE: {total}, TAX: {tax}, TOTAL PRICE: {total + tax}";
        }

        private ISalesTaxStrategy SelectTaxStrategy(Order order)
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
    }

    
}
