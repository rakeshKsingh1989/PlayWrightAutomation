using Microsoft.Playwright;
using NUnit.Framework;

namespace PlayWrightAutomation.NunitTests
{
    [TestFixture]
    public class ExampleTests : TestBase
    {           

        [Test]
        public async Task OpenDuckDuckGoTest()
        {
            IPage.GotoAsync("https://duckduckgo.com");
            await IPage.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var title = await IPage.TitleAsync();
            Assert.That(title, Does.Contain("DuckDuckGo"));
        }       
    }
}
