using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CustomerRegistryABC.Models;

namespace CustomerRegistryABC.Forms
{
    /// <summary>
    /// Main GUI: shows the registry list on the left and details on the right.
    /// </summary>
    public class MainForm : Form
    {
        private readonly CustomerManager _manager = new();
        private readonly ListBox _lstCustomers = new();
        private readonly TextBox _txtDetails = new();
        private readonly Button _btnAdd = new();
        private readonly Button _btnEdit = new();
        private readonly Button _btnDelete = new();

        public MainForm()
        {
            Text = "Customer Registry – ABC";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(900, 560);

            InitializeLayout();
            WireEvents();
        }

        private void InitializeLayout()
        {
            // Root layout: two columns
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            Controls.Add(root);

            // Left panel: ListBox + buttons
            var leftPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // auto-size row for buttons
            root.Controls.Add(leftPanel, 0, 0);

            // ListBox
            _lstCustomers.Dock = DockStyle.Fill;
            _lstCustomers.Font = new Font(FontFamily.GenericMonospace, 10f);
            leftPanel.Controls.Add(_lstCustomers, 0, 0);

            // Buttons panel
            var btnPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(8),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill
            };
            leftPanel.Controls.Add(btnPanel, 0, 1);

            // Buttons
            _btnAdd.Text = "Add";
            _btnEdit.Text = "Edit";
            _btnDelete.Text = "Delete";

            _btnAdd.Width = _btnEdit.Width = _btnDelete.Width = 120;
            _btnAdd.Height = _btnEdit.Height = _btnDelete.Height = 36;

            btnPanel.Controls.AddRange(new Control[] { _btnAdd, _btnEdit, _btnDelete });

            // Right column: details textbox
            _txtDetails.Multiline = true;
            _txtDetails.ReadOnly = true;
            _txtDetails.ScrollBars = ScrollBars.Vertical;
            _txtDetails.Dock = DockStyle.Fill;
            _txtDetails.Font = new Font(FontFamily.GenericMonospace, 10f);
            root.Controls.Add(_txtDetails, 1, 0);
        }

        private void WireEvents()
        {
            _btnAdd.Click += (_, __) => AddCustomer();
            _btnEdit.Click += (_, __) => EditCustomer();
            _btnDelete.Click += (_, __) => DeleteCustomer();
            _lstCustomers.SelectedIndexChanged += (_, __) => UpdateDetailsPanel();
            Shown += (_, __) => RefreshListBox();
        }

        private void AddCustomer()
        {
            using var dlg = new ContactForm();
            var result = dlg.ShowDialog(this);
            if (result == DialogResult.OK && dlg.ContactResult != null)
            {
                if (!dlg.ContactResult.CheckData(out var err))
                {
                    MessageBox.Show(this, err, "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCustomer = new Customer(dlg.ContactResult);
                _manager.Add(newCustomer);
                RefreshListBoxAndSelectLast();
            }
        }

        private void EditCustomer()
        {
            var idx = _lstCustomers.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show(this, "Select a customer to edit.", "No selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var existing = _manager.GetAt(idx);
            if (existing == null) return;

            var copy = CloneContact(existing.Contact);

            using var dlg = new ContactForm(copy);
            var result = dlg.ShowDialog(this);
            if (result == DialogResult.OK && dlg.ContactResult != null)
            {
                existing.Contact = dlg.ContactResult;
                _manager.Change(idx, existing);
                RefreshListBoxKeepSelection(idx);
            }
        }

        private void DeleteCustomer()
        {
            var idx = _lstCustomers.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show(this, "Select a customer to delete.", "No selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(this, "Delete the selected customer?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _manager.RemoveAt(idx);
                RefreshListBox();
            }
        }

        private void RefreshListBox()
        {
            _lstCustomers.BeginUpdate();
            _lstCustomers.Items.Clear();
            _lstCustomers.Items.AddRange(_manager.ToDisplayStrings().Cast<object>().ToArray());
            _lstCustomers.EndUpdate();
            UpdateDetailsPanel();
        }

        private void RefreshListBoxAndSelectLast()
        {
            RefreshListBox();
            if (_lstCustomers.Items.Count > 0)
                _lstCustomers.SelectedIndex = _lstCustomers.Items.Count - 1;
        }

        private void RefreshListBoxKeepSelection(int index)
        {
            RefreshListBox();
            if (_lstCustomers.Items.Count > 0 && index >= 0 && index < _lstCustomers.Items.Count)
                _lstCustomers.SelectedIndex = index;
        }

        private void UpdateDetailsPanel()
        {
            var idx = _lstCustomers.SelectedIndex;
            var customer = _manager.GetAt(idx);
            _txtDetails.Text = customer?.Contact.ToDetailsString() ?? "Select a customer to view details.";
        }

        private static Contact CloneContact(Contact c)
        {
            return new Contact
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = new Address(c.Address.Street, c.Address.ZipCode, c.Address.City, c.Address.Country),
                Phone = new Phone
                {
                    PrivatePhone = c.Phone.PrivatePhone,
                    OfficePhone = c.Phone.OfficePhone
                },
                Email = new Email
                {
                    PrivateEmail = c.Email.PrivateEmail,
                    OfficeEmail = c.Email.OfficeEmail
                }
            };
        }
    }
}
