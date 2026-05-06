using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlowTracker.Models;

namespace CashFlowTracker.Services;

public class FinanceManager
{
    private List<Transaction> _transactions = new();

    // Add a transaction
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    // Get all transactions
    public List<Transaction> GetAllTransactions()
    {
        return _transactions;
    }

    // Group transactions by month (key = first day of month)
    public Dictionary<DateTime, List<Transaction>> GetTransactionsGroupedByMonth()
    {
        return _transactions
            .GroupBy(t => new DateTime(t.Date.Year, t.Date.Month, 1))
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Monthly totals returned as tuple
    public (decimal totalRevenues, decimal totalExpenses, decimal netCashFlow) CalculateMonthlyTotals(DateTime monthStart)
    {
        var monthTx = _transactions
            .Where(t => t.Date.Year == monthStart.Year && t.Date.Month == monthStart.Month)
            .ToList();

        decimal totalRevenues = monthTx.Where(t => t.Category.Type == CategoryType.Revenue).Sum(t => t.Amount);
        decimal totalExpenses = monthTx.Where(t => t.Category.Type == CategoryType.Expense).Sum(t => t.Amount);
        decimal netCashFlow = totalRevenues - totalExpenses;

        return (totalRevenues, totalExpenses, netCashFlow);
    }

    // Top N expense categories for a month
    public List<(string categoryName, decimal total)> GetTopExpenseCategories(DateTime monthStart, int topN = 3)
    {
        return _transactions
            .Where(t => t.Date.Year == monthStart.Year && t.Date.Month == monthStart.Month)
            .Where(t => t.Category.Type == CategoryType.Expense)
            .GroupBy(t => t.Category.Name)
            .Select(g => (categoryName: g.Key, total: g.Sum(t => t.Amount)))
            .OrderByDescending(x => x.total)
            .Take(topN)
            .ToList();
    }

    // Top N revenue sources for a month
    public List<(string categoryName, decimal total)> GetTopRevenueSources(DateTime monthStart, int topN = 3)
    {
        return _transactions
            .Where(t => t.Date.Year == monthStart.Year && t.Date.Month == monthStart.Month)
            .Where(t => t.Category.Type == CategoryType.Revenue)
            .GroupBy(t => t.Category.Name)
            .Select(g => (categoryName: g.Key, total: g.Sum(t => t.Amount)))
            .OrderByDescending(x => x.total)
            .Take(topN)
            .ToList();
    }

    // Search by text fields and/or date
    public List<Transaction> SearchTransactions(string? searchText = null, DateTime? date = null,
        string? categoryName = null, string? description = null)
    {
        var query = _transactions.AsEnumerable();

        if (date.HasValue)
            query = query.Where(t => t.Date.Date == date.Value.Date);

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            query = query.Where(t =>
                t.Category.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                t.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(categoryName))
            query = query.Where(t => t.Category.Name.Contains(categoryName, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(description))
            query = query.Where(t => t.Description.Contains(description, StringComparison.OrdinalIgnoreCase));

        return query.ToList();
    }

    // Filter by type only
    public List<Transaction> FilterByType(CategoryType? type)
    {
        if (type == null)
            return _transactions;

        return _transactions.Where(t => t.Category.Type == type).ToList();
    }

    // Filter by month only
    public List<Transaction> FilterByMonth(DateTime monthStart)
    {
        return _transactions
            .Where(t => t.Date.Year == monthStart.Year && t.Date.Month == monthStart.Month)
            .ToList();
    }

    // Persistence: save
    public void SaveData(string filePath)
    {
        FileService.SaveToJson(filePath, _transactions);
    }

    // Persistence: load
    public void LoadData(string filePath)
    {
        if (File.Exists(filePath))
        {
            _transactions = FileService.LoadFromJson<List<Transaction>>(filePath);
        }
    }
}
