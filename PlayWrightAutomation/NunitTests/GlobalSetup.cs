
using Microsoft.Playwright;
using NUnit.Framework;
namespace PlayWrightAutomation.NunitTests
{
    // Global setup fixture (runs once for the whole test run)
    [SetUpFixture]
    public class GlobalSetup
    {        
        public static IPlaywright Playwright;
        public static IBrowser Browser;

        [OneTimeSetUp]
        public async Task Setup()
        {
            Playwright = Microsoft.Playwright.Playwright.CreateAsync().GetAwaiter().GetResult();
            Browser = Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome", // or "msedge" for Edge
                Args = new[] { "--start-maximized" }

            }).GetAwaiter().GetResult();
        }

        [OneTimeTearDown] 
        public void GlobalTeardown() 
        {
            Browser.CloseAsync().GetAwaiter().GetResult();
            Playwright.Dispose();
        }


    }
}
