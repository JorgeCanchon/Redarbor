# Redarbor
WebApi employees Redarbor

1. Luego de clonar el proyecto, abrimos un CLI con la ruta raiz del proyecto y ejecutamos el siguiente comando para correr la infraestructura:

```shell
docker compose up -d 
```
<img width="1328" height="225" alt="image" src="https://github.com/user-attachments/assets/5122f23d-b4e4-43e8-afd7-39c426bf769c" />

<img width="2610" height="614" alt="image" src="https://github.com/user-attachments/assets/cfddac28-21e9-41f8-817b-f2a6f3d74827" />

2.  Luego ejecutamos la migracion para crear nuestra DB, vamos a la ruta **Redarbor\Redarbor.InfrastructureEF**, y,
ejecutamos el siguiente comando para correr la migración:

```shell
dotnet ef database update --startup-project ..\Redarbor.API\Redarbor.Api.csproj
```
<img width="2156" height="119" alt="image" src="https://github.com/user-attachments/assets/1c656f74-2bd4-45c9-978a-39b0cfc7c539" />


# Conectarse a la instancia de docker 

3. En la misma consola o CLI ejecutamos este comando para conectarnos a la instancia de postgresql

```shell
docker exec -it dbpostgresqlserver psql -U redarboruser -d RedarborDb
```
<img width="993" height="66" alt="image" src="https://github.com/user-attachments/assets/73bbc700-1faa-4a9e-9931-4e16d4f97531" />

4. Una vez conectados verificamos que se hayan creado las tablas 

```shell
\dt
```
<img width="850" height="377" alt="image" src="https://github.com/user-attachments/assets/a4bd7146-9eda-45e8-866d-61d3d1ddb9b0" />

5. Validamos que las tablas tengas los datos iniciales

```shell
SELECT * FROM "Roles";
```
<img width="1496" height="217" alt="image" src="https://github.com/user-attachments/assets/30749018-3e89-484f-a1c5-53977792767d" />

# Validar API

6. Para validar que nuestro API esta corriendo vamos a esta [URL](http://localhost:5250/swagger/index.html)
<img width="2599" height="1449" alt="image" src="https://github.com/user-attachments/assets/b40c6358-a998-447d-84c5-a59cab66f6e8" />

# Pruebas en Postman
7. En la raiz del proyecto se encuentra una coleccion de postman llamada **Redarbor.postman_collection.json** la cual importaremos y ejecutaremos.
<img width="1811" height="847" alt="image" src="https://github.com/user-attachments/assets/901cd996-97d1-4161-837d-e376546d6847" />

# Test de integracion

