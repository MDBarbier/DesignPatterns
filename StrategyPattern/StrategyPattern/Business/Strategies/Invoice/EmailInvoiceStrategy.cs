using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternWithMethodDi.Business.Strategies.Invoice
{
    class EmailInvoiceStrategy : BaseInvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var emailBody = base.GenerateTextInvoice(order);

            Console.WriteLine($"This is the email that will be sent: \n {emailBody}");
        }
    }
}
