using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WBS.Selenium
{
    [XmlType("user")]
    public class User
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("login")]
        public string Login { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
    }
}
