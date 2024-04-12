using System.Globalization;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: Xunit.TestFramework(
    "SSLTests.SetCultureInfo",
    "SSLTests")]
namespace SSLTests
{
    public class SetCultureInfo : XunitTestFramework
    {
        public SetCultureInfo(IMessageSink messageSink)
            : base(messageSink)
        {
            SetCulture();
        }

        public void SetCulture()
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            SetTimezone(TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
        }

        private static void SetTimezone(TimeZoneInfo timeZoneInfo)
        {
            var info = typeof(TimeZoneInfo).GetField("s_cachedData", BindingFlags.NonPublic | BindingFlags.Static);
            var cachedData = info.GetValue(null);
            var field = cachedData.GetType().GetField("_localTimeZone",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Instance);
            field.SetValue(cachedData, timeZoneInfo);
        }
    }
}