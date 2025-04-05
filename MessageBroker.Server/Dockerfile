# Используем базовый образ для runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MessageBroker.Server/MessageBroker.Server.csproj", "MessageBroker.Server/"]
COPY ["MessageBroker.Kafka/MessageBroker.Kafka.csproj", "MessageBroker.Kafka/"]
RUN dotnet restore "MessageBroker.Server/MessageBroker.Server.csproj"

COPY . .
WORKDIR "/src/MessageBroker.Server"
RUN dotnet build "MessageBroker.Server.csproj" -c Release -o /app/build

# Этап публикации
FROM build AS publish
RUN dotnet publish "MessageBroker.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessageBroker.Server.dll"]