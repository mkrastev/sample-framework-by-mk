using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;
using Automation.Tests;
public class homepageTest
{
    [Fact]
    public async Task TestHomepage()
    {
        await using var fixture = new PlaywrightFixture();
        var homepage = new Automation.Tests.Pages.Homepage(fixture.Page);

        await homepage.GotoHomepage();
        await homepage.NavigateToNewsAndUpdates();
        await homepage.NavigateToDifferenceIsClearSection();
        await homepage.NavigateToHowItWorks01();
        await homepage.NavigateToHowItWorks05();
        await homepage.NavigateToJoinTheWaitlistSection();
        await homepage.NavigateToFaqSection();
    }
}