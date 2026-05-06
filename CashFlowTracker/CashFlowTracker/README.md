# Cash Flow Tracker — Assignment 5

**Objective:** Build a C# WPF application to track monthly incomes and expenses, demonstrating records, tuples, collections, and file I/O as per the course requirements.

## What the application does
- Users add transactions with date, amount, description, custom category name, and type (Expense/Revenue).
- Transactions are stored in a `List<Transaction>` and grouped by month using a `Dictionary<DateTime, List<Transaction>>`.
- Monthly totals (revenues, expenses, net cash‑flow) are calculated and returned via **tuples**.
- The app supports **search** (by date, text, category) and **filter** (by type, month).
- A monthly report shows the top 3 expense categories and top 3 revenue sources.
- Data is persisted to a JSON file (`transactions.json`) using `System.Text.Json`.

## Key data structures (Grade D–A)
- **Records:** `Category` and `Transaction` are immutable records.
- **Tuples:** used in `CalculateMonthlyTotals` to return `(totalRevenues, totalExpenses, netCashFlow)`.
- **Collections:** `List<Transaction>`, `Dictionary<DateTime, List<Transaction>>`, and LINQ for grouping, filtering, and top‑N queries.

## Project files
/Models
CategoryType.cs → Enum (Expense, Revenue)
Category.cs → Record: string Name, CategoryType Type
Transaction.cs → Record: DateTime Date, decimal Amount, Category, string Description
/Services
FinanceManager.cs → Core logic: add, group by month, totals, search, filter, top‑N, save/load
FileService.cs → Static JSON serialisation/deserialisation helper
/Helpers
TransactionFilter.cs → Static methods to filter a list by date, month, type, or search text
ReportGenerator.cs → Builds a formatted monthly report string
MainWindow.xaml → WPF UI (two tabs: Transactions and Monthly View)
MainWindow.xaml.cs → Code‑behind wiring the UI to FinanceManager
transactions.json → Auto‑generated save file