#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]

# https://www.programmingwithwolfgang.com/restore-nuget-inside-docker/
ARG PAT="MissingPAT"
RUN sed -i "s|</configuration>|<packageSourceCredentials><iCert><add key=\"Username\" value=\"PAT\" /><add key=\"ClearTextPassword\" value=\"${PAT}\" /></iCert></packageSourceCredentials></configuration>|" nuget.config

RUN dotnet restore "src/Application/Application.csproj"

COPY . .

WORKDIR "/src/src/Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDDTemplate.Application.dll"]
