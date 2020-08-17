using StrategyPattern.Business.Strategies.Invoice;
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
        public ISalesTaxStrategy SalesTaxStrategy { get; set; }
        public IInvoiceStrategy InvoiceStrategy { get; set; }
        public InvoiceMethod SelectedInvoiceMethod { get; set; }

        public Order()
        {
            LineItems = new List<Item>();
        }

        public decimal GetTax()
        {
            return SalesTaxStrategy.GetTaxFor(this);
        }

        public void FinaliseOrder()
        {          
            InvoiceStrategy.Generate(this);
        }

        public enum InvoiceMethod
        {
            Email,Web,File
        }
    }
}
