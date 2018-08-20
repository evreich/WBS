using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WBS.Selenium
{
    public class Context
    {
        public List<User> Users { get; set; }
        XmlSerializer formatter = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("users"));
        public Context()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "Configs\\Users.xml"));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Users = (List<User>)formatter.Deserialize(fs);
            }
        }
    }
}
