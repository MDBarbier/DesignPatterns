using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
