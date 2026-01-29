using EcoPark_Animal_Management_System.animal_gen;
using EcoPark_Animal_Management_System.enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EcoPark_Animal_Management_System
{
    // Popup form used to create a single animal with dynamic inputs
    public class AnimalInputForm : Form
    {
        // The created animal returned to MainForm
        public Animal CreatedAnimal { get; private set; }

        // Base animal inputs
        private TextBox txtName;
        private NumericUpDown numAge;
        private NumericUpDown numWeight;
        private ComboBox cmbGender;

        // Category-level inputs
        private NumericUpDown numCat1;
        private NumericUpDown numCat2;
        private TextBox txtCat;
        private CheckBox chkCat;

        // Species-level inputs
        private TextBox txtSpec;
        private NumericUpDown numSpec1;
        private NumericUpDown numSpec2;
        private CheckBox chkSpec;

        // Selected category and species
        private readonly string category;
        private readonly string species;

        public AnimalInputForm(string category, string species)
        {
            this.category = category;
            this.species = species;
            InitializeUI();
        }

        // Builds the form dynamically based on category and species
        private void InitializeUI()
        {
            Text = species + " Details";
            Size = new Size(380, 620);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;

            // Base animal data
            txtName = AddTextBox("Name", ref y);
            numAge = AddNumber("Age", 0, 100, ref y);
            numWeight = AddNumber("Weight", 1, 500, ref y);
            cmbGender = AddComboBox("Gender", Enum.GetNames(typeof(GenderType)), ref y);

            // Category-specific inputs
            if (category == "Mammal")
            {
                numCat1 = AddNumber("Number of teeth", 0, 100, ref y);
                numCat2 = AddNumber("Tail length (cm)", 0, 300, ref y);
                chkCat = AddCheckBox("Has fur", ref y);
            }
            else if (category == "Bird")
            {
                numCat1 = AddNumber("Wing span (m)", 0, 20, ref y);
                txtCat = AddTextBox("Feather color", ref y);
                chkCat = AddCheckBox("Can fly", ref y);
            }
            else
            {
                numCat1 = AddNumber("Body length (cm)", 0, 500, ref y);
                numCat2 = AddNumber("Aggressiveness (0–10)", 0, 10, ref y);
                chkCat = AddCheckBox("Lives in water", ref y);
            }

            // Species-specific inputs
            if (species == "Dog")
            {
                txtSpec = AddTextBox("Breed", ref y);
                chkSpec = AddCheckBox("Is trained", ref y);
                numSpec1 = AddNumber("Loyalty level", 0, 10, ref y);
            }
            else if (species == "Cat")
            {
                txtSpec = AddTextBox("Fur color", ref y);
                chkSpec = AddCheckBox("Is indoor", ref y);
            }
            else if (species == "Cow")
            {
                numSpec1 = AddNumber("Milk per day (L)", 0, 10, ref y);
            }
            else if (species == "Chicken")
            {
                chkSpec = AddCheckBox("Is domestic", ref y);
                numSpec1 = AddNumber("Eggs per week", 0, 20, ref y);
            }
            else if (species == "Falcon")
            {
                numSpec1 = AddNumber("Flying speed", 0, 300, ref y);
                numSpec2 = AddNumber("Hunting accuracy", 0, 10, ref y);
            }
            else if (species == "Raven")
            {
                txtSpec = AddTextBox("Beak color", ref y);
                numSpec1 = AddNumber("Intelligence level", 0, 10, ref y);
            }
            else if (species == "Frog")
            {
                numSpec1 = AddNumber("Jump height", 0, 10, ref y);
                chkSpec = AddCheckBox("Can live on land", ref y);
            }
            else if (species == "Snake")
            {
                chkSpec = AddCheckBox("Is venomous", ref y);
                numSpec1 = AddNumber("Bite range", 0, 10, ref y);
            }
            else if (species == "Turtle")
            {
                numSpec1 = AddNumber("Shell width", 0, 3, ref y);
                chkSpec = AddCheckBox("Is aquatic", ref y);
            }

            // Confirm creation
            Button ok = new Button
            {
                Text = "OK",
                Location = new Point(140, y + 10),
                Width = 80
            };
            ok.Click += (s, e) =>
            {
                CreatedAnimal = CreateAnimal();
                DialogResult = DialogResult.OK;
                Close();
            };
            Controls.Add(ok);
        }

        // Creates and populates the animal object
        private Animal CreateAnimal()
        {
            Animal animal = null;

            if (species == "Dog") animal = new category.mammal.species.Dog();
            else if (species == "Cat") animal = new category.mammal.species.Cat();
            else if (species == "Cow") animal = new category.mammal.species.Cow();
            else if (species == "Chicken") animal = new category.birds.species.Chicken();
            else if (species == "Falcon") animal = new category.birds.species.Falcon();
            else if (species == "Raven") animal = new category.birds.species.Raven();
            else if (species == "Frog") animal = new category.reptiles.species.Frog();
            else if (species == "Snake") animal = new category.reptiles.species.Snake();
            else if (species == "Turtle") animal = new category.reptiles.species.Turtle();

            if (animal == null) return null;

            // Base properties
            animal.Name = txtName.Text;
            animal.Age = (int)numAge.Value;
            animal.Weight = (double)numWeight.Value;
            animal.Gender = (GenderType)Enum.Parse(
                typeof(GenderType),
                cmbGender.SelectedItem.ToString()
            );

            // Category properties
            if (animal is category.mammal.Mammal m)
            {
                m.NumberOfTeeth = (int)numCat1.Value;
                m.TailLength = (double)numCat2.Value;
                m.HasFur = chkCat.Checked;
            }
            else if (animal is category.birds.Bird b)
            {
                b.WingSpan = (double)numCat1.Value;
                b.FeatherColor = txtCat.Text;
                b.CanFly = chkCat.Checked;
            }
            else if (animal is category.reptiles.Reptile r)
            {
                r.BodyLength = (double)numCat1.Value;
                r.AggressivenessLevel = (int)numCat2.Value;
                r.LivesInWater = chkCat.Checked;
            }

            // Species-specific assignments are handled above

            return animal;
        }

        // Helper to add a labeled textbox
        private TextBox AddTextBox(string label, ref int y)
        {
            Controls.Add(new Label { Text = label, Location = new Point(20, y) });
            y += 20;
            var box = new TextBox { Location = new Point(20, y), Width = 300 };
            Controls.Add(box);
            y += 30;
            return box;
        }

        // Helper to add a labeled numeric input
        private NumericUpDown AddNumber(string label, int min, int max, ref int y)
        {
            Controls.Add(new Label { Text = label, Location = new Point(20, y) });
            y += 20;
            var num = new NumericUpDown
            {
                Location = new Point(20, y),
                Minimum = min,
                Maximum = max,
                Width = 300
            };
            Controls.Add(num);
            y += 30;
            return num;
        }

        // Helper to add a labeled dropdown
        private ComboBox AddComboBox(string label, string[] items, ref int y)
        {
            Controls.Add(new Label { Text = label, Location = new Point(20, y) });
            y += 20;
            var box = new ComboBox
            {
                Location = new Point(20, y),
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            box.Items.AddRange(items);
            box.SelectedIndex = 0;
            Controls.Add(box);
            y += 30;
            return box;
        }

        // Helper to add a checkbox
        private CheckBox AddCheckBox(string label, ref int y)
        {
            var chk = new CheckBox
            {
                Text = label,
                Location = new Point(20, y),
                AutoSize = true
            };
            Controls.Add(chk);
            y += 30;
            return chk;
        }
    }
}
