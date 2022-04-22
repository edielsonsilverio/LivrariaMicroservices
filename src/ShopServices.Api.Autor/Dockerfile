#Instala a imagem do dotNet 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Copia as Dedenpencias do projeto para posteriormente ser compiladas
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Core.WebApi/Core.WebApi.csproj", "Core.WebApi/"]
COPY ["./ShopServices.Api.Autor/ShopServices.Api.Autor.csproj", "ShopServices.Api.Autor/"]




RUN dotnet restore "ShopServices.Api.Autor/ShopServices.Api.Autor.csproj"
COPY . .
WORKDIR "ShopServices.Api.Autor"
RUN dotnet build "ShopServices.Api.Autor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopServices.Api.Autor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopServices.Api.Autor.dll"]

#	(Observa��o: tem que colocar o ponto na frente do comando para dizer para copiar tudo)
#	docker build -t webapi-autor .
#	docker run --name webapi-autor -d -p 8081:80 webapi-autor