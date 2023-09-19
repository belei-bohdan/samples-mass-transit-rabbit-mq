FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TipsAPI.csproj", "TipsAPI/"]
RUN dotnet restore "TipsAPI/TipsAPI.csproj"

WORKDIR "/src/TipsAPI"
COPY . .

RUN dotnet build "TipsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TipsAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TipsAPI.dll", "--urls", "http://0.0.0.0:80"]