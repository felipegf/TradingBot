# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos do projeto
COPY TradingBot.Application/*.csproj TradingBot.Application/
COPY TradingBot.Domain/*.csproj TradingBot.Domain/

# Restaurar depend�ncias
RUN dotnet restore TradingBot.Application/TradingBot.Application.csproj

# Criar o diret�rio de logs
RUN mkdir -p /app/logs

# Copiar todo o c�digo-fonte e publicar
COPY . .
WORKDIR /src/TradingBot.Application
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "TradingBot.Application.dll"]
