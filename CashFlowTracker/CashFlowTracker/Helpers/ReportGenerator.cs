using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CashFlowTracker.Models;
using CashFlowTracker.Services;


namespace CashFlowTracker.Helpers;

public static class ReportGenerator
{
    // Build a formatted monthly report with totals and top categories/sources
    public static string GenerateMonthlyReport(FinanceManager manager, DateTime monthStart)
    {
        // Get monthly totals using tuple deconstruction
        var (totalRevenues, totalExpenses, netCashFlow) = manager.CalculateMonthlyTotals(monthStart);
        var topExpenses = manager.GetTopExpenseCategories(monthStart);
        var topRevenues = manager.GetTopRevenueSources(monthStart);

        string report = $"Monthly Report – {monthStart:MMMM yyyy}\n";
        report += $"Total Revenues: {totalRevenues:C}\n";
        report += $"Total Expenses: {totalExpenses:C}\n";
        report += $"Net Cash Flow: {netCashFlow:C}\n\n";

        report += "Top 3 Expense Categories:\n";
        foreach (var (name, total) in topExpenses)
            report += $"  • {name}: {total:C}\n";

        report += "\nTop 3 Revenue Sources:\n";
        foreach (var (name, total) in topRevenues)
            report += $"  • {name}: {total:C}\n";

        return report;
    }
}