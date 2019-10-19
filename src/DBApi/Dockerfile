FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DBApi/DBApi/DBApi.csproj", "DBApi/DBApi/"]
RUN dotnet restore "DBApi/DBApi/DBApi.csproj"
COPY . .
WORKDIR "/src/DBApi/DBApi"
RUN dotnet build "DBApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DBApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DBApi.dll"]