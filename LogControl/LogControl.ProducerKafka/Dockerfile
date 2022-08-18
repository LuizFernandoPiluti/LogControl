#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LogControl.ProducerKafka/LogControl.ProducerKafka.csproj", "LogControl.ProducerKafka/"]
RUN dotnet restore "LogControl.ProducerKafka/LogControl.ProducerKafka.csproj"
COPY . .
WORKDIR "/src/LogControl.ProducerKafka"
RUN dotnet build "LogControl.ProducerKafka.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogControl.ProducerKafka.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogControl.ProducerKafka.dll"]