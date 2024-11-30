FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CapitalGain/CapitalGain.csproj", "CapitalGain/"]
RUN dotnet restore "CapitalGain/CapitalGain.csproj"
COPY . .
WORKDIR "/src/CapitalGain"
RUN dotnet build "CapitalGain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CapitalGain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CapitalGain.dll"]