using StrategyPattern.Business.Models;

namespace StrategyPatternWithMethodDi.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
