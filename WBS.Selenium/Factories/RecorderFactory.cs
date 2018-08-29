using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Factories
{
    /// <summary>
    ///  Класс RecorderFactory
    ///  класс для настройки видео
    /// </summary>
    public class RecorderFactory
    {
        private const string DefaultExtension = ".avi";
        private readonly string _defaultOutputPath = TestContext.CurrentContext.TestDirectory;
        private readonly VideoConfigurator _configurator;

        private RecorderFactory(VideoConfigurator configurator)
        {
            _configurator = configurator;
        }

        public static RecorderFactory Instance => new RecorderFactory(new VideoConfigurator() { Quality = VideoQuality.High });

        public VideoRecorder Create(string videoName)
        {
            return new VideoRecorder(videoName + DefaultExtension);
        }
    }
}
