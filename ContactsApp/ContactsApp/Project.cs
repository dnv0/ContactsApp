using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactsApp
{
    /// <summary>
    /// Список всех контактов, созданных в приложении
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов
        /// </summary>
        public List<Contact> ContactsList = new List<Contact>();

        /// <summary>
        /// Функция, выполняющая поиск контактов
        /// </summary>
        /// <param name="project">Список, который нужно отсортировать</param>
        /// <returns>Отсортированный список</returns>
        public static Project Sort(Project project, string substring)
        {
            Project sortedProject = new Project();

            //for (int i = 0; i < project.ContactsList.Count; i++)
            //{
            //    if (project.ContactsList[i].Surname.Contains(substring) ||
            //        project.ContactsList[i].Name.Contains(substring))
            //    {
            //        sortedProject.ContactsList.Add(project.ContactsList[i]);
            //    }
            //}

            foreach (Contact item in project.ContactsList)
            {
                if (item.Surname.Contains(substring) || item.Name.Contains(substring))
                {
                    sortedProject.ContactsList.Add(item);
                }
                    
            }

            if (sortedProject.ContactsList.Count == 0)
            {
                sortedProject = null;
                return sortedProject;
            }

            sortedProject.ContactsList.Sort();

            return sortedProject;
        }
    }
}
