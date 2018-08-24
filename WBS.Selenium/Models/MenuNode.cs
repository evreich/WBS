using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WBS.Selenium.Models
{
    [XmlType("node")]
    public class MenuNode
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlArray("children")]
        public List<MenuNode> Children { get; set; }
    }
}
