# Avaliação Dev para B3

Requisitos de Software:
	Visual Studio 2022 ou superior
	.NET 8.0 SDK ou superior
	angular 17 ou superior

Instruções para Abrir o Projeto B3.Api no Visual Studio:

1. Abra o Visual Studio e selecione "Abrir um Projeto ou Solução".
2. Navegue até a pasta "avaliacao_dev\B3" e selecione o arquivo com a extensão ".sln", "TARGET FRAMEWORK .NET 8.0"
3. Quando o projeto for aberto, clique com o botão direito do mouse no projeto "B3.Api" na janela "Solução" e selecione "Definir como Projeto de Inicialização".
4. Pressione "F5" para iniciar o projeto ou clique no ícone de play na barra de ferramentas.

Instruções para Executar os Testes no Projeto B3.Api:

1. No Visual Studio, clique na guia "Teste" na barra de menu.
2. Selecione "Executar todos os testes" ou pressione "Ctrl + R, V".
3. Verifique se todos os testes foram executados com sucesso.

Instruções para Abrir o Projeto B3.Site no Visual Studio Code:

1. Abra o Visual Studio Code e selecione "Abrir pasta".
2. Navegue até a pasta "avaliacao_dev\B3\B3.Site\b3site" e selecione-a.
3. Abra o terminal (Ctrl + ` ou clicando no ícone de terminal na barra de ferramentas) e execute o comando "npm install".
4. Após a instalação das dependências, execute o comando "ng serve --o".
5. Verifique se a variável "private readonly API = 'http://localhost:5280/';" no arquivo "services/investment.service.ts" está configurada corretamente.

Instruções para Uso do Script PowerShell:

Este script PowerShell automatiza a inicialização do backend e do frontend do projeto. Ele realiza as seguintes ações:

1. Navega até a pasta "B3\B3.Api" e executa o comando `dotnet run` para iniciar a API.
2. Abre uma nova janela do PowerShell, navega até a pasta "B3\B3.Site\b3site", instala as dependências do Angular com `npm install --force` e inicia o servidor com `ng serve -o`.

**Como Executar o Script:**

1. Certifique-se de que o PowerShell está configurado para permitir a execução de scripts.
   - Você pode ajustar isso executando `Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned` no PowerShell.
2. Execute o script com o comando `.\<nome_do_script>.ps1` na pasta onde ele está localizado.

**Sugestão de Nome para o Script:**
- `start-b3-environment.ps1`
