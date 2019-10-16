#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Tavisca.tripster.HotelApi.contracts/Tavisca.tripster.HotelApi.contracts.csproj", "Tavisca.tripster.HotelApi.contracts/"]
RUN dotnet restore "Tavisca.tripster.HotelApi.contracts/Tavisca.tripster.HotelApi.contracts.csproj"
COPY . .
WORKDIR "/src/Tavisca.tripster.HotelApi.contracts"
RUN dotnet build "Tavisca.tripster.HotelApi.contracts.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tavisca.tripster.HotelApi.contracts.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tavisca.tripster.HotelApi.contracts.dll"]