using System;
using System.Drawing;
using System.Windows.Forms;

namespace EcoPark_Animal_Management_System
{
    // Simple dialog that shows application information
    public class AboutForm : Form
    {
        public AboutForm()
        {
            // Form basic settings
            Text = "About";
            Size = new Size(300, 220);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // Application information label
            Controls.Add(new Label
            {
                Text = "Ahmed Algabri\nEcoPark Animal Management System\nVersion 1.0",
                Location = new Point(30, 30),
                AutoSize = true
            });

            // Information icon
            Controls.Add(new PictureBox
            {
                Image = SystemIcons.Information.ToBitmap(),
                Location = new Point(30, 100),
                Size = new Size(48, 48),
                SizeMode = PictureBoxSizeMode.Zoom
            });

            // OK button closes the dialog
            Button ok = new Button
            {
                Text = "OK",
                Location = new Point(180, 130),
                Size = new Size(70, 30)
            };
            ok.Click += (s, e) => Close();
            Controls.Add(ok);
        }
    }
}
