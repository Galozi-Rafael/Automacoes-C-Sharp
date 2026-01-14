using System;
using System.Threading;
using System.Reflection.Metadata.Ecma335;
using MoverArquivos.Services;

namespace MoverArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("MoverArquivosNome foi iniciado.");

            // Loop principal para monitorar e mover arquivos periodicamente.
            while (continuar)
            {
                try
                {
                    // Instancia o serviço de mover arquivos.
                    var serviceMover = new MoveFiles();

                    string sourceDir = @"C:\Input";
                    string destDir = @"C:\Output";

                    // Chama o método para organizar os arquivos.
                    serviceMover.OrganizeFiles(sourceDir, destDir);

                    Console.WriteLine("MoverArquivosNome foi concluído com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }


                // Verifica se a tecla 'Q' foi pressionada para encerrar o programa.
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Q)
                    {
                        continuar = false;
                        Console.WriteLine("O Monitor de Mover Arquivos foi encerrado com sucesso!");
                    }               
                }              
                
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }            
        }
    }
}