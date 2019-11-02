FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pos.Gateway/Pos.Gateway.csproj", "Pos.Gateway/"]
RUN dotnet restore "Pos.Gateway/Pos.Gateway.csproj"
COPY . .
WORKDIR "/src/Pos.Gateway"
RUN dotnet build "Pos.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pos.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pos.Gateway.dll"]