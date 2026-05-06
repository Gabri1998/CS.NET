using EcoPark_Animal_Management_System.animal_gen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EcoPark_Animal_Management_System
{
    // Main application window
    public partial class MainForm : Form
    {
        // Stores all created animals during runtime using AnimalManager
        private AnimalManager animalManager = new AnimalManager();
        private Animal currAnimal = null;           // Temporary working animal
        private Animal editingAnimal = null;
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
        private Button btnChange;

        // Constructor initializes form
        public MainForm()
        {
            InitializeComponent();
            BuildUI();
        }

        // Builds the UI manually using fixed positioning
        private void BuildUI()
        {
            int xLeft = 20;
            int xRight = 520;
            int y = 20;

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

            // List of animals
            lstAnimals = new ListBox
            {
                Location = new Point(xLeft, y),
                Size = new Size(460, 120),
                Visible = false
            };
            lstAnimals.SelectedIndexChanged += lstAnimals_SelectedIndexChanged;
            Controls.Add(lstAnimals);

            y += 130;

            // Output box for animal details
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

            btnChange = new Button
            {
                Text = "Change Animal",
                Location = new Point(xRight, 100),
                Size = new Size(150, 30)
            };
            btnChange.Click += BtnChange_Click;
            Controls.Add(btnChange);

            // Image preview
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

        // Updates species list based on selected category
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

        // Opens input form and creates a new animal using AddWithUniqueId
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

                    RefreshList();
                }
            }
        }

        // Deletes the selected animal from the list
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstAnimals.SelectedIndex >= 0)
            {
                animalManager.Remove(lstAnimals.SelectedIndex);

                RefreshList();

                txtOutput.Text = "";
                picAnimal.Image = null;
            }
        }


        // Chenges the selected animal from the list
        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (lstAnimals.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an animal first.");
                return;
            }

            Animal selected = animalManager.GetAt(lstAnimals.SelectedIndex);

            using (var dlg = new AnimalInputForm(selected))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    
                    RefreshList();

                    txtOutput.Text = selected.ToString();
                    picAnimal.ImageLocation = selected.ImagePath;
                }
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

        // Refreshes the animal list when list mode is active
        private void RefreshList()
        {
            lstAnimals.Visible = chkListAll.Checked;

            bool listMode = chkListAll.Checked;

            rbMammal.Enabled = !listMode;
            rbBird.Enabled = !listMode;
            rbReptile.Enabled = !listMode;
            cmbSpecies.Enabled = !listMode;

            btnCreate.Enabled = !listMode;

            // FIX: Delete must stay enabled when listing animals
            btnDelete.Enabled = listMode;

            if (!chkListAll.Checked) return;

            lstAnimals.DataSource = null;

            lstAnimals.DataSource = animalManager.ToStringSummaryAllAnimals();
        }

        // Handles animal selection in the list and displays full details
        private void lstAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAnimals.SelectedIndex >= 0)
            {
                Animal selected = animalManager.GetAt(lstAnimals.SelectedIndex);

                if (selected != null)
                {
                    txtOutput.Text = selected.ToString();

                    picAnimal.ImageLocation = selected.ImagePath;

                    string animalType = selected.GetType().Namespace;

                    if (animalType.Contains("mammal"))
                        rbMammal.Checked = true;
                    else if (animalType.Contains("birds"))
                        rbBird.Checked = true;
                    else if (animalType.Contains("reptiles"))
                        rbReptile.Checked = true;
                }
            }
        }
    }
}