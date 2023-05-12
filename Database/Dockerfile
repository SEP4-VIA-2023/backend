FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /src
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Database.sln ./
COPY DataAccess/*.csproj ./DataAccess/
COPY gRPC/*.csproj ./gRPC/
COPY GrpcService/*.csproj ./GrpcService/

RUN dotnet restore
COPY . .

WORKDIR /src/DataAccess
RUN dotnet build -c Release -o /app

WORKDIR /src/GrpcService
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GrpcService.dll"]