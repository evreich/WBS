﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using WBS.Selenium.Factories;

namespace WBS.Selenium
{
    public class Context
    {
        public List<User> Users { get; set; }
        XmlSerializer formatter = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("users"));

        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait { get; set; }        

        public TestSettingsFactory TestSettings { get; protected set; }

        public Context(string testId)
        {
            Driver = new ChromeDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            TestSettings = new TestSettingsFactory(testId);
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "Configs\\Users.xml"));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Users = (List<User>)formatter.Deserialize(fs);
            }
        }
    }
}
