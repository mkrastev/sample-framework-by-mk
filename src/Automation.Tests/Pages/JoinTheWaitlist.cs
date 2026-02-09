using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Automation.Tests.Helpers;

namespace Automation.Tests.Pages
{
    public class JoinTheWaitlist
    {
        private readonly IPage _page;

        public JoinTheWaitlist(IPage page)
        {
            _page = page;
        }

        // Selectors
        private ILocator FirstNameField => _page.Locator("#First-Name");
        private ILocator LastNameField => _page.Locator("#Last-Name");
        private ILocator EmailField => _page.Locator("#Email-Address");
        private ILocator NextButton => _page.Locator("#Next-form");
        private ILocator UserDescriptorButtonProfessional => _page.GetByText("I Am A Professional");
        // private ILocator IndustryDropdownButton => _page.Locator("#Industry");
        // private ILocator CompanySizeDropdownButton => _page.Locator("#Company-Size");
        // private ILocator JobFunctionDropdownButton => _page.Locator("#Job-Function");
        // private ILocator CurrentOrFutureProjectDropdownButton => _page.Locator("#Current-or-Future-Project");
        // I couldn't think of a good way to get the locators for the dropdowns within the FillWaitlistForm method,
        // so I'll leave it as it is for now.
        private ILocator DescribeYourProjectField => _page.Locator("#Describe-your-project");
        private ILocator MarketingOptInCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "communications-consent" });
        private ILocator TermsAndConditionsCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Email-Consent" });
        private ILocator JoinTheWaitlistSubmitButton => _page.Locator("._w-full");
        // Methods
        public async Task NavigateToJoinTheWaitlistSection()
        {
            var url = TestConfig.WaitlistUrl;
            await _page.GotoAsync(url);
            Console.WriteLine($"Navigated to Waitlist Section");
        }
        public async Task FillWaitlistForm(UserData user)
        {
            await FirstNameField.FillAsync(user.FirstName);
            await LastNameField.FillAsync(user.LastName);
            await EmailField.FillAsync(user.Email);
            await NextButton.ClickAsync();
            await UserDescriptorButtonProfessional.ClickAsync();
            await _page.SelectDropdownByValueAsync("#Industry", user.Industry.ToString());
            await _page.SelectDropdownByValueAsync("#Company-Size", user.CompanySize.ToString());
            await _page.SelectDropdownByValueAsync("#Job-Function", user.JobFunction.ToString());
            await _page.SelectDropdownByValueAsync("#Current-or-Future-Project", user.CurrentOrFutureProject.ToString());
            await DescribeYourProjectField.FillAsync(user.ProjectDescription);
            //await MarketingOptInCheckBox.CheckAsync();
            //await TermsAndConditionsCheckBox.CheckAsync();
        }

        public async Task SubmitWaitlistForm()
        {
            //await JoinTheWaitlistSubmitButton.ClickAsync();
            Console.WriteLine($"I don't want to submit the form on Prod, but here we are");
        }
    }
}