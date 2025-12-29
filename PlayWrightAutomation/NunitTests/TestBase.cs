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
                .NewContextAsync()
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
