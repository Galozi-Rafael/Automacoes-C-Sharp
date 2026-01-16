using System;
using System.Collections.Generic;
using System.Text;

// Essa classe configura o robô para acessar o email
namespace MonitorEmail.Models
{
    public class EmailConfig
    {
        public string Email { get; set; }
        // Temporáriamente armazenar
        public string Password { get; set; }
        public string ImapServer { get; set; }
        public int ImapPort { get; set; }
        public string DownloadFolder { get; set; }
    }
}
