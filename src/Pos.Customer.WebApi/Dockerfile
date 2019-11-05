FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pos.Customer.WebApi/Pos.Customer.WebApi.csproj", "Pos.Customer.WebApi/"]
COPY ["Pos.Customer.Infrastructure/Pos.Customer.Infrastructure.csproj", "Pos.Customer.Infrastructure/"]
COPY ["Pos.Customer.Domain/Pos.Customer.Domain.csproj", "Pos.Customer.Domain/"]
COPY ["Pos.Event.Contracts/Pos.Event.Contracts.csproj", "Pos.Event.Contracts/"]
RUN dotnet restore "Pos.Customer.WebApi/Pos.Customer.WebApi.csproj"
COPY . .
WORKDIR "/src/Pos.Customer.WebApi"
RUN dotnet build "Pos.Customer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pos.Customer.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pos.Customer.WebApi.dll"]