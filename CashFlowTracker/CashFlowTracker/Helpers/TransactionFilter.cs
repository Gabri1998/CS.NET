using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CashFlowTracker.Models;



namespace CashFlowTracker.Helpers;

public static class TransactionFilter
{
    // Filter by exact date (ignores time)
    public static List<Transaction> ByDate(IEnumerable<Transaction> transactions, DateTime date)
    {
        return transactions.Where(t => t.Date.Date == date.Date).ToList();
    }

    // Filter by month (year and month must match)
    public static List<Transaction> ByMonth(IEnumerable<Transaction> transactions, DateTime monthStart)
    {
        return transactions
            .Where(t => t.Date.Year == monthStart.Year && t.Date.Month == monthStart.Month).ToList();
    }

    // Filter by expense or revenue type
    public static List<Transaction> ByType(IEnumerable<Transaction> transactions, CategoryType type)
    {
        return transactions.Where(t => t.Category.Type == type).ToList();
    }

    // Case‑insensitive search in category name and description
    public static List<Transaction> BySearchText(IEnumerable<Transaction> transactions, string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText)) return transactions.ToList();

        return transactions
            .Where(t =>
                t.Category.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                t.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}