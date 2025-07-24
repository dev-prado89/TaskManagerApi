# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

# Esto para ver si la carpeta está ahí durante la build
RUN ls -l /app/public

RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Copiamos la carpeta public manualmente
COPY --from=build /app/public ./public

ENTRYPOINT ["dotnet", "TaskManagerApi.dll"]