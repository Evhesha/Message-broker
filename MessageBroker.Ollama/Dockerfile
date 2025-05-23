﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MessageBroker.Ollama/MessageBroker.Ollama.csproj", "MessageBroker.Ollama/"]
COPY ["MessageBroker.Kafka/MessageBroker.Kafka.csproj", "MessageBroker.Kafka/"]
COPY ["MessageBroker.Server/MessageBroker.Server.csproj", "MessageBroker.Server/"]
RUN dotnet restore "MessageBroker.Ollama/MessageBroker.Ollama.csproj"
COPY . .
WORKDIR "/src/MessageBroker.Ollama"
RUN dotnet build "MessageBroker.Ollama.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MessageBroker.Ollama.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessageBroker.Ollama.dll"]
