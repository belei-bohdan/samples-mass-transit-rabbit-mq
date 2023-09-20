FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 6000
EXPOSE 6001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ReportingAPI/ReportingAPI.csproj", "ReportingAPI/"]
RUN dotnet restore "ReportingAPI/ReportingAPI.csproj"

WORKDIR "/src/ReportingAPI"
COPY . .

RUN dotnet build "ReportingAPI/ReportingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportingAPI/ReportingAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportingAPI.dll", "--urls", "http://0.0.0.0:6000", "http://0.0.0.0:6001"]