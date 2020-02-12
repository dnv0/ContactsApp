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
        private Project _project;
        public MainForm()
        {
            InitializeComponent();

            // Загрузка файла с контактами
            //
            _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);

            // Загрузка в listBox контактов из ContactList
            //
            listBox1.DataSource = _project.ContactsList;
            listBox1.DisplayMember = "Surname";

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contact c = (Contact)listBox1.SelectedItem;
            textBoxSurename.Text = c.Surname;
            textBoxName.Text = c.Name;
            textBoxEmail.Text = c.Email;
            textBoxIdvkcom.Text = c.IDVkcom;
            textBoxPhone.Text = c.phoneNumber.Number;
            dateTimePicker1.Value = c.DateOfBirth;
        }
    }
}
