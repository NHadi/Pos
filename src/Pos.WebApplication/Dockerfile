FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pos.WebApplication/Pos.WebApplication.csproj", "Pos.WebApplication/"]
RUN dotnet restore "Pos.WebApplication/Pos.WebApplication.csproj"
COPY . .
WORKDIR "/src/Pos.WebApplication"
RUN dotnet build "Pos.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pos.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pos.WebApplication.dll"]