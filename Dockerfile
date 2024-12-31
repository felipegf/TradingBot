# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar apenas os arquivos necess�rios para o restore
COPY *.sln .
COPY TradingBot.Application/*.csproj TradingBot.Application/
COPY TradingBot.Domain/*.csproj TradingBot.Domain/

# Restaurar depend�ncias
RUN dotnet restore TradingBot.Application/TradingBot.Application.csproj

# Copiar todo o c�digo-fonte
COPY . .

# Build da aplica��o
WORKDIR /src/TradingBot.Application
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar a sa�da do build
COPY --from=build /app/publish .

# Criar o diret�rio de logs
RUN mkdir -p /app/logs

# Expor a porta da aplica��o
EXPOSE 80

# Definir o entrypoint
ENTRYPOINT ["dotnet", "TradingBot.Application.dll"]
