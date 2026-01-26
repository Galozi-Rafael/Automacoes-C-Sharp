using ExcelReader.Services;
using Microsoft.Playwright;
using WebService.Services;
using System.Threading.Tasks;

namespace RPAChallenge
{
    class Program
    {
        public static async Task Main()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();

            var rpaPage = new RPAChallengePage(page);
            

            await rpaPage.GoAsync();

            string basePath = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(basePath, "data");
            string excelPath = Path.Combine(dataFolder, "challenge.xlsx");

            await rpaPage.DownloadExcelAsync(excelPath);

            var excelReader = new ExcelDataReader(excelPath);

            await rpaPage.StartAsync();

            int i = 1;
            foreach (var row in excelReader.ReadDataRow())
            {
                await rpaPage.FillFormsAsync(
                    row.Cell(1).GetValue<string>(),
                    row.Cell(2).GetValue<string>(),
                    row.Cell(3).GetValue<string>(),
                    row.Cell(4).GetValue<string>(),
                    row.Cell(5).GetValue<string>(),
                    row.Cell(6).GetValue<string>(),
                    row.Cell(7).GetValue<string>()
                    );
                await page.ScreenshotAsync(new PageScreenshotOptions { Path = dataFolder + @"\screenshoot" + i + ".png" });

                await rpaPage.SubmitAsync();

                i++;
            }

            await page.ScreenshotAsync(new PageScreenshotOptions { Path = dataFolder + @"\screenshootTelaFinal.png" });
        }
    }
}
