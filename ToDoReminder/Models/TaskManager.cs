using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoReminder.Models
{
    
    /// Manages a list of tasks and file operations.
   
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();


        /// Number of tasks currently stored.
        public int Count => _tasks.Count;

        /// Read-only access to all tasks.
        public IReadOnlyList<TaskItem> Tasks => _tasks.AsReadOnly();

        /// Adds a task to the list.
        public void Add(TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _tasks.Add(task);
        }

        /// Updates the task at the given index.
        public bool Update(int index, TaskItem updatedTask)
        {
            if (!IsValidIndex(index)) return false;
            _tasks[index] = updatedTask ?? throw new ArgumentNullException(nameof(updatedTask));
            return true;
        }

        /// Removes the task at the given index.
        public bool RemoveAt(int index)
        {
            if (!IsValidIndex(index)) return false;
            _tasks.RemoveAt(index);
            return true;
        }

        /// Clears all tasks.
        public void Clear() => _tasks.Clear();

        /// Saves all tasks to a file.
        public void SaveToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var task in _tasks)
                    writer.WriteLine(task.ToFileString());
            }
        }

        /// Loads tasks from a file, replacing current list.
        public void LoadFromFile(string filePath)
        {
            _tasks.Clear();
            foreach (var line in File.ReadAllLines(filePath))
            {
                try
                {
                    _tasks.Add(TaskItem.FromFileString(line));
                }
                catch
                {
                    // Skip invalid lines
                }
            }
        }

        private bool IsValidIndex(int index)
            => index >= 0 && index < _tasks.Count;
    }
}
