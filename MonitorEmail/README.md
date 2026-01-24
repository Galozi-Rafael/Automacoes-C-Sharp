# Robô Monitor de E-mail
Esse projeto visa implementar uma automação que irá monitorar certa pasta em uma conta de e-mail, ler as mensagem e fazer download de qualquer anexo para um diretório local.

## Objetivos do Robô
1. Monitorar uma caixa de E-mail;
2. Identificar se chegam novas mensagens;
3. Verificar se essas mensagens possuem anexos;
4. Se tiver anexos:
 - Marcar o e-mail como lido;
 - Salvar os anexos em uma pasta local.
 
 ## Contribuição do robô
 1. Evita trabalho repetitivo;
 2. Evita erros humanos;
 3. Evita atrasos no processamento de documento.
 
## Diagrama
```mermaid
flowchart TD
    A([Início do robô]) --> B[Conectar à conta de e-mail]

    B --> C[Buscar e-mails não lidos]
    C --> D{Existe e-mail não lido?}

    D -- Não --> W[Aguardar intervalo de monitoramento]
    W --> C

    D -- Sim --> E[Selecionar próximo e-mail]
    E --> F{O e-mail possui anexo?}

    F -- Não --> G[Marcar e-mail como lido]
    G --> C

    F -- Sim --> I[Salvar anexo na pasta]
    I --> J[Marcar e-mail como lido]
    J --> C
```

## Estrutura do Repositório

```mermaid
graph LR
A[MonitorEmail] --> B[src]
A --> C[.gitignore]
A --> E[MonitorEmail.slnx]
A --> D[README.md]
B --> F[MonitorEmail]

F --> G[Models]
F --> H[Service]
F --> I[obj]
F --> J[MonitorEmail.csproj]
F --> K[Program.cs]

G --> M[EmailConfig.cs]
H --> N[EmailService.cs]
```