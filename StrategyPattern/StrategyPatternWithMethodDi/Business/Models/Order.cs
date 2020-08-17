using StrategyPattern.Business.Strategies.SalesTax;
using StrategyPatternWithMethodDi.Business.Strategies.Invoice;
using System;
using System.Collections.Generic;

namespace StrategyPattern.Business.Models
{
    public class Order
    {        
        public ShippingDetails ShippingDetails { get; internal set; }
        public List<Item> LineItems { get; internal set; }                

        public Order()
        {
            LineItems = new List<Item>();
        }

        public decimal GetTax(ISalesTaxStrategy salesTaxStrategy)
        {
            if (salesTaxStrategy == null)
            {
                throw new Exception("Sales tax strategy is not defined");
            }

            return salesTaxStrategy.GetTaxFor(this);
        }        

        public void FinaliseOrder(IInvoiceStrategy invoiceStrategy)
        {
            invoiceStrategy.Generate(this);
        }
    }
}
