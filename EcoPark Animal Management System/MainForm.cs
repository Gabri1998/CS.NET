using EcoPark_Animal_Management_System.animal_gen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EcoPark_Animal_Management_System
{
    // Main application window
    public partial class MainForm : Form
    {
        // Stores all created animals during runtime
        private List<Animal> animals = new List<Animal>();

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
            lstAnimals.SelectedIndexChanged += (s, e) =>
            {
                if (lstAnimals.SelectedItem is Animal a)
                {
                    txtOutput.Text = a.ToString();
                    picAnimal.ImageLocation = a.ImagePath;
                }
            };
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
                    animals.Add(dlg.CreatedAnimal);
                    txtOutput.Text = dlg.CreatedAnimal.ToString();
                    RefreshList();
                }
            }
        }

        // Loads an image for the last created animal
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            if (animals.Count == 0) return;

            OpenFileDialog dlg = new OpenFileDialog { Filter = "Images|*.jpg;*.png;*.bmp" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                animals.Last().ImagePath = dlg.FileName;
                picAnimal.ImageLocation = dlg.FileName;
            }
        }

        // Refreshes the animal list when list mode is active
        private void RefreshList()
        {
            lstAnimals.Visible = chkListAll.Checked;
            if (!chkListAll.Checked) return;

            lstAnimals.DataSource = null;
            lstAnimals.DataSource = animals;
            lstAnimals.DisplayMember = "DisplayName";
        }
    }
}
