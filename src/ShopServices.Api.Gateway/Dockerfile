#Instala a imagem do dotNet 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Copia as Dedenpencias do projeto para posteriormente ser compiladas
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#COPY *.csproj ./src
COPY ["./Core.WebApi/Core.WebApi.csproj", "Core.WebApi/"]
COPY ["./ShopServices.Api.Gateway/ShopServices.Api.Gateway.csproj", "ShopServices.Api.Gateway/"]

RUN dotnet restore "ShopServices.Api.Gateway/ShopServices.Api.Gateway.csproj"
COPY . .
WORKDIR "ShopServices.Api.Gateway"
RUN dotnet build "ShopServices.Api.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopServices.Api.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopServices.Api.Gateway.dll"]

#	(Observa��o: tem que colocar o ponto na frente do comando para dizer para copiar tudo)
#	docker build -t webapi-Gateway .
#	docker run --name webapi-Gateway -d -p 8082:80 webapi-Gateway
#	docker build -f ./ShopServices.Api.Gateway/Dockerfile --force -rm -t .
#	docker build   -f ShopServices.Api.Gateway/Dockerfile .