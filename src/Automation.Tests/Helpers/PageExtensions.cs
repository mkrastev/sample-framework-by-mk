using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Automation.Tests.Helpers
{
    public static class PageExtensions
    {
        /// Selects a dropdown option by index (1-based).
        /// Example: index "3" selects the 3rd option in the dropdown.
        public static async Task SelectDropdownByValueAsync(this IPage page, string selector, string index)
        {
            if (!int.TryParse(index, out int optionIndex) || optionIndex <= 0)
                throw new Exception($"Index must be a positive integer, got: {index}");

            await page.WaitForSelectorAsync(selector);
            var el = await page.QuerySelectorAsync(selector);
            if (el == null) throw new Exception($"Dropdown not found: {selector}");

            var tag = await el.EvaluateAsync<string>("e => e.tagName && e.tagName.toLowerCase()");
            if (tag == "select")
            {
                // Native <select>: get all option values and select by index
                var optionValues = await el.EvaluateAsync<string[]>(
                    "el => Array.from(el.querySelectorAll('option')).map(o => o.value)"
                );
                
                if (optionIndex > optionValues.Length)
                    throw new Exception($"Index {optionIndex} out of range (dropdown has {optionValues.Length} options)");
                
                var actualValue = optionValues[optionIndex - 1];
                await page.SelectOptionAsync(selector, actualValue);
                return;
            }

            // Custom dropdown: click toggle, then click option by index
            await page.ClickAsync(selector);
            await page.WaitForTimeoutAsync(300); // Wait for dropdown to open
            
            var options = page.Locator("[role='option'], .dropdown-item, li");
            var nth = options.Nth(optionIndex - 1);
            await nth.ClickAsync();
        }
    }
}