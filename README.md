# Redarbor
WebApi employees Redarbor


docker network create redarbor-network
docker compose up -d 


dotnet ef --startup-project ../Redarbor.API/ database update


dotnet ef migrations add "Inicial" --startup-project ..\Redarbor.API\Redarbor.Api.csproj

Ingresar a la ruta Redarbor\Redarbor.InfrastructureEF 

Ejecutar el siguiente comando para correr la migración

dotnet ef database update --startup-project ..\Redarbor.API\Redarbor.Api.csproj

ConnectionString="Server=dbpostgresqlserver;Database=RedarborDb;Port=5432;User Id=redarboruser;Password=R3d2@rb0rus3r132*!"