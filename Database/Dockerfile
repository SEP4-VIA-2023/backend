FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /src
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Database.sln ./
COPY EFCDataAccess/*.csproj ./EFCDataAccess/
COPY Logic/*.csproj ./Logic/
COPY Model/*.csproj ./Model/
COPY WebSockets/*.csproj ./WebSockets/
COPY ServerTest/*.csproj ./ServerTest/
COPY APIs/*.csproj ./APIs/

RUN dotnet restore
COPY . .

WORKDIR /src/EFCDataAccess
RUN dotnet build -c Release -o /app

WORKDIR /src/Logic
RUN dotnet build -c Release -o /app

WORKDIR /src/Model
RUN dotnet build -c Release -o /app

WORKDIR /src/WebSockets
RUN dotnet build -c Release -o /app

WORKDIR /src/ServerTest
RUN dotnet build -c Release -o /app

WORKDIR /src/APIs
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "APIs.dll"]