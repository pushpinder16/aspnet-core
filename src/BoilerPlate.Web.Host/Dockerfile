FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BoilerPlate.Web.Host/BoilerPlate.Web.Host.csproj", "src/BoilerPlate.Web.Host/"]
COPY ["src/BoilerPlate.Web.Core/BoilerPlate.Web.Core.csproj", "src/BoilerPlate.Web.Core/"]
COPY ["src/BoilerPlate.Application/BoilerPlate.Application.csproj", "src/BoilerPlate.Application/"]
COPY ["src/BoilerPlate.Core/BoilerPlate.Core.csproj", "src/BoilerPlate.Core/"]
COPY ["src/BoilerPlate.EntityFrameworkCore/BoilerPlate.EntityFrameworkCore.csproj", "src/BoilerPlate.EntityFrameworkCore/"]
WORKDIR "/src/src/BoilerPlate.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BoilerPlate.Web.Host", "src/BoilerPlate.Web.Host"]
COPY ["src/BoilerPlate.Web.Core", "src/BoilerPlate.Web.Core"]
COPY ["src/BoilerPlate.Application", "src/BoilerPlate.Application"]
COPY ["src/BoilerPlate.Core", "src/BoilerPlate.Core"]
COPY ["src/BoilerPlate.EntityFrameworkCore", "src/BoilerPlate.EntityFrameworkCore"]
WORKDIR "/src/src/BoilerPlate.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BoilerPlate.Web.Host.dll"]
