# ApiNet7LokiGrafana

# Documentación de desarrollo para Web API de .NET 7

Esta Web API de .NET 7 es una prueba de concepto que utiliza las óltimas tecnologías para grabar logs en Grafana Loki a travós de Serilog.

## Tecnologías utilizadas

- .NET 7

- Serilog

- Grafana Loki

## Requisitos previos

- .NET 7 SDK

- Grafana Loki

- VS 2022 ya posee todos los requisitos

## Paquetes:

```
* PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjectionFixed" Version="5.1.2"

```

```
* PackageReference Include="Serilog.Sinks.Grafana.Loki" Version="8.1.0"

```

```
* PackageReference Include="Serilog.Sinks.Http" Version="8.0.0"

```

```
* PackageReference Include="FluentValidation" Version="11.5.1"

```

````
* PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0"

```w

## Configuración del entorno

1. Descargar e instalar el .NET 7 SDK.

2. Descargar e instalar Grafana Loki.

3. Configurar la conexión con Grafana Loki en la aplicación a travós de la configuración de Serilog.

## Instalación y Descarga

1. Clonar o descargar el repositorio de la aplicación.

- Selecciona cualquiera de las dos opciones:

  1.1 - Ir a la siguiente dirección: http://gitlab.gyfcloud.com.ar/architecture/poc/loki-grafana

y presionar el boton CODE la opcion Download ZIP.

1.2.- Ir a la Terminal de comando y ejecutar este comando:

git clone http://gitlab.gyfcloud.com.ar/architecture/poc/loki-grafana.git

Instalación y ejecución

2.- Ir a la carpeta donde se desplegó la solución a este archivo ---→ … \ApiSystemCQRS Abrir una terminal de comando.

3.- En la terminal de comando donde se desplego la app ejecutar:

3.1.- dotnet restore

4.- En la terminal de comando donde se desplego la app ejecutar:

4.1.- dotnet publish -c Release -o apinet7Output

5.- En la terminal de comando donde se desplego la app ejecutar:

5.1.- dotnet apinet7Output/ApiSystemCQRS

## Estructura del proyecto

El proyecto sigue la estructura convencional de una aplicación de .NET 7. Las carpetas principales son: Controllers, Models, Services, y Properties.

El proyecto es desarrollado Asp Net 7 Api Restful con un crud sin base de datos, mantiene los datos mientras la Api este Online.

## Base de datos

No se utiliza una base de datos en la aplicación.

## Endpoints

La API tiene los siguientes endpoints:

- GET http://localhost:9000/api/Gyf/

- GET http://localhost:9000/api/Gyf/id?id=4

- POST http://localhost:9000/api/Gyf/

          {

          "nombre": "Sistema de Prueba",

          "descripcion": "Sistema desde postman",

          "usuario": "LOYS",

          "tipoLicencia": "anual"

          }

- PUT http://localhost:9000/api/Gyf/

          {

          "Id":5,

          "nombre": "Sistema de Prueba",

          "descripcion": "Sistema desde postman",

          "usuario": "LOYS",

          "tipoLicencia": "anual"

          }

- DELETE http://localhost:9000/api/Gyf/1

## Autenticación y autorización

No se implementa autenticación o autorización en la aplicación.

## Mejoras futuras

Algunas mejoras futuras que se desean implementar son: añadir autenticación y autorización, implementar pruebas de rendimiento, agregar base de datos y agregar más endpoints.

## Contribución

Si deseas contribuir al proyecto, puedes hacer un fork del repositorio, hacer tus cambios y enviar una solicitud de cambios.

## Licencia

La aplicación utiliza la licencia MIT.

## Contacto

Puedes contactar al equipo de desarrollo a través del correo electrónico lramirez@gyf.com.ar
````
