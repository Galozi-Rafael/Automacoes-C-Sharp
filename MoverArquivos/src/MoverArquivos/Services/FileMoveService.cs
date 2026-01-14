using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MoverArquivos.Services
{
    internal class MoveFiles
    {
        // Criação da função que é responsável por organizar os arquivos
        public void OrganizeFiles(string sourceDir, string destDir)
        {
            // Se falhar no início: captura o erro
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException("Diretório de entrada não existe." + sourceDir);
            }

            // Criação de variáveis para compor o nome da pasta destino
            var files = Directory.GetFiles(sourceDir);
            var dateFolder = DateTime.Today.ToString("yyyy-MM-dd");

            Console.WriteLine($"Foram encontrados {files.Length} arquivos.");

            // Cria o endereço da pasta de forma correta
            var destination = Path.Combine(destDir, dateFolder);

            // Cria o novo diretório
            Directory.CreateDirectory(destination);

            // Percorre cada item na array files e transporta para nova pasta
            foreach (var file in files)
            {
                // Captura o nome do arquivo e a extensão em variáveis separadas
                var fileName = Path.GetFileNameWithoutExtension(file);
                var extension = Path.GetExtension(file);

                // Cria a string contendo a data e hora atual
                var timeStamp = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
                // Cria o novo nome do arquivo
                var newFileName = $"{fileName}_{timeStamp}{extension}";

                // Cria o endereço do arquivo de forma correta
                var filePath = Path.Combine(destination, newFileName);

                File.Move(file, filePath);
            }
        }
    }
}