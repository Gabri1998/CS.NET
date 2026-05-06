using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CashFlowTracker.Models
{
    public record Transaction(DateTime Date, decimal Amount, Category Category, string Description);
}
