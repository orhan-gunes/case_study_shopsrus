#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["shopsruscase.api/shopsruscase.api.csproj", "shopsruscase.api/"]
COPY ["Applications/shopsruscase.Applications.csproj", "Applications/"]
COPY ["Infrastructure/shopsruscase.Infrastructure.csproj", "Infrastructure/"]
COPY ["Domain/shopsruscase.Domain.csproj", "Domain/"]
RUN dotnet restore "shopsruscase.api/shopsruscase.api.csproj"
COPY . .
WORKDIR "/src/shopsruscase.api"
RUN dotnet build "shopsruscase.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "shopsruscase.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "shopsruscase.api.dll"]