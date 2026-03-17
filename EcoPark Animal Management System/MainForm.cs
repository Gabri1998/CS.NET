using EcoPark_Animal_Management_System.animal_gen;
using EcoPark_Animal_Management_System.category.mammal;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EcoPark_Animal_Management_System
{
    // Main application window responsible for UI and user interaction
    public partial class MainForm : Form
    {
        // Stores all animals during runtime using AnimalManager
        private AnimalManager animalManager = new AnimalManager();

        // Temporary working animal used when creating new animals
        private Animal currAnimal = null;

        // UI controls
        private CheckBox chkListAll;
        private ListBox lstAnimals;
        private TextBox txtOutput;
        private PictureBox picAnimal;

        // Category selection
        private RadioButton rbMammal;
        private RadioButton rbBird;
        private RadioButton rbReptile;

        // Species selection
        private ComboBox cmbSpecies;

        // Action buttons
        private Button btnCreate;
        private Button btnLoadImage;
        private Button btnDelete;

        // MenuStrip
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newItem;
        private ToolStripMenuItem openItem;
        private ToolStripMenuItem saveItem;
        private ToolStripMenuItem saveAsItem;

        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem aboutMenu;

        // Current file path
        private string currentFile = null;

        // Controls how animals are displayed in the list
        private enum ViewMode
        {
            All,
            SortedName,
            SortedAge,
            Mammals
        }

        private ViewMode currentView = ViewMode.All;

        // Initializes the form
        public MainForm()
        {
            InitializeComponent();
            BuildUI();
        }

        // Builds the user interface manually
        private void BuildUI()
        {
            int xLeft = 20;
            int xRight = 520;
            int y = 20;

            // Create menu bar
            menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;
            MainMenuStrip = menuStrip;

            // Sort menu
            ToolStripMenuItem sortMenu = new ToolStripMenuItem("Sort");
            ToolStripMenuItem sortNameItem = new ToolStripMenuItem("Sort by Name");
            ToolStripMenuItem sortAgeItem = new ToolStripMenuItem("Sort by Age");

            // Filter menu
            ToolStripMenuItem filterMenu = new ToolStripMenuItem("Filter");
            ToolStripMenuItem mammalsItem = new ToolStripMenuItem("Show Mammals");

            // Statistics menu
            ToolStripMenuItem statsMenu = new ToolStripMenuItem("Statistics");
            ToolStripMenuItem avgAgeItem = new ToolStripMenuItem("Average Age");

            sortMenu.DropDownItems.Add(sortNameItem);
            sortMenu.DropDownItems.Add(sortAgeItem);

            filterMenu.DropDownItems.Add(mammalsItem);

            statsMenu.DropDownItems.Add(avgAgeItem);

            // File menu
            fileMenu = new ToolStripMenuItem("File");
            helpMenu = new ToolStripMenuItem("Help");

            newItem = new ToolStripMenuItem("New");
            openItem = new ToolStripMenuItem("Open");
            saveItem = new ToolStripMenuItem("Save");
            saveAsItem = new ToolStripMenuItem("Save As");

            aboutMenu = new ToolStripMenuItem("About");

            fileMenu.DropDownItems.Add(newItem);
            fileMenu.DropDownItems.Add(openItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(saveItem);
            fileMenu.DropDownItems.Add(saveAsItem);

            helpMenu.DropDownItems.Add(aboutMenu);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(sortMenu);
            menuStrip.Items.Add(filterMenu);
            menuStrip.Items.Add(statsMenu);
            menuStrip.Items.Add(helpMenu);

            // About dialog
            aboutMenu.Click += (s, e) =>
            {
                new AboutForm().ShowDialog();
            };

            // Menu actions
            sortNameItem.Click += SortName_Click;
            sortAgeItem.Click += SortAge_Click;
            mammalsItem.Click += MammalsOnly_Click;
            avgAgeItem.Click += AvgAge_Click;

            newItem.Click += New_Click;
            openItem.Click += Open_Click;
            saveItem.Click += Save_Click;
            saveAsItem.Click += SaveAs_Click;

            Controls.Add(menuStrip);
            y += menuStrip.Height + 10;

            // Toggle list mode
            chkListAll = new CheckBox
            {
                Text = "List all animals",
                Location = new Point(xLeft, y),
                AutoSize = true
            };

            chkListAll.CheckedChanged += (s, e) => RefreshList();
            Controls.Add(chkListAll);

            y += 30;

            // Animal list display
            lstAnimals = new ListBox
            {
                Location = new Point(xLeft, y),
                Size = new Size(460, 120),
                Visible = false
            };

            // Monospaced font for aligned columns
            lstAnimals.Font = new Font("Consolas", 10);

            lstAnimals.SelectedIndexChanged += lstAnimals_SelectedIndexChanged;
            Controls.Add(lstAnimals);

            y += 130;

            // Output box for detailed animal information
            txtOutput = new TextBox
            {
                Location = new Point(xLeft, y),
                Size = new Size(460, 120),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            Controls.Add(txtOutput);

            y += 140;

            // Category selection group
            GroupBox grpCategory = new GroupBox
            {
                Text = "Category",
                Location = new Point(xLeft, y),
                Size = new Size(260, 60)
            };

            Controls.Add(grpCategory);

            rbMammal = new RadioButton
            {
                Text = "Mammal",
                Location = new Point(10, 25),
                AutoSize = true,
                Checked = true
            };

            rbBird = new RadioButton
            {
                Text = "Bird",
                Location = new Point(90, 25),
                AutoSize = true
            };

            rbReptile = new RadioButton
            {
                Text = "Reptile",
                Location = new Point(150, 25),
                AutoSize = true
            };

            // Update species when category changes
            rbMammal.CheckedChanged += (s, e) => UpdateSpecies();
            rbBird.CheckedChanged += (s, e) => UpdateSpecies();
            rbReptile.CheckedChanged += (s, e) => UpdateSpecies();

            grpCategory.Controls.Add(rbMammal);
            grpCategory.Controls.Add(rbBird);
            grpCategory.Controls.Add(rbReptile);

            y += grpCategory.Height + 10;

            // Species dropdown
            cmbSpecies = new ComboBox
            {
                Location = new Point(xLeft, y),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Controls.Add(cmbSpecies);

            y += 40;

            // Create animal button
            btnCreate = new Button
            {
                Text = "Create Animal",
                Location = new Point(xRight, 20),
                Size = new Size(150, 30)
            };

            btnCreate.Click += BtnCreate_Click;
            Controls.Add(btnCreate);

            // Delete animal button
            btnDelete = new Button
            {
                Text = "Delete Animal",
                Location = new Point(xRight, 60),
                Size = new Size(150, 30)
            };

            btnDelete.Click += BtnDelete_Click;
            Controls.Add(btnDelete);

            // Image preview box
            picAnimal = new PictureBox
            {
                Location = new Point(xRight, 70),
                Size = new Size(200, 200),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Controls.Add(picAnimal);

            // Load image button
            btnLoadImage = new Button
            {
                Text = "Load Image",
                Location = new Point(xRight, 280),
                Size = new Size(150, 30)
            };

            btnLoadImage.Click += BtnLoadImage_Click;
            Controls.Add(btnLoadImage);

            UpdateSpecies();
        }

        // Saves data to a new file
        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Validate duplicates before saving
                    animalManager.ValidateDuplicates();

                    currentFile = dlg.FileName;

                    if (currentFile.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                        animalManager.JsonSerialize(currentFile);

                    else if (currentFile.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        animalManager.XMLSerialize(currentFile);

                    RefreshList();
                }
                catch (DuplicateAnimalException ex)
                {
                    MessageBox.Show(ex.Message, "Duplicate Animal Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Saves to the currently opened file
        private void Save_Click(object sender, EventArgs e)
        {
            if (currentFile == null)
            {
                SaveAs_Click(sender, e);
                return;
            }

            try
            {
                // Validate duplicates before serialization
                animalManager.ValidateDuplicates();

                if (currentFile.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    animalManager.JsonSerialize(currentFile);

                else if (currentFile.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    animalManager.XMLSerialize(currentFile);

                RefreshList();
            }
            catch (DuplicateAnimalException ex)
            {
                MessageBox.Show(ex.Message, "Duplicate Animal Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Opens a saved file
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentFile = dlg.FileName;

                    if (currentFile.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        animalManager.JsonDeserialize(currentFile);
                        animalManager.UpdateNextId();
                    }
                    else
                    {
                        MessageBox.Show("XML loading not supported.");
                    }

                    RefreshList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Clears all animals and starts a new session
        private void New_Click(object sender, EventArgs e)
        {
            if (animalManager.Count > 0)
            {
                DialogResult result =
                    MessageBox.Show("Discard current animals?",
                                    "Confirm",
                                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;
            }

            animalManager = new AnimalManager();
            currentFile = null;

            RefreshList();

            txtOutput.Text = "";
            picAnimal.Image = null;
            lstAnimals.DataSource = null;
        }

        // Sort animals by name
        private void SortName_Click(object sender, EventArgs e)
        {
            currentView = ViewMode.SortedName;
            RefreshList();
        }

        // Sort animals by age
        private void SortAge_Click(object sender, EventArgs e)
        {
            currentView = ViewMode.SortedAge;
            RefreshList();
        }

        // Show only mammals
        private void MammalsOnly_Click(object sender, EventArgs e)
        {
            currentView = ViewMode.Mammals;
            RefreshList();
        }

        // Displays average age statistics
        private void AvgAge_Click(object sender, EventArgs e)
        {
            int count = animalManager.Count;

            if (count == 0)
            {
                MessageBox.Show("No animals registered yet.");
                return;
            }

            double avg = animalManager.GetAverageAge();

            MessageBox.Show(
                $"Number of animals: {count}\nAverage animal age: {avg:F2}",
                "Statistics");
        }

        // Updates species list depending on selected category
        private void UpdateSpecies()
        {
            cmbSpecies.Items.Clear();

            if (rbMammal.Checked)
                cmbSpecies.Items.AddRange(new[] { "Dog", "Cat", "Cow" });

            else if (rbBird.Checked)
                cmbSpecies.Items.AddRange(new[] { "Chicken", "Falcon", "Raven" });

            else
                cmbSpecies.Items.AddRange(new[] { "Frog", "Snake", "Turtle" });

            if (cmbSpecies.Items.Count > 0)
                cmbSpecies.SelectedIndex = 0;
        }

        // Opens input form and creates a new animal
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (cmbSpecies.SelectedItem == null) return;

            string category =
                rbMammal.Checked ? "Mammal" :
                rbBird.Checked ? "Bird" : "Reptile";

            using (var dlg = new AnimalInputForm(category, cmbSpecies.SelectedItem.ToString()))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && dlg.CreatedAnimal != null)
                {
                    currAnimal = dlg.CreatedAnimal;

                    animalManager.AddWithUniqueId(currAnimal);

                    currAnimal = null;

                    txtOutput.Text = dlg.CreatedAnimal.ToString();

                    chkListAll.Checked = true;
                    RefreshList();

                    if (lstAnimals.Items.Count > 0)
                        lstAnimals.SelectedIndex = lstAnimals.Items.Count - 1;
                }
            }
        }

        // Deletes the selected animal
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstAnimals.SelectedItem == null)
            {
                MessageBox.Show("Please select an animal first.");
                return;
            }

            Animal selected = (Animal)lstAnimals.SelectedItem;

            int indexToRemove = -1;

            for (int i = 0; i < animalManager.Count; i++)
            {
                if (animalManager.GetAt(i).Id == selected.Id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                DialogResult result =
                    MessageBox.Show(
                        "Delete selected animal?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                animalManager.Remove(indexToRemove);

                RefreshList();

                txtOutput.Text = "";
                picAnimal.Image = null;
            }
        }

        // Loads an image for the last created animal
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            if (animalManager.Count == 0) return;

            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.png;*.bmp"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                animalManager.GetAt(animalManager.Count - 1).ImagePath = dlg.FileName;
                picAnimal.ImageLocation = dlg.FileName;
            }
        }

        // Refreshes the list of animals based on current view
        private void RefreshList()
        {
            lstAnimals.Visible = chkListAll.Checked;

            bool listMode = chkListAll.Checked;

            rbMammal.Enabled = !listMode;
            rbBird.Enabled = !listMode;
            rbReptile.Enabled = !listMode;
            cmbSpecies.Enabled = !listMode;

            btnCreate.Enabled = !listMode;
            btnDelete.Enabled = listMode;

            if (!chkListAll.Checked) return;

            lstAnimals.DataSource = null;

            switch (currentView)
            {
                case ViewMode.SortedName:
                    lstAnimals.DataSource = animalManager.GetAnimalsSortedByName();
                    break;

                case ViewMode.SortedAge:
                    lstAnimals.DataSource = animalManager.GetAnimalsSortedByAge();
                    break;

                case ViewMode.Mammals:
                    lstAnimals.DataSource = animalManager.GetMammalsOnly();
                    break;

                default:
                    lstAnimals.DataSource = animalManager.GetAll();
                    break;
            }

            lstAnimals.DisplayMember = "DisplayName";
            lstAnimals.ClearSelected();

            Text = $"EcoPark Animal Manager  |  Animals: {animalManager.Count}";
        }

        // Displays full details when an animal is selected
        private void lstAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAnimals.SelectedItem == null)
                return;

            Animal selected = (Animal)lstAnimals.SelectedItem;

            txtOutput.Text = selected.ToString();
            picAnimal.ImageLocation = selected.ImagePath;

            string animalType = selected.GetType().Namespace.ToLower();

            if (animalType.Contains("mammal"))
                rbMammal.Checked = true;
            else if (animalType.Contains("birds"))
                rbBird.Checked = true;
            else if (animalType.Contains("reptiles"))
                rbReptile.Checked = true;
        }
    }
}