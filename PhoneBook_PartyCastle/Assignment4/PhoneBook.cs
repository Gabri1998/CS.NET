using System;

namespace Assignment4
{
    internal class PhoneBook
    {
        private string[] names;
        private string[] phones;
        private string[,] table; // 2D array to store user entries
        private int row;         // Number of rows for the table
        private int column;      // Number of columns (name, phone)

        public PhoneBook(int row)
        {
            // Initialize predefined names and phones
            names = new string[6] { "Ahmed", "Sam", "Ali", "Jabr", "Abdullah", "Sameer" };
            phones = new string[6] { "703-534-356", "705-648-692", "706-790-802", "702-842-387", "705-762-395", "702-365-894" };
            this.row = row;
            column = 2; // Two columns: Name and Phone
            table = new string[row, column]; // Initialize table
        }

        // Entry point for the PhoneBook operations
        public void Start()
        {
            displayList();      // Step 1: Display the unsorted predefined list
            sortByName();       // Step 2: Sort the predefined list by names alphabetically
            displayList();      // Step 3: Display the sorted predefined list
            fillTable();        // Step 4: Fill the 2D table with user input
            Console.WriteLine("Before sorting the table:");
            printTable();       // Step 5: Display the unsorted 2D table
            sortTableByName();  // Step 6: Sort the 2D table by names (first column)
            Console.WriteLine("After sorting the table:");
            printTable();       // Step 7: Display the sorted 2D table
        }

        // Display the phone book list (either sorted or unsorted)
        private void displayList()
        {
            Console.WriteLine("Phone Book List:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Name: {names[i]}, Phone: {phones[i]}");
            }
            Console.WriteLine();
        }

        // Sort the predefined list by name using Bubble Sort
        private void sortByName()
        {
            int size = names.Length; // Get size of the names array
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (string.Compare(names[j], names[j + 1]) > 0) // Compare alphabetically
                    {
                        swapValues(j); // Swap both names and phones if out of order
                    }
                }
            }
        }

        // Swap names and their corresponding phone numbers
        private void swapValues(int i)
        {
            // Swap names
            (this.names[i + 1], this.names[i]) = (this.names[i], this.names[i + 1]);
            // Swap corresponding phone numbers
            (this.phones[i + 1], this.phones[i]) = (this.phones[i], this.phones[i + 1]);
        }

        // Fill the 2D table with new user input (name and phone number)
        private void fillTable()
        {
            Console.WriteLine($"\nYou can store up to {row} people contact info.\n");
            for (int i = 0; i < table.GetLength(0); i++) // Iterate over rows
            {
                Console.WriteLine($"Enter contact info for person {i + 1}:");

                Console.Write("Name: ");
                table[i, 0] = Console.ReadLine(); // First column: Name

                Console.Write("Phone Number: ");
                table[i, 1] = Console.ReadLine(); // Second column: Phone number

                Console.WriteLine();
            }
        }

        // Sort the 2D table by the name (first column) using Bubble Sort
        private void sortTableByName()
        {
            int rows = table.GetLength(0); // Get the number of rows
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    // Compare names in the first column
                    if (string.Compare(table[j, 0], table[j + 1, 0]) > 0)
                    {
                        swapRows(j); // Swap the entire row if the name is out of order
                    }
                }
            }
        }

        // Swap two rows of the table (name and phone number)
        private void swapRows(int rowIndex)
        {
            for (int col = 0; col < column; col++)
            {
                // Swap the elements of the two rows across all columns
                (table[rowIndex + 1, col], table[rowIndex, col]) = (table[rowIndex, col], table[rowIndex + 1, col]);
            }
        }

        // Print the 2D table
        private void printTable()
        {
            Console.WriteLine("PhoneBook Table:");
            for (int i = 0; i < table.GetLength(0); i++) // Iterate over rows
            {
                for (int j = 0; j < table.GetLength(1); j++) // Iterate over columns
                {
                    Console.Write($"{table[i, j]} "); // Print each element
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
