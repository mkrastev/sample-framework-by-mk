# Playwright Automation Framework

This project is a small Playwright-based automation framework focused on page-object patterns and clear, incremental test flows. It separates core, pages, and tests to keep responsibilities clean while experimenting with selectors and form interactions.

## What Has Been Built So Far

- Homepage page object with navigation helpers and targeted screenshots for key sections.
- Waitlist page object that fills a multi-step form, uses a dropdown helper, and intentionally avoids submitting a production form.
- Two tests: one for homepage navigation and one for filling the waitlist form with test data.
- A reusable dropdown helper that selects by index (1-based) for native `<select>` and custom dropdowns.
- A `SoftAssert` helper class that collects multiple assertion failures and reports them all at once (non-breaking assertions).

## What Was Done With Copilot Assistance

- Initial page-object scaffold for the homepage (structure, method layout, and selector placeholders).
- Screenshot usage for sections as a quick visual validation tool.
- Early drafts of helper patterns that were then refined to fit the test behavior.
- Early SoftAssert implementation and suggestions for assertion strategies.

## Design Decisions And Rationale

- **Page object structure:** The homepage page object is used as a template for new pages to keep tests consistent and readable.
- **Screenshots for sections:** Added for quick visual verification while selectors are still evolving.
- **Dropdown selection by index:** The helper selects by index to avoid fragile value matching when the actual `<option>` values are unknown or unstable.
- **No production submit:** The waitlist submit action is intentionally commented out to avoid submitting data to a live environment.
- **Simple test data:** The waitlist test uses a single `ValidUser` object for clarity; additional datasets can be added later.
- **SoftAssert for visibility checks:** The homepage test now uses soft assertions to check element visibility before interacting, allowing all checks to complete even if one fails. This provides better insights into page state with a single test run.

## Project Structure

```
playwright-automation
├── src
│   └── Automation.Tests         # Page objects, Test Configs, Page Extensions,SoftAssert and Test cases
├── PlaywrightAutomation.sln     # Solution file
├── Directory.Build.props        # Common properties for all projects
└── README.md                    # Project documentation
```

## Helper Classes

### PageExtensions
- `SelectDropdownByValueAsync(selector, index)` — Selects a dropdown option by 1-based index. Handles both native `<select>` and custom dropdowns.

### SoftAssert
Available methods:
- `AssertTrue(condition, message)` — Asserts a boolean condition without throwing immediately.
- `AssertEqual<T>(expected, actual, message)` — Asserts equality of two values.
- `AssertContains(substring, fullString, message)` — Asserts substring presence.
- `Fail(message)` — Record a custom failure message.
- `HasErrors()` / `ErrorCount()` — Check if errors exist or get the count.
- `GetErrorsSummary()` — Get all errors as a formatted string.
- `AssertAll()` — Throws an exception with all collected errors (call at test end).
- `Clear()` — Reset all logged errors.

## Getting Started

### Prerequisites

- .NET SDK (version 6.0 or later recommended)
- Node.js (for Playwright)

### Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   cd playwright-automation
   ```

2. Restore the dependencies:
   ```
   dotnet restore
   ```

3. Install Playwright:
   ```
   npm install -D playwright
   ```

### Running Tests

```
dotnet test
```

### Example: Using SoftAssert

The homepage test demonstrates soft assertions in action:

```csharp
[Fact]
public async Task TestHomepage()
{
    var softAssert = new SoftAssert();

    // Pass softAssert to page methods
    await homepage.NavigateToNewsAndUpdates(softAssert);
    await homepage.NavigateToDifferenceIsClearSection(softAssert);
    // ... more navigation methods
    
    // Collect all assertion results at the end
    softAssert.AssertAll();  // Throws with all collected errors if any failed
}
```

Page methods check visibility before interaction:

```csharp
public async Task NavigateToNewsAndUpdates(SoftAssert softAssert = null)
{
    softAssert ??= new SoftAssert();
    
    await NewsAndUpdatesTab.ScrollIntoViewIfNeededAsync();
    var isVisible = await NewsAndUpdatesTab.IsVisibleAsync();
    softAssert.AssertTrue(isVisible, "NewsAndUpdatesTab should be visible");
    
    Console.WriteLine($"Navigated to News and Updates Tab");
}
```

### Notes

- Screenshots are saved relative to the test run working directory (typically the test output folder under `src/Automation.Tests/bin/Debug/...`).
- If a selector resolves to multiple elements, Playwright strict mode will throw; update the selector to be more specific.