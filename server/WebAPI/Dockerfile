FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY . WebAPI
COPY ["WebAPI.csproj", "WebAPI/"]
RUN dotnet restore "WebAPI/WebAPI.csproj"

#ENTRYPOINT ["entrypoint.sh"]
WORKDIR /src/WebAPI/
RUN dotnet build "WebAPI.csproj" -c Release -o /app

FROM build AS publish
COPY --from=build /src/WebAPI/ .
#RUN chmod +x ./entrypoint.sh
#CMD /entrypoint.sh
RUN dotnet publish "WebAPI.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
