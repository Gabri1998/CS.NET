using System;
using System.Drawing;
using System.Windows.Forms;
using CustomerRegistryABC.Models;

namespace CustomerRegistryABC.Forms
{
    /// <summary>
    /// Data entry form for Contact. Used for both Add and Edit.
    /// Includes real-time validation for each field.
    /// </summary>
    public class ContactForm : Form
    {
        // Public result (read-only)
        public Contact ContactResult { get; private set; }

        // Controls
        private readonly TextBox txtFirst = new();
        private readonly TextBox txtLast = new();
        private readonly TextBox txtStreet = new();
        private readonly TextBox txtZip = new();
        private readonly TextBox txtCity = new();
        private readonly TextBox txtCountry = new();
        private readonly TextBox txtPhonePrivate = new();
        private readonly TextBox txtPhoneOffice = new();
        private readonly TextBox txtEmailPrivate = new();
        private readonly TextBox txtEmailOffice = new();
        private readonly Button btnOk = new();
        private readonly Button btnCancel = new();

        private readonly Contact _working; // mutable copy when editing

        public ContactForm() : this(new Contact()) { }

        public ContactForm(Contact contact)
        {
            _working = contact ?? new Contact();

            ContactResult = null;

            Text = "Contact";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(640, 560);

            InitializeLayout();
            LoadFromContact(_working);
            WireValidation();

            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            AcceptButton = btnOk;
            CancelButton = btnCancel;

            btnOk.Click += (_, __) => OnOk();
            FormClosing += ContactForm_FormClosing;
        }

        private void InitializeLayout()
        {
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            Controls.Add(root);

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 10,
                AutoScroll = true
            };

            for (int i = 0; i < 10; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            root.Controls.Add(grid, 0, 0);

            void AddRow(string label, Control control)
            {
                var lbl = new Label
                {
                    Text = label,
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Fill
                };
                control.Dock = DockStyle.Fill;
                grid.Controls.Add(lbl);
                grid.Controls.Add(control);
            }

            AddRow("First name:", txtFirst);
            AddRow("Last name:", txtLast);
            AddRow("Street:", txtStreet);
            AddRow("ZIP code:", txtZip);
            AddRow("City:", txtCity);
            AddRow("Country:", txtCountry);
            AddRow("Private phone:", txtPhonePrivate);
            AddRow("Office phone:", txtPhoneOffice);
            AddRow("Private email:", txtEmailPrivate);
            AddRow("Office email:", txtEmailOffice);

            var btnPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(8)
            };
            root.Controls.Add(btnPanel, 0, 1);

            btnOk.Text = "OK";
            btnOk.Width = 120;
            btnOk.Height = 36;

            btnCancel.Text = "Cancel";
            btnCancel.Width = 120;
            btnCancel.Height = 36;

            btnPanel.Controls.Add(btnOk);
            btnPanel.Controls.Add(btnCancel);
        }

        private void LoadFromContact(Contact c)
        {
            txtFirst.Text = c.FirstName;
            txtLast.Text = c.LastName;
            txtStreet.Text = c.Address.Street;
            txtZip.Text = c.Address.ZipCode;
            txtCity.Text = c.Address.City;
            txtCountry.Text = c.Address.Country;
            txtPhonePrivate.Text = c.Phone.PrivatePhone;
            txtPhoneOffice.Text = c.Phone.OfficePhone;
            txtEmailPrivate.Text = c.Email.PrivateEmail;
            txtEmailOffice.Text = c.Email.OfficeEmail;
        }

        private void WireValidation()
        {
            // Real-time: only letters for names, city, country
            txtFirst.KeyPress += AllowLettersOnly;
            txtLast.KeyPress += AllowLettersOnly;
            txtCity.KeyPress += AllowLettersOnly;
            txtCountry.KeyPress += AllowLettersOnly;

            // Real-time: only numbers for ZIP and phones
            txtZip.KeyPress += AllowDigitsOnly;
            txtPhonePrivate.KeyPress += AllowDigitsOnly;
            txtPhoneOffice.KeyPress += AllowDigitsOnly;
        }

        private void AllowLettersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void AllowDigitsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void OnOk()
        {
            // Field-level final checks
            if (string.IsNullOrWhiteSpace(txtFirst.Text) && string.IsNullOrWhiteSpace(txtLast.Text))
            {
                MessageBox.Show("Provide at least a first name or a last name.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text) || string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                MessageBox.Show("City and Country are required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Push UI into _working
            _working.FirstName = txtFirst.Text;
            _working.LastName = txtLast.Text;
            _working.Address.Street = txtStreet.Text;
            _working.Address.ZipCode = txtZip.Text;
            _working.Address.City = txtCity.Text;
            _working.Address.Country = txtCountry.Text;
            _working.Phone.PrivatePhone = txtPhonePrivate.Text;
            _working.Phone.OfficePhone = txtPhoneOffice.Text;
            _working.Email.PrivateEmail = txtEmailPrivate.Text;
            _working.Email.OfficeEmail = txtEmailOffice.Text;

            // Contact-level validation
            if (!_working.CheckData(out var err))
            {
                MessageBox.Show(err, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            ContactResult = _working;
        }

        private void ContactForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                var res = MessageBox.Show("Cancel without saving?", "Confirm",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
