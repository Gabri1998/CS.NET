using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Partycastle
{
    public partial class Form1 : Form
    {
        private Party party;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCostPerPerson.Text, out int costPerPerson) &&
                int.TryParse(txtFeePerPerson.Text, out int feePerPerson) &&
                int.TryParse(txtMaxGuests.Text, out int maxGuests))
            {
                party = new Party(costPerPerson, feePerPerson, maxGuests);
                lstGuestList.Items.Clear();
                UpdateSummary();

                // Clear input fields
                txtCostPerPerson.Clear();
                txtFeePerPerson.Clear();
                txtMaxGuests.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for cost per person, fee per person, and max guests.");
            }
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            if (party == null)
            {
                MessageBox.Show("Please calculate the party details first.");
                return;
            }

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                Guest guest = new Guest(firstName, lastName);
                if (party.AddGuest(guest))
                {
                    lstGuestList.Items.Add($"{guest.getFirstName()} {guest.getLastName()}");
                    UpdateSummary();

                    // Clear guest input fields
                    txtFirstName.Clear();
                    txtLastName.Clear();
                }
                else
                {
                    MessageBox.Show("Cannot add guest. Maximum number of guests reached.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both first and last names.");
            }
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (party == null)
            {
                MessageBox.Show("Please calculate the party details first.");
                return;
            }

            if (lstGuestList.SelectedIndex != -1)
            {
                int selectedIndex = lstGuestList.SelectedIndex;
                if (party.DeleteGuest(selectedIndex))
                {
                    lstGuestList.Items.RemoveAt(selectedIndex);
                    UpdateSummary();
                }
                else
                {
                    MessageBox.Show("Error removing the selected guest.");
                }
            }
            else
            {
                MessageBox.Show("Please select a guest to delete.");
            }
        }

        private void UpdateSummary()
        {
            if (party == null) return;

            lblTotalCost.Text = $"Total Cost: {party.CalculateTotalCost()}";
            lblTotalFees.Text = $"Total Fees: {party.CalculateTotalFees()}";
            lblDeficit.Text = $"Deficit: {party.CalculateDeficit()}";
        }
    }
}

