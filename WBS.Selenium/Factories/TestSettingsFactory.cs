using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace WBS.Selenium.Factories
{
    public class TestSettingsFactory
    {
        private XDocument testConfig;
        public TestSettingsFactory(string testId)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "Configs\\Tests\\"+testId+ ".xml"));
            testConfig = XDocument.Load(path);
        }

        public string GetValue(string key)
        {
            return testConfig.Root.Element(key).Value;
        }

        public string GetValue(string key, int index)
        {
            return testConfig.Root.Elements(key).ToList()[index].Value;
        }

        public List<string> GetValues(string key)
        {
            var elements = testConfig.Root.Elements(key).ToList();
            List<string> result = new List<string>();
            foreach (var element in elements)
                result.Add(element.Value);
            return result;
        }

        public void SetValue(string key, string value)
        {
            testConfig.Root.SetElementValue(key, value);
        }

        public void SetValue(string key, int index, string value)
        {
            testConfig.Root.Elements(key).ToList()[index].Value = value;
        }
    }
}
