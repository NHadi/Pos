FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pos.Gateway.Securities/Pos.Gateway.Securities.csproj", "Pos.Gateway.Securities/"]
RUN dotnet restore "Pos.Gateway.Securities/Pos.Gateway.Securities.csproj"
COPY . .
WORKDIR "/src/Pos.Gateway.Securities"
RUN dotnet build "Pos.Gateway.Securities.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pos.Gateway.Securities.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pos.Gateway.Securities.dll"]