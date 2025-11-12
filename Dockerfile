FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY BackendLab3.Api/*.csproj ./BackendLab3.Api/
COPY BackendLab3.Services/*.csproj ./BackendLab3.Services/
COPY BackendLab3.DataAccess/*.csproj ./BackendLab3.DataAccess/

RUN dotnet restore BackendLab3.Api/BackendLab3.Api.csproj

COPY . .

RUN dotnet publish BackendLab3.Api/BackendLab3.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "BackendLab3.Api.dll"]
