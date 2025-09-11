using System;

namespace ToDoReminder.Models
{
    
    /// Represents a single to-do task.
   
    public class TaskItem
    {
        // Private fields (encapsulation)
        private string _description;
        private DateTime _dueDate;
        private Priority _priority;

       
        /// Constructor initializes all properties.
        
        public TaskItem(string description, DateTime dueDate, Priority priority)
        {
            _description = string.IsNullOrWhiteSpace(description)
                ? throw new ArgumentException("Description cannot be empty.")
                : description.Trim();

            _dueDate = dueDate;
            _priority = priority;
        }

        ///Task description.
        public string Description
        {
            get => _description;
            set => _description = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Description cannot be empty.")
                : value.Trim();
        }

        /// Due date and time.
        public DateTime DueDate
        {
            get => _dueDate;
            set => _dueDate = value;
        }

        /// Task priority.
        public Priority Priority
        {
            get => _priority;
            set => _priority = value;
        }

        
        /// Returns a compact string for list display.
   
        public override string ToString()
        {
            return $"{DueDate:g} | {Priority} | {Description}";
        }

      
        /// Serializes the task into a simple CSV-like string for saving to file.
        
        public string ToFileString()
        {
            return $"{DueDate:o};{Priority};{Description}";
        }

        
        /// Recreates a TaskItem from a file string.
       
        public static TaskItem FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException("Invalid line.");

            var parts = line.Split(';');
            if (parts.Length < 3)
                throw new ArgumentException("Invalid task format.");

            var dueDate = DateTime.Parse(parts[0]);
            var priority = (Priority)Enum.Parse(typeof(Priority), parts[1]);

            var description = parts[2];

            return new TaskItem(description, dueDate, priority);
        }
    }
}
