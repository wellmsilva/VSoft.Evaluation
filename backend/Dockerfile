FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/VSoft.Evaluation.WebApi/VSoft.Evaluation.WebApi.csproj", "src/VSoft.Evaluation.WebApi/"]
COPY ["src/VSoft.Evaluation.Domain/VSoft.Evaluation.Domain.csproj", "src/VSoft.Evaluation.Domain/"]
COPY ["src/VSoft.Evaluation.Application/VSoft.Evaluation.Application.csproj", "src/VSoft.Evaluation.Application/"]
COPY ["src/VSoft.Evaluation.Infrastructure/VSoft.Evaluation.Infrastructure.csproj", "src/VSoft.Evaluation.Infrastructure/"]
RUN dotnet restore "src/VSoft.Evaluation.WebApi/VSoft.Evaluation.WebApi.csproj"
COPY . .
WORKDIR "/src/src/VSoft.Evaluation.WebApi"
RUN dotnet dev-certs https --trust
RUN dotnet build "VSoft.Evaluation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VSoft.Evaluation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VSoft.Evaluation.WebApi.dll"]