using System.Windows.Forms;

namespace Partycastle
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCostPerPerson;
        private TextBox txtFeePerPerson;
        private TextBox txtMaxGuests;
        private Label lblCostPerPerson;
        private Label lblFeePerPerson;
        private Label lblMaxGuests;
        private Button btnCalculate;
        private Label lblTotalCost;
        private Label lblTotalFees;
        private Label lblDeficit;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button btnAddGuest;
        private ListBox lstGuestList;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblGuestList;
        private Button btnDeleteGuest;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCostPerPerson = new System.Windows.Forms.TextBox();
            this.txtFeePerPerson = new System.Windows.Forms.TextBox();
            this.txtMaxGuests = new System.Windows.Forms.TextBox();
            this.lblCostPerPerson = new System.Windows.Forms.Label();
            this.lblFeePerPerson = new System.Windows.Forms.Label();
            this.lblMaxGuests = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblDeficit = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.lstGuestList = new System.Windows.Forms.ListBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblGuestList = new System.Windows.Forms.Label();
            this.btnDeleteGuest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCostPerPerson
            // 
            this.txtCostPerPerson.Location = new System.Drawing.Point(150, 20);
            this.txtCostPerPerson.Name = "txtCostPerPerson";
            this.txtCostPerPerson.Size = new System.Drawing.Size(100, 26);
            this.txtCostPerPerson.TabIndex = 0;
            // 
            // txtFeePerPerson
            // 
            this.txtFeePerPerson.Location = new System.Drawing.Point(150, 60);
            this.txtFeePerPerson.Name = "txtFeePerPerson";
            this.txtFeePerPerson.Size = new System.Drawing.Size(100, 26);
            this.txtFeePerPerson.TabIndex = 1;
            // 
            // txtMaxGuests
            // 
            this.txtMaxGuests.Location = new System.Drawing.Point(150, 100);
            this.txtMaxGuests.Name = "txtMaxGuests";
            this.txtMaxGuests.Size = new System.Drawing.Size(100, 26);
            this.txtMaxGuests.TabIndex = 2;
            // 
            // lblCostPerPerson
            // 
            this.lblCostPerPerson.AutoSize = true;
            this.lblCostPerPerson.Location = new System.Drawing.Point(20, 23);
            this.lblCostPerPerson.Name = "lblCostPerPerson";
            this.lblCostPerPerson.Size = new System.Drawing.Size(127, 20);
            this.lblCostPerPerson.TabIndex = 3;
            this.lblCostPerPerson.Text = "Cost per Person:";
            // 
            // lblFeePerPerson
            // 
            this.lblFeePerPerson.AutoSize = true;
            this.lblFeePerPerson.Location = new System.Drawing.Point(20, 63);
            this.lblFeePerPerson.Name = "lblFeePerPerson";
            this.lblFeePerPerson.Size = new System.Drawing.Size(122, 20);
            this.lblFeePerPerson.TabIndex = 4;
            this.lblFeePerPerson.Text = "Fee per Person:";
            // 
            // lblMaxGuests
            // 
            this.lblMaxGuests.AutoSize = true;
            this.lblMaxGuests.Location = new System.Drawing.Point(20, 103);
            this.lblMaxGuests.Name = "lblMaxGuests";
            this.lblMaxGuests.Size = new System.Drawing.Size(98, 20);
            this.lblMaxGuests.TabIndex = 5;
            this.lblMaxGuests.Text = "Max Guests:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Gold;
            this.btnCalculate.Location = new System.Drawing.Point(100, 140);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 30);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Create a list";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(20, 180);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(85, 20);
            this.lblTotalCost.TabIndex = 7;
            this.lblTotalCost.Text = "Total Cost:";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(20, 210);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(88, 20);
            this.lblTotalFees.TabIndex = 8;
            this.lblTotalFees.Text = "Total Fees:";
            // 
            // lblDeficit
            // 
            this.lblDeficit.AutoSize = true;
            this.lblDeficit.Location = new System.Drawing.Point(20, 240);
            this.lblDeficit.Name = "lblDeficit";
            this.lblDeficit.Size = new System.Drawing.Size(58, 20);
            this.lblDeficit.TabIndex = 9;
            this.lblDeficit.Text = "Deficit:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(150, 280);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 26);
            this.txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(150, 320);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 26);
            this.txtLastName.TabIndex = 11;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddGuest.Location = new System.Drawing.Point(150, 360);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(100, 30);
            this.btnAddGuest.TabIndex = 12;
            this.btnAddGuest.Text = "Add Guest";
            this.btnAddGuest.UseVisualStyleBackColor = false;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
            // 
            // lstGuestList
            // 
            this.lstGuestList.FormattingEnabled = true;
            this.lstGuestList.ItemHeight = 20;
            this.lstGuestList.Location = new System.Drawing.Point(300, 20);
            this.lstGuestList.Name = "lstGuestList";
            this.lstGuestList.Size = new System.Drawing.Size(200, 364);
            this.lstGuestList.TabIndex = 13;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 283);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(90, 20);
            this.lblFirstName.TabIndex = 14;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 323);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(90, 20);
            this.lblLastName.TabIndex = 15;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblGuestList
            // 
            this.lblGuestList.AutoSize = true;
            this.lblGuestList.Location = new System.Drawing.Point(300, 0);
            this.lblGuestList.Name = "lblGuestList";
            this.lblGuestList.Size = new System.Drawing.Size(86, 20);
            this.lblGuestList.TabIndex = 16;
            this.lblGuestList.Text = "Guest List:";
            // 
            // btnDeleteGuest
            // 
            this.btnDeleteGuest.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteGuest.Location = new System.Drawing.Point(349, 406);
            this.btnDeleteGuest.Name = "btnDeleteGuest";
            this.btnDeleteGuest.Size = new System.Drawing.Size(113, 30);
            this.btnDeleteGuest.TabIndex = 17;
            this.btnDeleteGuest.Text = "Delete Guest";
            this.btnDeleteGuest.UseVisualStyleBackColor = false;
            this.btnDeleteGuest.Click += new System.EventHandler(this.btnDeleteGuest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 460); // Adjusted ClientSize
            this.Controls.Add(this.lblGuestList);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lstGuestList);
            this.Controls.Add(this.btnAddGuest);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblDeficit);
            this.Controls.Add(this.lblTotalFees);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblMaxGuests);
            this.Controls.Add(this.lblFeePerPerson);
            this.Controls.Add(this.lblCostPerPerson);
            this.Controls.Add(this.txtMaxGuests);
            this.Controls.Add(this.txtFeePerPerson);
            this.Controls.Add(this.txtCostPerPerson);
            this.Controls.Add(this.btnDeleteGuest);
            this.Name = "Form1";
            this.Text = "Party Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
