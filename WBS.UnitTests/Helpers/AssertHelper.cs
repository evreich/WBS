using Newtonsoft.Json;
using Xunit;

namespace WBS.Tests.Helpers
{
    public class AssertHelper
    {
        public static void JsonEquals<T>(T expected, T actual)
        {
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }
    }
}
