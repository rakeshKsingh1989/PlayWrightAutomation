using Microsoft.Playwright;
using NUnit.Framework;

namespace PlayWrightAutomation.NunitTests
{
    [TestFixture]
    public class TestBase
    {
        protected IBrowserContext IContext;
        protected IPage IPage;

        [SetUp]
        public void TestSetup()
        {
            // Reuse the global browser, but create a fresh context/page per test
            IContext = GlobalSetup.Browser
                .NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize=null,
                   
                    //ViewportSize = new ViewportSize { Width = 1920, Height = 1080 }
                })
                .GetAwaiter()
                .GetResult();

            IPage = IContext
                .NewPageAsync()
                .GetAwaiter()
                .GetResult();
        }

        [TearDown]
        public void TestTeardown()
        {
            IContext
                .CloseAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}
