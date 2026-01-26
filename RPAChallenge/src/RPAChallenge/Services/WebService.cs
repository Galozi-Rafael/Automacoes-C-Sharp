/* Usando Page Object Model
 * Refatorando o código para ter uma arquitetura mais limpa
 * Cada página tem que ter uma única função
 */
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Services
{
    public class RPAChallengePage
    {
        // Cria uma instância (aba no navegador) IPage na variável _page
        private readonly IPage _page; // Underscore é padrão para variável private

        /* Construtor da classe.
         * Aqui a _page será guardada na variável pública page.
         * garante que a instância da página não será modificada.
         */
        public RPAChallengePage(IPage page)
        {
            _page = page;
        }

        // Métodos da página!
        public async Task GoAsync()
        {
            await _page.GotoAsync("http://www.rpachallenge.com/");
        }

        // Cria o método que baixa o arquivo Excel.
        public async Task DownloadExcelAsync(string outputFilePath)
        {
            // Garantir que a pasta de destino existe.
            var folder = Path.GetDirectoryName(outputFilePath);

            if (!string.IsNullOrWhiteSpace(folder) && !Directory.Exists(folder));
            {
                Directory.CreateDirectory(folder);
            }

            // Inicia o download e espera até que ele seja concluído.
            var download = await _page.RunAndWaitForDownloadAsync(async () =>
            {
                await _page.GetByRole(AriaRole.Link, new() { Name = "Download Excel" }).ClickAsync();
            });

            // Salva o arquivo baixado no caminho especificado.
            await download.SaveAsAsync(outputFilePath);
        }

        public async Task StartAsync()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Start" }).ClickAsync();
        }

        public async Task FillFormsAsync(
            string firstName,
            string lastName,
            string company,
            string role,
            string address,
            string email,
            string phone)
        {
            await _page.Locator("[ng-reflect-name=\"labelFirstName\"]").FillAsync(firstName);
            await _page.Locator("[ng-reflect-name=\"labelLastName\"]").FillAsync(lastName);
            await _page.Locator("[ng-reflect-name=\"labelCompanyName\"]").FillAsync(company);
            await _page.Locator("[ng-reflect-name=\"labelRole\"]").FillAsync(role);
            await _page.Locator("[ng-reflect-name=\"labelAddress\"]").FillAsync(address);
            await _page.Locator("[ng-reflect-name=\"labelEmail\"]").FillAsync(email);
            await _page.Locator("[ng-reflect-name=\"labelPhone\"]").FillAsync(phone);
        }

        public async Task SubmitAsync()
        {
            await _page.ClickAsync("input[type='submit']");            
        }

        
    }
}
