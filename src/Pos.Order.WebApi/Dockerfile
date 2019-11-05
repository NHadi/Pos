FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pos.Order.WebApi/Pos.Order.WebApi.csproj", "Pos.Order.WebApi/"]
COPY ["Pos.Order.Infrastructure/Pos.Order.Infrastructure.csproj", "Pos.Order.Infrastructure/"]
COPY ["Pos.Order.Domain/Pos.Order.Domain.csproj", "Pos.Order.Domain/"]
COPY ["Pos.Event.Contracts/Pos.Event.Contracts.csproj", "Pos.Event.Contracts/"]
RUN dotnet restore "Pos.Order.WebApi/Pos.Order.WebApi.csproj"
COPY . .
WORKDIR "/src/Pos.Order.WebApi"
RUN dotnet build "Pos.Order.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pos.Order.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pos.Order.WebApi.dll"]