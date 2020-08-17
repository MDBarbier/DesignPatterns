using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StrategyPatternWithMethodDi.Business.Strategies.Invoice
{
    class FileInvoiceStrategy : BaseInvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var fileContents = base.GenerateTextInvoice(order);

            using (var stream = new StreamWriter($"invoice_{DateTime.Now.ToShortDateString()}.txt"))
            {
                stream.Write(fileContents);

                stream.Flush();
            }
        }
    }
}
