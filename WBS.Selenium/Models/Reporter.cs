using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace WBS.Selenium.Models
{
    public class Reporter
    {
        private static Lazy<Reporter> lazy = new Lazy<Reporter>(() => new Reporter());
        private ExtentHtmlReporter htmlReporter;
        public static Reporter Instance => lazy.Value;

        public ExtentReports Report { get; private set; }
        public ExtentTest Test { get; private set; }
        public ExtentTest CurrentNode { get; private set; }
        public static string FileName { get; set; }
        public static string TitleName { get; set; }
        private NameValueCollection appSettings;
        private Reporter()
        {
            //GlobalSettingsFactory globalSettings = new GlobalSettingsFactory();
            string reportDate = DateTime.Now.ToString("dd.MM.yyyy");
            //string reportDate = DateTime.Now.ToString("dd.MM.yyyy HHч mmм");
            appSettings = ConfigurationManager.AppSettings;
            string reporter = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, appSettings.Get("reporter")));
            Directory.CreateDirectory(reporter);

            htmlReporter = new ExtentHtmlReporter(Path.Combine(reporter, $"{FileName} за {reportDate}.html"));
            htmlReporter.Configuration().DocumentTitle = TitleName;
            htmlReporter.Configuration().ReportName = TitleName;
            Report = new ExtentReports();
            Report.AttachReporter(htmlReporter);
            Report.AnalysisStrategy = AnalysisStrategy.Class;
        }

        public void CreateTest(string title)
        {
            Test = Report.CreateTest(title);
        }
        public void CreateNode(string title)
        {
            CurrentNode = Test.CreateNode(title);
        }

    }
}
