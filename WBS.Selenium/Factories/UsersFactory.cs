using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Factories
{
    /// <summary>
    ///  Класс UsersFactory
    ///  класс для работы со списком юзеров в Users.xml
    /// </summary>
    public class UsersFactory
    {
        private List<User> users;

        public UsersFactory()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("users"));
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "Configs\\Users.xml"));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                //заполнение листа юзеров из файла
                users = (List<User>)formatter.Deserialize(fs);
            }
        }

        public User GetUserbyName(UserNames userName)
        {
            return users.FirstOrDefault(u => u.Name == userName.ToString());
        }
    }
}
