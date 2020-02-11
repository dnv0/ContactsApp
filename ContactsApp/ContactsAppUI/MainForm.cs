using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsApp
{
    public partial class MainForm : Form
    {
        private Project project = new Project();
        private int n = 0;
        public MainForm()
        {
            InitializeComponent();

            Contact contact1 = new Contact
            {
                Surname = "Reeves",
                Name = "Keeanu",
                DateOfBirth = new DateTime(1990, 02, 26),
                Email = "123@mail.ru",
                IDVkcom = "1234567",
                phoneNumber = {Number = "79991234567"}
            };


            Contact contact2 = (Contact)contact1.Clone();

            Contact contact3 = new Contact
            {
                Surname = "Yolo",
                Name = "Volvo",
                DateOfBirth = new DateTime(1993, 05, 06),
                Email = "yolo@volvo.com",
                IDVkcom = "7654321",
                phoneNumber = { Number = "79993332211" }
            };

            project.ContactsList.Add(contact1);
            project.ContactsList.Add(contact2);
            project.ContactsList.Add(contact3);

            
                label1.Text = project.ContactsList[n].Surname;
                label2.Text = project.ContactsList[n].Name;
                label3.Text = project.ContactsList[n].DateOfBirth.ToString();
                label4.Text = project.ContactsList[n].Email;
                label5.Text = project.ContactsList[n].IDVkcom;
                label6.Text = project.ContactsList[n].phoneNumber.Number;

                label7.Text = "Contact Number: " + n;
            
           ProjectManager.SaveToFile(project, ProjectManager.stringMyDocumentsPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (project.ContactsList.Count-1 != n)
            {
                n++;
            }

            label1.Text = project.ContactsList[n].Surname;
            label2.Text = project.ContactsList[n].Name;
            label3.Text = project.ContactsList[n].DateOfBirth.ToString();
            label4.Text = project.ContactsList[n].Email;
            label5.Text = project.ContactsList[n].IDVkcom;
            label6.Text = project.ContactsList[n].phoneNumber.Number;

            label7.Text = "Contact Number: " + n;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (n != 0)
            {
                n--;
            }
            label1.Text = project.ContactsList[n].Surname;
            label2.Text = project.ContactsList[n].Name;
            label3.Text = project.ContactsList[n].DateOfBirth.ToString();
            label4.Text = project.ContactsList[n].Email;
            label5.Text = project.ContactsList[n].IDVkcom;
            label6.Text = project.ContactsList[n].phoneNumber.Number;

            label7.Text = "Contact Number: " + n;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contact contact4 = new Contact
            {
                Surname = "Unsaved",
                Name = "File",
                DateOfBirth = new DateTime(1995, 05, 06),
                Email = "unsaved@file.com",
                IDVkcom = "7654321",
                phoneNumber = { Number = "79993332211" }
            };
            project.ContactsList.Add(contact4);


        }

        private void button4_Click(object sender, EventArgs e)
        {
           project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);
        }
    }
}
