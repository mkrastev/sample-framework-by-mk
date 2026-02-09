using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;
using Automation.Tests;
using System.ComponentModel.DataAnnotations;

public class JoinTheWaitlistTests
{
    // Here I put on some test data for filling the waitlist form
    // For the dropdowns I'll be using the helper method that I created in the PageExtensions class, so I won't be needing test data for the dropdowns
    // For bigger, more complicated forms, I'd create another helper class that will help me fill the forms with 
    // pre-made data sets
    public static readonly UserData ValidUser = new()
    {
        FirstName = "Han",
        LastName = "Solo",
        Email = "han.solo@test.com",
        Industry = 3,
        CompanySize = 2,
        JobFunction = 4,
        CurrentOrFutureProject = 5,
        ProjectDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
    };

    [Fact]
    public async Task PopulateAndSubmitWaitlistForm()
    {
        await using var fixture = new PlaywrightFixture();
        var joinTheWaitlist = new Automation.Tests.Pages.JoinTheWaitlist(fixture.Page);

        await joinTheWaitlist.NavigateToJoinTheWaitlistSection();
        await joinTheWaitlist.FillWaitlistForm(ValidUser);
        await joinTheWaitlist.SubmitWaitlistForm();
    }
}

public class UserData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ProjectDescription { get; set; }
    public int Industry { get; set; }
    public int CompanySize { get; set; }
    public int JobFunction { get; set; }    
    public int CurrentOrFutureProject { get; set; }
}