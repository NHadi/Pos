FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pos.Report.WebApi/Pos.Report.WebApi.csproj", "Pos.Report.WebApi/"]
COPY ["Pos.Report.Infrastructure/Pos.Report.Infrastructure.csproj", "Pos.Report.Infrastructure/"]
COPY ["Pos.Report.Domain/Pos.Report.Domain.csproj", "Pos.Report.Domain/"]
RUN dotnet restore "Pos.Report.WebApi/Pos.Report.WebApi.csproj"
COPY . .
WORKDIR "/src/Pos.Report.WebApi"
RUN dotnet build "Pos.Report.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pos.Report.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pos.Report.WebApi.dll"]