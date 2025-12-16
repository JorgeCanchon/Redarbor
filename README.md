# Redarbor
WebApi employees Redarbor

1. Luego de clonar el proyecto, abrimos un CLI con la ruta raiz del proyecto y ejecutamos el siguiente comando para correr la infraestructura:

```shell
docker compose up -d 
```


2.  Luego ejecutamos la migracion para crear nuestra DB, vamos a la ruta **Redarbor\Redarbor.InfrastructureEF**, y,
ejecutamos el siguiente comando para correr la migración:

```shell
dotnet ef database update --startup-project ..\Redarbor.API\Redarbor.Api.csproj
```

# Conectarse a la instancia de docker 

En la misma consola o CLI ejecutamos este comando para conectarnos a la instancia de postgresql

```shell
docker exec -it dbpostgresqlserver psql -U redarboruser -d RedarborDb
```
Una vez conectados verificamos que se hayan creado las tablas 

```shell
\dt
```

Validamos que las tablas tengas los datos iniciales

```shell
SELECT * FROM "Roles";
```

# Validar API

Para validar que nuestro API esta corriendo vamos a esta [URL](http://localhost:5250/swagger/index.html)

# Pruebas en Postman
En la raiz del proyecto se encuentra una coleccion de postman llamada **Redarbor.postman_collection.json** la cual importaremos y ejecutaremos.

# Test de integracion

