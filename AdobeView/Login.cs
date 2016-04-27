using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdobeView
{
    public partial class Login : Form
    {
        private bool drag;
        private Point firstPoint;
        public Login()
        {
            drag = false;
            InitializeComponent();
            this.Username.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
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

        public string GetUsername()
        {
            return this.Username.Text;
        }

        public string GetPassword()
        {
            return this.Password.Text;
        }

        private void Alert(string text)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 100;
            prompt.Text = text;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = GetUsername();
            string password = GetPassword();
            if (username == "" || username == null)
            {
                Alert("Invalid Username");
            }
            else if (password == "" || password == null)
            {
                Alert("Invalid Password");
            }
            
            Program.user = new User(username, password);
            
            bool valid = Program.user.Authenticate();

            if (!valid)
            {
                MessageBox.Show("Invalid Login", "Error", MessageBoxButtons.OK);
            }
            else
            {
                this.Dispose();
            }

            
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginBtn_Click(sender, e);
            }
        }
    }
}
