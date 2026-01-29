using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ToDoReminder.Models;

namespace ToDoReminder.Forms
{
    public class MainForm : Form
    {
        //  Core data 
        private readonly TaskManager _manager = new TaskManager();

        //  Controls 
        private readonly DateTimePicker _dtp = new DateTimePicker();
        private readonly ComboBox _cmbPriority = new ComboBox();
        private readonly TextBox _txtDescription = new TextBox();
        private readonly ListBox _lstTasks = new ListBox();
        private readonly Button _btnAdd = new Button();
        private readonly Button _btnEdit = new Button();
        private readonly Button _btnDelete = new Button();
        private readonly Label _lblClock = new Label();
        private readonly ToolTip _toolTip = new ToolTip();
        private readonly Timer _timer = new Timer();

        private string _currentFile = Path.Combine(Application.StartupPath, "reminders.txt");

        public MainForm()
        {
            Text = "ToDo Reminder";
            MinimumSize = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;

            InitializeMenu();
            InitializeLayout();
            InitializeEvents();
            InitializeTimer();
        }

     
        // Setup
        
        private void InitializeMenu()
        {
            var menuStrip = new MenuStrip();

            // File menu
            var fileMenu = new ToolStripMenuItem("File");
            fileMenu.DropDownItems.Add("New", null, (_, __) => NewFile());
            fileMenu.DropDownItems.Add("Open", null, (_, __) => OpenFile());
            fileMenu.DropDownItems.Add("Save", null, (_, __) => SaveFile());
            fileMenu.DropDownItems.Add("Exit", null, (_, __) => ExitApp());

            // Help menu
            var helpMenu = new ToolStripMenuItem("Help");
            helpMenu.DropDownItems.Add("About...", null, (_, __) => ShowAbout());

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(helpMenu);


            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }

        private void InitializeLayout()
        {
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));      // input area expands as needed
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // task list fills remaining space
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));  // clock area fixed
            Controls.Add(root);
            root.Dock = DockStyle.Fill;
            root.BringToFront();
            root.Location = new Point(0, MainMenuStrip.Height);


            // Input area 
            var inputPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2,
                Padding = new Padding(8),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            inputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            inputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            inputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            inputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            root.Controls.Add(inputPanel, 0, 0);

            // Date/Time
            inputPanel.Controls.Add(new Label { Text = "Date/Time:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 0);
            _dtp.Format = DateTimePickerFormat.Custom;
            _dtp.CustomFormat = "yyyy-MM-dd HH:mm";
            _dtp.Dock = DockStyle.Fill;
            _dtp.Margin = new Padding(3);
            _toolTip.SetToolTip(_dtp, "Select the date and time for the task.");
            inputPanel.Controls.Add(_dtp, 1, 0);

            // Priority
            inputPanel.Controls.Add(new Label { Text = "Priority:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 2, 0);
            _cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbPriority.DataSource = Enum.GetValues(typeof(Priority));
            _cmbPriority.Dock = DockStyle.Fill;
            _cmbPriority.Margin = new Padding(3);
            inputPanel.Controls.Add(_cmbPriority, 3, 0);

            // Description
            inputPanel.Controls.Add(new Label { Text = "Description:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 1);
            _txtDescription.Dock = DockStyle.Fill;
            _txtDescription.Margin = new Padding(3);
            inputPanel.SetColumnSpan(_txtDescription, 3);
            inputPanel.Controls.Add(_txtDescription, 1, 1);

            // Task list + buttons 
            var middlePanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            middlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            middlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            root.Controls.Add(middlePanel, 0, 1);

            _lstTasks.Dock = DockStyle.Fill;
            middlePanel.Controls.Add(_lstTasks, 0, 0);

            var btnPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(8)
            };
            middlePanel.Controls.Add(btnPanel, 1, 0);

            _btnAdd.Text = "Add";
            _btnEdit.Text = "Edit";
            _btnDelete.Text = "Delete";
            _btnAdd.Width = _btnEdit.Width = _btnDelete.Width = 100;
            _btnAdd.Height = _btnEdit.Height = _btnDelete.Height = 36;

            btnPanel.Controls.Add(_btnAdd);
            btnPanel.Controls.Add(_btnEdit);
            btnPanel.Controls.Add(_btnDelete);

            // Status/Clock 
            _lblClock.Dock = DockStyle.Fill;
            _lblClock.TextAlign = ContentAlignment.MiddleRight;
            _lblClock.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            root.Controls.Add(_lblClock, 0, 2);
        }

        private void InitializeEvents()
        {
            _btnAdd.Click += (_, __) => AddTask();
            _btnEdit.Click += (_, __) => EditTask();
            _btnDelete.Click += (_, __) => DeleteTask();

            _lstTasks.SelectedIndexChanged += (_, __) => UpdateButtonStates();
        }

        private void InitializeTimer()
        {
            _timer.Interval = 1000; // 1 sec
            _timer.Tick += (_, __) => _lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            _timer.Start();
        }

       
        // Actions
        
        private void AddTask()
        {
            var description = _txtDescription.Text.Trim();
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = new TaskItem(description, _dtp.Value, (Priority)_cmbPriority.SelectedItem);
            _manager.Add(task);
            RefreshTaskList();
            _txtDescription.Clear();
        }

        private void EditTask()
        {
            int idx = _lstTasks.SelectedIndex;
            if (idx < 0) return;

            var description = _txtDescription.Text.Trim();
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updated = new TaskItem(description, _dtp.Value, (Priority)_cmbPriority.SelectedItem);
            _manager.Update(idx, updated);
            RefreshTaskList();
        }

        private void DeleteTask()
        {
            int idx = _lstTasks.SelectedIndex;
            if (idx < 0) return;

            var confirm = MessageBox.Show("Delete selected task?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _manager.RemoveAt(idx);
                RefreshTaskList();
            }
        }

        private void RefreshTaskList()
        {
            _lstTasks.Items.Clear();
            foreach (var task in _manager.Tasks)
                _lstTasks.Items.Add(task);
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = _lstTasks.SelectedIndex >= 0;
            _btnEdit.Enabled = hasSelection;
            _btnDelete.Enabled = hasSelection;
        }

        // File operations
        
        private void NewFile()
        {
            _manager.Clear();
            RefreshTaskList();
            _txtDescription.Clear();
        }

        private void SaveFile()
        {
            try
            {
                _manager.SaveToFile(_currentFile);
                MessageBox.Show("Tasks saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
            }
        }

        private void OpenFile()
        {
            try
            {
                if (File.Exists(_currentFile))
                {
                    _manager.LoadFromFile(_currentFile);
                    RefreshTaskList();
                    MessageBox.Show("Tasks loaded successfully.", "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No saved file found.", "Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening: {ex.Message}");
            }
        }

        private void ExitApp()
        {
            var res = MessageBox.Show("Exit the program?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
                Close();
        }

        private void ShowAbout()
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }
    }
}
