FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["SportsFinder/SportsFinder.csproj", "SportsFinder/"]
RUN dotnet restore "SportsFinder/SportsFinder.csproj"
COPY . .
WORKDIR "/src/SportsFinder"
RUN dotnet build "SportsFinder.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SportsFinder.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SportsFinder.dll"]
