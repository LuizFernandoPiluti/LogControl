#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LogControl.Api/LogControl.Api.csproj", "LogControl.Api/"]
RUN dotnet restore "LogControl.Api/LogControl.Api.csproj"
COPY . .
WORKDIR "/src/LogControl.Api"
RUN dotnet build "LogControl.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogControl.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogControl.Api.dll"]