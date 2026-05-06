using CashFlowTracker.Helpers;
using CashFlowTracker.Models;
using CashFlowTracker.Services;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace CashFlowTracker;

public partial class MainWindow : Window
{
    // Core business logic instance
    private FinanceManager _manager = new();
    // File where transactions are persisted as JSON
    private string _dataFilePath = "transactions.json";

    public MainWindow()
    {
        InitializeComponent();

        // Load saved data on startup
        _manager.LoadData(_dataFilePath);
        RefreshTransactionList();
        PopulateMonthComboBox();
    }

    // --------------- Add Transaction ---------------
    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        // Try to parse the amount; if invalid, ignore the add
        if (!decimal.TryParse(txtAmount.Text, out decimal amount)) return;

        // Determine category type from dropdown selection
        CategoryType type = (cmbType.SelectedItem as ComboBoxItem)?.Content.ToString() == "Revenue"
            ? CategoryType.Revenue
            : CategoryType.Expense;

        // Build the immutable category and transaction records
        var category = new Category(txtCategoryName.Text, type);
        var transaction = new Transaction(
            dpDate.SelectedDate ?? DateTime.Today,
            amount,
            category,
            txtDescription.Text
        );

        // Add to manager and refresh UI
        _manager.AddTransaction(transaction);
        RefreshTransactionList();
        PopulateMonthComboBox();   // new month may have appeared
    }

    // --------------- Save / Load ---------------
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        _manager.SaveData(_dataFilePath);
        MessageBox.Show("Data saved.");
    }

    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        _manager.LoadData(_dataFilePath);
        RefreshTransactionList();
        PopulateMonthComboBox();
        MessageBox.Show("Data loaded.");
    }

    // --------------- Refresh main DataGrid ---------------
    private void RefreshTransactionList()
    {
        // Reset and repopulate the main transaction grid
        dataGridTransactions.ItemsSource = null;
        dataGridTransactions.ItemsSource = _manager.GetAllTransactions();
    }

    // Applies the currently selected type filter and search text together
    private void ApplyFilters()
    {
        CategoryType? selectedType = null;
        if (cmbFilterType.SelectedItem is ComboBoxItem item)
            selectedType = item.Content.ToString() == "Expense" ? CategoryType.Expense : CategoryType.Revenue;

        string searchText = txtSearch.Text.Trim();

        // Start with all transactions
        var result = _manager.GetAllTransactions();

        // Filter by type if one is selected
        if (selectedType.HasValue)
            result = _manager.FilterByType(selectedType.Value);

        // Apply text search on the (possibly type‑filtered) list
        if (!string.IsNullOrEmpty(searchText))
            result = TransactionFilter.BySearchText(result, searchText);

        dataGridTransactions.ItemsSource = result;
    }

    // --------------- Search & Filter ---------------
    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
        ApplyFilters();   // combines text search and type filter
    }

    private void btnSearchDate_Click(object sender, RoutedEventArgs e)
    {
        // Search by the exact date selected in the DatePicker
        if (dpDate.SelectedDate.HasValue)
        {
            var results = _manager.SearchTransactions(date: dpDate.SelectedDate.Value);
            dataGridTransactions.ItemsSource = results;
        }
        else
        {
            RefreshTransactionList();
        }
    }

    private void cmbFilterType_SelectionChanged(object sender, RoutedEventArgs e)
    {
        ApplyFilters();   // reapply filters whenever the type dropdown changes
    }

    private void btnClearFilter_Click(object sender, RoutedEventArgs e)
    {
        // Clear search text and reset the type filter, then show all transactions
        txtSearch.Text = "";
        cmbFilterType.SelectedIndex = -1;   // -1 means "no selection" -> show all types
        RefreshTransactionList();           // ensures we are back to the full list
    }

    // --------------- Monthly View ---------------
    private void PopulateMonthComboBox()
    {
        // Fill the month dropdown with all months that contain transactions
        cmbMonth.Items.Clear();
        var months = _manager.GetTransactionsGroupedByMonth().Keys.OrderBy(d => d);
        foreach (var m in months)
            cmbMonth.Items.Add(m.ToString("yyyy-MM"));
    }

    private void cmbMonth_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (cmbMonth.SelectedItem == null) return;

        // Parse the selected month string (e.g., "2026-05") back to a DateTime
        if (DateTime.TryParse(cmbMonth.SelectedItem.ToString() + "-01", out DateTime monthStart))
        {
            // Calculate and display monthly totals (revenue, expenses, net)
            var totals = _manager.CalculateMonthlyTotals(monthStart);
            txtMonthlyTotals.Text = $"Revenues: {totals.totalRevenues:C}   Expenses: {totals.totalExpenses:C}   Net Cashflow: {totals.netCashFlow:C}";

            // Show only transactions for the selected month
            var monthTx = _manager.FilterByMonth(monthStart);
            dataGridMonthlyTransactions.ItemsSource = monthTx;
        }
    }

    private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
    {
        if (cmbMonth.SelectedItem == null) return;

        if (DateTime.TryParse(cmbMonth.SelectedItem.ToString() + "-01", out DateTime monthStart))
        {
            // Use the ReportGenerator helper to build the formatted report string
            string report = ReportGenerator.GenerateMonthlyReport(_manager, monthStart);
            MessageBox.Show(report, "Monthly Report");
        }
    }
}