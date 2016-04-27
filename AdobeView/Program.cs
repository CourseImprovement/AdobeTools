using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdobeView
{
    static class Program
    {
        public static User user;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program.user = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View());
        }

        public static void CreateAccounts()
        {
            string file = GetFile();
            string cookie = user.GetCookie();

            if (file == "File Not Found")
            {
                Console.WriteLine(file);
                return;
            }

            SLDocument xls = new SLDocument(file);
            SLWorksheetStatistics stats = xls.GetWorksheetStatistics();

            // check that the spreadsheet is correct
            if (xls.GetCellValueAsString(1, 1) != "First" && xls.GetCellValueAsString(1, 2) != "Last" && xls.GetCellValueAsString(1, 3) != "Email")
            {
                MessageBox.Show("Please be sure that the first row is in this form:\n| First | Last | Email |", "Invalid Excel File", MessageBoxButtons.OK);
                return;
            }

            // parse the excel file
            for (int i = 2; i <= stats.EndRowIndex; i++)
            {
                string first = xls.GetCellValueAsString(i, 1);
                string last = xls.GetCellValueAsString(i, 2);
                string email = xls.GetCellValueAsString(i, 3);
                
                OfficeCreation oc = new OfficeCreation(cookie, first, last, email);

                if (!oc.IsCreated())
                {
                    oc.CreateAccount();
                    oc.CreateOffice();
                    oc.CreateMeetings();
                }
            }

            MessageBox.Show("All instructors have offices.", "Office Creation Completed", MessageBoxButtons.OK);
        }

        public static void CreateMeetings()
        {
            string cookie = user.GetCookie();

            if (cookie == "")
                return;

            string file = GetFile();

            // check that the file exists
            if (file == "File Not Found")
            {
                Console.WriteLine(file);
                return;
            }

            SLDocument xls = new SLDocument(file);
            SLWorksheetStatistics stats = xls.GetWorksheetStatistics();

            // verify that the excel file is correct
            if (xls.GetCellValueAsString(1, 1) != "Course" && xls.GetCellValueAsString(1, 2) != "Section")
            {
                MessageBox.Show("Please be sure that the first row is in this form:\n| Course | Section |", "Invalid Excel File", MessageBoxButtons.OK);
                return;
            }
            int numMeetings = 0;
            // parse the excel file
            for (int i = 2; i <= stats.EndRowIndex; i++)
            {
                string courseName = xls.GetCellValueAsString(i, 1);
                string section = xls.GetCellValueAsString(i, 2);
                numMeetings = xls.GetCellValueAsInt32(i, 3);
                if (courseName != "")
                {
                    MeetingSetUp m = new MeetingSetUp(cookie, courseName, section, numMeetings);

                    m.CourseMeetingCreation();
                }
            }

            MessageBox.Show("Meeting creation complete.", "Meetings Creation Completed", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Prompts user for a file
        /// </summary>
        /// <returns>filename</returns>
        public static string GetFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            // Set filter options and filter index.
            dialog.Filter = "Excel (.xlsx)|*.xlsx";
            dialog.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                return dialog.FileName;
            else
                return "File Not Found";
        }
    }
}