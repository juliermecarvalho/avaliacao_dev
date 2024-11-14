# Define os caminhos das pastas
$apiTest = "B3\B3.Test"
$apiPath = "..\B3\B3.Api"
$sitePath = "B3\B3.Site\b3site"

# Executar os testes e iniciar a API .NET em uma única janela
Write-Host "Executando os testes e abrindo a API em: $apiTest e $apiPath"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $apiTest; dotnet restore; dotnet test --verbosity minimal; cd ..\$apiPath; dotnet restore; dotnet run"

# Abrir o site Angular em uma nova janela
Write-Host "Abrindo o site Angular em: $sitePath"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $sitePath; npm install --force or --legacy-peer-deps; ng serve -o"