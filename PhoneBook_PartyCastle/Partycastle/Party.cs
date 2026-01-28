using System;

namespace Partycastle
{
    internal class Party
    {
        private int costPerPerson;
        private int feePerPerson;
        private int maxGuests;
        private Guest[] guests;    // Changed to an array
        private int currentGuestCount; // Track the current number of guests added

        public Party(int costPerPerson, int feePerPerson, int maxGuests)
        {
            this.costPerPerson = costPerPerson;
            this.feePerPerson = feePerPerson;
            this.maxGuests = maxGuests;
            this.guests = new Guest[maxGuests]; // Initialize the array with a fixed size
            this.currentGuestCount = 0;         // Initially, no guests are added
        }

        // Getter methods
        public int GetCostPerPerson() { return this.costPerPerson; }
        public int GetFeePerPerson() { return this.feePerPerson; }
        public int GetMaxGuests() { return this.maxGuests; }
        public Guest[] GetGuests() { return this.guests; }
        public int GetCurrentGuestCount() { return this.currentGuestCount; } // Number of guests added so far

        // Setter methods
        public void SetCostPerPerson(int cost) { this.costPerPerson = cost; }
        public void SetFeePerPerson(int fee) { this.feePerPerson = fee; }
        public void SetMaxGuests(int number) { this.maxGuests = number; }

        // Add a guest
        public bool AddGuest(Guest guest)
        {
            if (currentGuestCount < maxGuests)
            {
                guests[currentGuestCount] = guest;
                currentGuestCount++;
                return true;
            }
            else
            {
                return false; // Cannot add more guests if max limit is reached
            }
        }

        // Delete a guest by index
        public bool DeleteGuest(int index)
        {
            if (index >= 0 && index < currentGuestCount)
            {
                // Shift all elements after the deleted guest to the left
                for (int i = index; i < currentGuestCount - 1; i++)
                {
                    guests[i] = guests[i + 1];
                }
                guests[currentGuestCount - 1] = null; // Clear the last spot
                currentGuestCount--;                  // Reduce the count of guests
                return true;
            }
            return false; // If the index is invalid, return false
        }

        // Calculate total cost for all guests
        public int CalculateTotalCost()
        {
            return costPerPerson * currentGuestCount;
        }

        // Calculate total fees collected from guests
        public int CalculateTotalFees()
        {
            return feePerPerson * currentGuestCount;
        }

        // Calculate surplus or deficit
        public int CalculateDeficit()
        {
            return CalculateTotalFees() - CalculateTotalCost();
        }
    }
}
