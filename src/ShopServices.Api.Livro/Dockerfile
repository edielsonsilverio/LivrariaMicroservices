#Instala a imagem do dotNet 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Copia as Dedenpencias do projeto para posteriormente ser compiladas
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Core.WebApi/Core.WebApi.csproj", "Core.WebApi.csproj/"]
COPY ["./ShopServices.Api.Livro/ShopServices.Api.Livro.csproj", "ShopServices.Api.Livro/"]

RUN dotnet restore "ShopServices.Api.Livro/ShopServices.Api.Livro.csproj"
COPY . .
WORKDIR "ShopServices.Api.Livro"
RUN dotnet build "ShopServices.Api.Livro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopServices.Api.Livro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopServices.Api.Livro.dll"]

#	(Observa��o: tem que colocar o ponto na frente do comando para dizer para copiar tudo)
#	docker build -t webapi-livro .
#	docker run --name webapi-livro -d -p 8080:80 webapi-livro