FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY BBC.Test.PushBullet.sln ./
COPY BBC.Test.PushBullet/BBC.Test.PushBullet.csproj BBC.Test.PushBullet/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/BBC.Test.PushBullet
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BBC.Test.PushBullet.dll"]
