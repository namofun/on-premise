FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/src/OnPremise"
RUN dotnet build "JudgeOnPremise.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JudgeOnPremise.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JudgeOnPremise.dll"]