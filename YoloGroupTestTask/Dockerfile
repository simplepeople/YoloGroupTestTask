FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YoloGroupTestTask/YoloGroupTestTask.csproj", "YoloGroupTestTask/"]
RUN dotnet restore "YoloGroupTestTask/YoloGroupTestTask.csproj"
COPY . .
WORKDIR "/src/YoloGroupTestTask"
RUN dotnet build "YoloGroupTestTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YoloGroupTestTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YoloGroupTestTask.dll"]
