# Use the official image from Microsoft
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Shitmaps/Shitmaps.csproj", "Shitmaps/"]
RUN dotnet restore "Shitmaps/Shitmaps.csproj"
COPY . .
WORKDIR "/src/Shitmaps"
RUN dotnet build "Shitmaps.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shitmaps.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
