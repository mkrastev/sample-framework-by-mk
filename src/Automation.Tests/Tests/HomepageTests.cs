using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;
using Automation.Tests;
using Automation.Tests.Helpers;

public class HomepageTests
{
    [Fact]
    public async Task VerifyHomepage()
    {
        await using var fixture = new PlaywrightFixture();
        var homepage = new Automation.Tests.Pages.Homepage(fixture.Page);
        var softAssert = new SoftAssert();

        await homepage.GotoHomepage();
        await homepage.NavigateToNewsAndUpdates(softAssert);
        await homepage.NavigateToDifferenceIsClearSection(softAssert);
        await homepage.NavigateToHowItWorks01(softAssert);
        await homepage.NavigateToHowItWorks05(softAssert);
        await homepage.NavigateToJoinTheWaitlistSection(softAssert);
        await homepage.NavigateToFaqSection(softAssert);
        
        // Check all soft assertions at the end
        softAssert.AssertAll();
    }
}