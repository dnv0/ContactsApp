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
        // Создаем список контактов.
        //
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

        /// <summary>
        /// Вывод выбранного элемента из ListBox
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
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

        /// <summary>
        /// Функция добавления контакта.
        /// </summary>
        private void AddContact()
        {
            var newForm = new AddEditForm();

            //Создаем переменную, в которую помещаем результат взаимодействия пользователя с формой.
            var resultOfDialog = newForm.ShowDialog();

            //Если пользователь нажал ОК, то вносим исправленные данные.
            if (resultOfDialog == DialogResult.OK)
            {
                var contact = newForm.Contact;
                _project.ContactsList.Add(contact);

                ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);

                listBox1.DataSource = null;
                listBox1.DataSource = _project.ContactsList;
                listBox1.DisplayMember = "Surname";
            }
        }

        /// <summary>
        /// Вызов окна добавления контакта
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Вызов окна добавления контакта из выпадающего меню
        /// </summary>
        private void menuItem4_Click(object sender, EventArgs e)
        {
            AddContact();
        }
    }
}
