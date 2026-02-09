using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Automation.Tests.Helpers;

namespace Automation.Tests.Pages

// I used the integrated CoPilot to help me out with creating the framework for the homepage, 
// and I will be using this as a template for the other pages as well.
// I will be using the same structure for the other pages as well, 
// I will be adding more methods to this page as I go along with the tests, but for now this is what I have.
{
    public class Homepage
    {
        private readonly IPage _page;

        public Homepage(IPage page)
        {
            _page = page;
        }

        // Selectors
        private ILocator NewsAndUpdatesTab => _page.Locator(".u-bg-quinary");
        private ILocator DifferenceIsClearSection => _page.Locator("text=THE DIFFERENCE IS CLEAR");
        private ILocator HowItWorks01 => _page.GetByText("Feed it anything");
        private ILocator HowItWorks05 => _page.GetByText("Lock the model");
        private ILocator JoinTheWaitlistSection => _page.Locator("#waitlist-form");
        private ILocator FaqSection => _page.Locator("#home-faq");

        // Methods
        public async Task GotoHomepage()
        {
            //await _page.GotoAsync(TestConfig.HomepageUrl);
            var url = TestConfig.DefaultHomepage; // or TestConfig.DefaultHomepage
            await _page.GotoAsync(url);
        }

        public async Task NavigateToNewsAndUpdates(SoftAssert softAssert = null)
        {
            softAssert ??= new SoftAssert();
            
            await NewsAndUpdatesTab.ScrollIntoViewIfNeededAsync();
            var isVisible = await NewsAndUpdatesTab.IsVisibleAsync();
            softAssert.AssertTrue(isVisible, "NewsAndUpdatesTab should be visible");
        }

        public async Task NavigateToDifferenceIsClearSection(SoftAssert softAssert = null)
        {
            softAssert ??= new SoftAssert();
            
            await DifferenceIsClearSection.ScrollIntoViewIfNeededAsync();
            var isVisible = await DifferenceIsClearSection.IsVisibleAsync();
            softAssert.AssertTrue(isVisible, "DifferenceIsClearSection should be visible");
            
            var text = await DifferenceIsClearSection.TextContentAsync();
            softAssert.AssertContains("CLEAR", text, "Section should contain 'CLEAR'");
            
            // I saw this method in the CoPilot suggestions and I thought it would be a good idea to take a screenshot of this section.
            // It needs another set of locators, so that it takes proper screenshots, but I'll leave it as it is for the time being, and I will be adding more locators to this section as I go along with the tests.
            await DifferenceIsClearSection.ScreenshotAsync(new LocatorScreenshotOptions { Path = "DifferenceIsClearSection.png" });
        }

        public async Task NavigateToHowItWorks01(SoftAssert softAssert = null)
        {  
            softAssert ??= new SoftAssert();
            
            //await HowItWorks01.ScrollIntoViewIfNeededAsync();
            var isVisible = await HowItWorks01.IsVisibleAsync();
            softAssert.AssertTrue(isVisible, "HowItWorks01 should be visible before clicking");
            
            await HowItWorks01.ClickAsync();
            await HowItWorks01.ScreenshotAsync(new LocatorScreenshotOptions { Path = "HowItWorks01.png" });
        }

        public async Task NavigateToHowItWorks05(SoftAssert softAssert = null)
        {
            softAssert ??= new SoftAssert();
            
            //await HowItWorks05.ScrollIntoViewIfNeededAsync();
            var isVisible = await HowItWorks05.IsVisibleAsync();
            softAssert.AssertTrue(isVisible, "HowItWorks05 should be visible before clicking");
            
            await HowItWorks05.ClickAsync();
            await HowItWorks05.ScreenshotAsync(new LocatorScreenshotOptions { Path = "HowItWorks02.png" });
        }

        public async Task NavigateToJoinTheWaitlistSection(SoftAssert softAssert = null)
        {
            softAssert ??= new SoftAssert();
            
            await JoinTheWaitlistSection.ScrollIntoViewIfNeededAsync();
            var isVisible = await JoinTheWaitlistSection.IsVisibleAsync();
            softAssert.AssertTrue(isVisible, "JoinTheWaitlistSection should be visible");
            
            await JoinTheWaitlistSection.ScreenshotAsync(new LocatorScreenshotOptions { Path = "JoinTheWaitlistSection.png" });
        }

        public async Task NavigateToFaqSection(SoftAssert softAssert = null)
        {
            softAssert ??= new SoftAssert();
            
            await FaqSection.ScrollIntoViewIfNeededAsync();
            var isVisible = await FaqSection.IsVisibleAsync();
            softAssert.AssertTrue(isVisible, "FaqSection should be visible");
            
            await FaqSection.ScreenshotAsync(new LocatorScreenshotOptions { Path = "FaqSection.png" });
        }
    }
}