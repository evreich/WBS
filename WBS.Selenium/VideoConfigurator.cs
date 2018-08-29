using System.Windows.Forms;
using WBS.Selenium.Enums;

namespace WBS.Selenium
{
    public class VideoConfigurator
    {
        public int Width { get; } = SystemInformation.PrimaryMonitorSize.Width;
        public int Height { get; } = SystemInformation.PrimaryMonitorSize.Height;
        public int FramePerSecond { get; set; } = 30;
        public int FrameCount { get; } = 0;
        public VideoQuality Quality { get; set; } = VideoQuality.VeryLow;

        public VideoConfigurator() { }

        public VideoConfigurator(int fps, VideoQuality quality)
        {
            FramePerSecond = fps;
            Quality = quality;
        }
    }
}
