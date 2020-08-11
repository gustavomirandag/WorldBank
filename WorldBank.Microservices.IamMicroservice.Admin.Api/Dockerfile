#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/WorldBank.Microservices.IamMicroservice.Admin.Api/WorldBank.Microservices.IamMicroservice.Admin.Api.csproj", "src/WorldBank.Microservices.IamMicroservice.Admin.Api/"]
COPY ["src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.Shared/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.Shared.csproj", "src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.Shared/"]
COPY ["src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer.csproj", "src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/"]
COPY ["src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL.csproj", "src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/WorldBank.Microservices.IamMicroservice.Shared/WorldBank.Microservices.IamMicroservice.Shared.csproj", "src/WorldBank.Microservices.IamMicroservice.Shared/"]
COPY ["src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.MySql/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.MySql.csproj", "src/WorldBank.Microservices.IamMicroservice.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/WorldBank.Microservices.IamMicroservice.Admin.Api/WorldBank.Microservices.IamMicroservice.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/WorldBank.Microservices.IamMicroservice.Admin.Api"
RUN dotnet build "WorldBank.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorldBank.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "WorldBank.Microservices.IamMicroservice.Admin.Api.dll"]