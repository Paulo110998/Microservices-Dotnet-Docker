# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar o arquivo .csproj
COPY PublishService.csproj ./

# Restaurar apenas o PublishService
RUN dotnet restore ./PublishService.csproj

# Copiar o restante do código
COPY . ./

# Publicar o projeto
RUN dotnet publish ./PublishService.csproj -c Release -o /out

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "PublishService.dll"]
