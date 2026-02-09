using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

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
        //private ILocator BigTextHomepage => _page.Locator(".h1_header");
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
            Console.WriteLine($"Navigated to Homepage");
        }

        public async Task NavigateToNewsAndUpdates()
        {
            await NewsAndUpdatesTab.ScrollIntoViewIfNeededAsync();
            Console.WriteLine($"Navigated to News and Updates Tab");
        }

        public async Task NavigateToDifferenceIsClearSection()
        {
            await DifferenceIsClearSection.ScrollIntoViewIfNeededAsync();
            // I saw this method in the CoPilot suggestions and I thought it would be a good idea to take a screenshot of this section.
            // It needs another set of locators, so that it takes proper screenshots, but I'll leave it as it is for the time being, and I will be adding more locators to this section as I go along with the tests.
            await DifferenceIsClearSection.ScreenshotAsync(new LocatorScreenshotOptions { Path = "DifferenceIsClearSection.png" });
            Console.WriteLine($"Navigated to The Difference Is Clear Section");
        }

        public async Task NavigateToHowItWorks01()
        {  
            //await HowItWorks01.ScrollIntoViewIfNeededAsync();
            await HowItWorks01.ClickAsync();
            await HowItWorks01.ScreenshotAsync(new LocatorScreenshotOptions { Path = "HowItWorks01.png" });
            Console.WriteLine($"Navigated to How It Works 01 Section");
        }

        public async Task NavigateToHowItWorks05()
        {
            //await HowItWorks05.ScrollIntoViewIfNeededAsync();
            await HowItWorks05.ClickAsync();
            await HowItWorks05.ScreenshotAsync(new LocatorScreenshotOptions { Path = "HowItWorks02.png" });
            Console.WriteLine($"Navigated to How It Works 02 Section"); 
        }

        public async Task NavigateToJoinTheWaitlistSection()
        {
            await JoinTheWaitlistSection.ScrollIntoViewIfNeededAsync();
            await JoinTheWaitlistSection.ScreenshotAsync(new LocatorScreenshotOptions { Path = "JoinTheWaitlistSection.png" });
            Console.WriteLine($"Navigated to Join The Waitlist Section");
        }

        public async Task NavigateToFaqSection()
        {
            await FaqSection.ScrollIntoViewIfNeededAsync();
            await FaqSection.ScreenshotAsync(new LocatorScreenshotOptions { Path = "FaqSection.png" });
            Console.WriteLine($"Navigated to FAQ Section");
        }
    }
}