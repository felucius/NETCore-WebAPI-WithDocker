FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NETCore-WebAPI-WithDocker.csproj", "./"]
RUN dotnet restore "NETCore-WebAPI-WithDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NETCore-WebAPI-WithDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NETCore-WebAPI-WithDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NETCore-WebAPI-WithDocker.dll"]
