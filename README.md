# Redarbor
WebApi employees Redarbor

En la raiz del proyecto ejecutar el siguiente comando para correr la infraestructura 

```shell
docker network create redarbor-network
docker compose up -d 
```


Ingresar a la ruta Redarbor\Redarbor.InfrastructureEF 

Ejecutar el siguiente comando para correr la migración

```shell
dotnet ef database update --startup-project ..\Redarbor.API\Redarbor.Api.csproj
```

# Conectarse a la instancia de docker 

```shell
docker exec -it dbpostgresqlserver psql -U redarboruser -d RedarborDb
```
## Ejecutar estos INSERT

```shell
INSERT INTO public."Portals"("Id", "Name", "CreatedOn")
VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'Portal test', now());

INSERT INTO public."Companies"("Id", "Name", "CreatedOn")
VALUES ('a2220b31-1402-485c-bcef-904b6dec977e', 'Company test', now());

INSERT INTO public."Roles"("Id", "Name", "CreatedOn")
VALUES ('b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e', 'Administrador', now());

INSERT INTO public."Users"("Id", "Username", "Password", "LastLogin", "CreatedOn")
VALUES ('f0e69bec-6b0d-426e-8ebf-439f31e314ce', 'redarborJorge', '123465798', now(), now());
```

# Credenciales postgresql

Server=localhost
Database=RedarborDb
Port=5433
User Id=redarboruser
Password=R3d2@rb0rus3r132