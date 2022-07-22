FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestProj/TestProj.csproj", "TestProj/"]
RUN dotnet restore "TestProj/TestProj.csproj"
COPY . .
WORKDIR "/src/TestProj"
RUN dotnet build "TestProj.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestProj.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestProj.dll"]
