FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PokemonSaveRead/PokemonSaveRead.csproj", "PokemonSaveRead/"]
RUN dotnet restore "PokemonSaveRead/PokemonSaveRead.csproj"
COPY . .
WORKDIR "/src/PokemonSaveRead"
RUN dotnet build "PokemonSaveRead.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PokemonSaveRead.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokemonSaveRead.dll"]
