using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;
using MonitorEmail.Models;
using System.Security.Cryptography.X509Certificates;

namespace MonitorEmail.Service
{
    public class EmailService
    {
        private readonly EmailConfig _config;

        public EmailService(EmailConfig config)
        {
            _config = config;
        }

        public void TestarConexao()
        {
            using (var client = new ImapClient())
            {
                // Conecta ao servidor Imap
                client.Connect(_config.ImapServer, _config.ImapPort, true);

                // Autentica no servidor
                client.Authenticate(_config.Email, _config.Password);

                // Acessa a pasta INBOX
                var inbox = client.Inbox;
                // Abre a pasta em modo somente leitura
                inbox.Open(FolderAccess.ReadOnly);

                // Busca e-mails não lidos
                var naoLidos = inbox.Search(SearchQuery.NotSeen);

                Console.WriteLine($"E-mails não lidos: {naoLidos.Count}");

                // Desconecta do servidor
                client.Disconnect(true);
            }
        }
    }
}
