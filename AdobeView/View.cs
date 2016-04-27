using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdobeView
{
    public partial class View : Form
    {
        private bool drag;
        private Point firstPoint;
        public View()
        {
            drag = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            firstPoint = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            ((Button)sender).Text = "Loading";
            Program.CreateAccounts();
            ((Button)sender).Text = "New Account/Office";
            ((Button)sender).Enabled = true;
        }

        private void View_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (Program.user == null || Program.user.GetCookie() == "" || Program.user.GetCookie() == null)
                {
                    Login l = new Login();
                    l.ShowDialog();
                }
                else break;
            }
        }

        private void MtgBtn_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            ((Button)sender).Text = "Loading";
            Program.CreateMeetings();
            ((Button)sender).Text = "New Meetings";
            ((Button)sender).Enabled = true;
        }

        private void AOExp_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();

            var newLine = string.Format("{0},{1},{2}", "First", "Last", "Email");
            var example = string.Format("{0},{1},{2}", "Bilbo", "Baggins", "bbaggins@byui.edu");
            csv.AppendLine(newLine);
            csv.AppendLine(example);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Adobe_Account_Office_Template.csv";
            sfd.ShowDialog();
            string path = sfd.FileName;

            File.WriteAllText(path, csv.ToString());

            MessageBox.Show("Download complete. Be sure to save your new file as a .xlsx file.", "Download Successful", MessageBoxButtons.OK);
        }

        private void mtgExp_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();

            var newLine = string.Format("{0},{1},{2}", "Course", "Section", "Number of Meetings");
            var example = string.Format("{0},{1},{2}", "AAA 555", "1", "8");
            csv.AppendLine(newLine);
            csv.AppendLine(example);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Adobe_Meetings_Template.csv";
            sfd.ShowDialog();
            string path = sfd.FileName;

            File.WriteAllText(path, csv.ToString());

            MessageBox.Show("Download complete. Be sure to save your new file as a .xlsx file.", "Download Successful", MessageBoxButtons.OK);
        }
    }
}
