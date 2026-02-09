using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Automation.Tests
{
    public class PlaywrightFixture : IAsyncDisposable
    {
        private readonly IBrowser _browser;
        private readonly IPage _page;

        public PlaywrightFixture()
        {
            _browser = CreateBrowserAsync().GetAwaiter().GetResult();
            _page = _browser.NewPageAsync().GetAwaiter().GetResult();
            // added this line to initialize the TestConfig before any tests run, and we can select a specific url from the appsettings.json file in the homepage.cs file.
            TestConfig.Init();
        }

        public async Task<IBrowser> CreateBrowserAsync()
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        }

        public async ValueTask DisposeAsync()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
        }

        public IPage Page => _page;
    }
}