FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TipsAPI/TipsAPI.csproj", "TipsAPI/"]
RUN dotnet restore "TipsAPI/TipsAPI.csproj"

WORKDIR "/src/TipsAPI"
COPY . .

RUN dotnet build "TipsAPI/TipsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TipsAPI/TipsAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TipsAPI.dll", "--urls", "http://0.0.0.0:5000", "http://0.0.0.0:5001"]