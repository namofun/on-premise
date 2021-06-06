FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/OnPremise/JudgeOnPremise.csproj", "src/OnPremise/"]
COPY ["src/Migrations.Postgres/SatelliteSite.Migrations.Postgres.csproj", "src/Migrations.Postgres/"]
COPY ["src/Migrations.SqlServer/SatelliteSite.Migrations.SqlServer.csproj", "src/Migrations.SqlServer/"]
COPY ["src/OnPremiseModule/SatelliteSite.OnPremiseModule.csproj", "src/OnPremiseModule/"]
COPY ["src/ExperimentalModule/SatelliteSite.ExperimentalModule.csproj", "src/ExperimentalModule/"]
RUN dotnet restore "src/OnPremise/JudgeOnPremise.csproj"
COPY . .
WORKDIR "/src/src/OnPremise"
RUN dotnet build "JudgeOnPremise.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JudgeOnPremise.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JudgeOnPremise.dll"]