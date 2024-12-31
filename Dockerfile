# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar apenas os arquivos necessários para o restore
COPY *.sln .
COPY TradingBot.Application/*.csproj TradingBot.Application/
COPY TradingBot.Domain/*.csproj TradingBot.Domain/

# Restaurar dependências
RUN dotnet restore TradingBot.Application/TradingBot.Application.csproj

# Copiar todo o código-fonte
COPY . .

# Build da aplicação
WORKDIR /src/TradingBot.Application
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar a saída do build
COPY --from=build /app/publish .

# Criar o diretório de logs
RUN mkdir -p /app/logs

# Expor a porta da aplicação
EXPOSE 80

# Definir o entrypoint
ENTRYPOINT ["dotnet", "TradingBot.Application.dll"]
