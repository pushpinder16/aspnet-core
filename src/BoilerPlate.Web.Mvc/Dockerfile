FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/BoilerPlate.Web.Mvc/BoilerPlate.Web.Mvc.csproj", "src/BoilerPlate.Web.Mvc/"]
COPY ["src/BoilerPlate.Web.Core/BoilerPlate.Web.Core.csproj", "src/BoilerPlate.Web.Core/"]
COPY ["src/BoilerPlate.Application/BoilerPlate.Application.csproj", "src/BoilerPlate.Application/"]
COPY ["src/BoilerPlate.Core/BoilerPlate.Core.csproj", "src/BoilerPlate.Core/"]
COPY ["src/BoilerPlate.EntityFrameworkCore/BoilerPlate.EntityFrameworkCore.csproj", "src/BoilerPlate.EntityFrameworkCore/"]
WORKDIR "/src/src/BoilerPlate.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BoilerPlate.Web.Mvc", "src/BoilerPlate.Web.Mvc"]
COPY ["src/BoilerPlate.Web.Core", "src/BoilerPlate.Web.Core"]
COPY ["src/BoilerPlate.Application", "src/BoilerPlate.Application"]
COPY ["src/BoilerPlate.Core", "src/BoilerPlate.Core"]
COPY ["src/BoilerPlate.EntityFrameworkCore", "src/BoilerPlate.EntityFrameworkCore"]
WORKDIR "/src/src/BoilerPlate.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BoilerPlate.Web.Mvc.dll"]
