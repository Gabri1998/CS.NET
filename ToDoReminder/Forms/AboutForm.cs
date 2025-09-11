using System.Drawing;
using System.Windows.Forms;

namespace ToDoReminder.Forms
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            Text = "About ToDo Reminder";
            Size = new Size(400, 300);
            StartPosition = FormStartPosition.CenterParent;

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            Controls.Add(root);

            var picture = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = SystemIcons.Information.ToBitmap()
            };
            root.Controls.Add(picture, 0, 0);

            var lbl = new Label
            {
                Text = "ToDo Reminder\n\nDeveloped by [Your Name]\nMalmö University\n2025",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            root.Controls.Add(lbl, 0, 1);
        }
    }
}
