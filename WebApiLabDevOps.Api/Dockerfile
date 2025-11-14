# ===================== RUNTIME IMAGE =====================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# ===================== BUILD IMAGE =======================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["WebApiLabDevOps.Api/WebApiLabDevOps.Api.csproj", "WebApiLabDevOps.Api/"]
COPY ["WebApiLabDevOps.Dal/WebApiLabDevOps.Dal.csproj", "WebApiLabDevOps.Dal/"]
COPY ["WebApiLabDevOps.Domain/WebApiLabDevOps.Domain.csproj", "WebApiLabDevOps.Domain/"]
COPY ["WebApiLabDevOps.Service/WebApiLabDevOps.Service.csproj", "WebApiLabDevOps.Service/"]

RUN dotnet restore "WebApiLabDevOps.Api/WebApiLabDevOps.Api.csproj"

COPY . .
WORKDIR "/src/WebApiLabDevOps.Api"

RUN dotnet build "WebApiLabDevOps.Api.csproj" -c Release -o /app/build

# ===================== PUBLISH IMAGE =====================
FROM build AS publish
RUN dotnet publish "WebApiLabDevOps.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ===================== FINAL RUNTIME IMAGE ===============
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WebApiLabDevOps.Api.dll"]
