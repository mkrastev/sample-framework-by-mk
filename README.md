# Playwright Automation Framework

This project is a small Playwright-based automation framework focused on page-object patterns and clear, incremental test flows. It separates core, pages, and tests to keep responsibilities clean while experimenting with selectors and form interactions.

## What Has Been Built So Far

- Homepage page object with navigation helpers and targeted screenshots for key sections.
- Waitlist page object that fills a multi-step form, uses a dropdown helper, and intentionally avoids submitting a production form.
- Two tests: one for homepage navigation and one for filling the waitlist form with test data.
- A reusable dropdown helper that selects by index (1-based) for native `<select>` and custom dropdowns.

## What Was Done With Copilot Assistance

- Initial page-object scaffold for the homepage (structure, method layout, and selector placeholders).
- Screenshot usage for sections as a quick visual validation tool.
- Early drafts of helper patterns that were then refined to fit the test behavior.

## Design Decisions And Rationale

- **Page object structure:** The homepage page object is used as a template for new pages to keep tests consistent and readable.
- **Screenshots for sections:** Added for quick visual verification while selectors are still evolving.
- **Dropdown selection by index:** The helper selects by index to avoid fragile value matching when the actual `<option>` values are unknown or unstable.
- **No production submit:** The waitlist submit action is intentionally commented out to avoid submitting data to a live environment.
- **Simple test data:** The waitlist test uses a single `ValidUser` object for clarity; Additional datasets can be added later.

## Project Structure

```
playwright-automation
├── src
│   └── Automation.Tests         # Page objects, Test Configs, Page Extensions, and Test cases
├── PlaywrightAutomation.sln     # Solution file
├── Directory.Build.props        # Common properties for all projects
└── README.md                    # Project documentation
```

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

### Notes

- Screenshots are saved relative to the test run working directory (typically the test output folder under `src/Automation.Tests/bin/Debug/...`).
- If a selector resolves to multiple elements, Playwright strict mode will throw; update the selector to be more specific.