#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Scheduling/Scheduling.API/Scheduling.API.csproj", "src/Services/Scheduling/Scheduling.API/"]
COPY ["src/Services/Scheduling/Scheduling.Application/Scheduling.Application.csproj", "src/Services/Scheduling/Scheduling.Application/"]
COPY ["src/Services/Scheduling/Scheduling.Core/Scheduling.Core.csproj", "src/Services/Scheduling/Scheduling.Core/"]
COPY ["src/Services/Scheduling/Scheduling.Infrastructure/Scheduling.Infrastructure.csproj", "src/Services/Scheduling/Scheduling.Infrastructure/"]
RUN dotnet restore "src/Services/Scheduling/Scheduling.API/Scheduling.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Scheduling/Scheduling.API"
RUN dotnet build "Scheduling.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scheduling.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scheduling.API.dll"]