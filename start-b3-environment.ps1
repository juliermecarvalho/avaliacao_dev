# Define os caminhos das pastas
$apiPath = "B3\B3.Api"
$sitePath = "B3\B3.Site\b3site"

# Abrir a API .NET
Write-Host "Abrindo a API em: $apiPath"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $apiPath; dotnet run"

# Abrir o site Angular
Write-Host "Abrindo o site Angular em: $sitePath"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $sitePath; npm i --force; ng serve -o"