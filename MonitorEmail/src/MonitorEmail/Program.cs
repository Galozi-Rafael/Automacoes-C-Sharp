using System;
using MonitorEmail.Models;
using MonitorEmail.Service;
using System.Threading;


namespace MonitorEmail
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                // try/catch feito para capturar qualquer erro
                try
                {
                    var config = new EmailConfig
                    {
                        Email = "test@test.com",
                        Password = "senha",
                        ImapServer = "imap.imap.com",
                        ImapPort = 993,
                        DownloadFolder = @"C:\Anexos"
                    };

                    var emailService = new EmailService(config);
                    emailService.TestarConexao();


                }
                // Mostra no console qualquer erro que ocorrer
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                    Console.WriteLine("\nStackTrace:");
                    Console.WriteLine(ex.StackTrace);
                }

                // Encerra o programa de forma graciosa ao pressionar 'q'
                if (Console.KeyAvailable)
                {
                    var tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.Q)
                    {
                        continuar = false;
                        Console.WriteLine("O Monitoramento de E-mails foi encerrado com sucesso.");
                    }


                }

                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}