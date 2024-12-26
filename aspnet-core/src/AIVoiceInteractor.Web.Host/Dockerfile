FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/AIVoiceInteractor.Web.Host/AIVoiceInteractor.Web.Host.csproj", "src/AIVoiceInteractor.Web.Host/"]
COPY ["src/AIVoiceInteractor.Web.Core/AIVoiceInteractor.Web.Core.csproj", "src/AIVoiceInteractor.Web.Core/"]
COPY ["src/AIVoiceInteractor.Application/AIVoiceInteractor.Application.csproj", "src/AIVoiceInteractor.Application/"]
COPY ["src/AIVoiceInteractor.Core/AIVoiceInteractor.Core.csproj", "src/AIVoiceInteractor.Core/"]
COPY ["src/AIVoiceInteractor.EntityFrameworkCore/AIVoiceInteractor.EntityFrameworkCore.csproj", "src/AIVoiceInteractor.EntityFrameworkCore/"]
WORKDIR "/src/src/AIVoiceInteractor.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AIVoiceInteractor.Web.Host", "src/AIVoiceInteractor.Web.Host"]
COPY ["src/AIVoiceInteractor.Web.Core", "src/AIVoiceInteractor.Web.Core"]
COPY ["src/AIVoiceInteractor.Application", "src/AIVoiceInteractor.Application"]
COPY ["src/AIVoiceInteractor.Core", "src/AIVoiceInteractor.Core"]
COPY ["src/AIVoiceInteractor.EntityFrameworkCore", "src/AIVoiceInteractor.EntityFrameworkCore"]
WORKDIR "/src/src/AIVoiceInteractor.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AIVoiceInteractor.Web.Host.dll"]
