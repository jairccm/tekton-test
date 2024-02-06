# tekton-test
# Proyecto tekton-test

Este proyecto utiliza ASP.NET Core y Entity Framework Core para realizar un mantenimiento de un producto.

## Configuración de la Cadena de Conexión

La cadena de conexión a la base de datos debe configurarse en el archivo `appsettings.json`. Abre este archivo y encuentra la sección `ConnectionStrings`, luego ajusta la cadena de conexión según sea necesario:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BDTest;User ID=sa;Password=xxxx;TrustServerCertificate=True"
  },

}
```

## Migraciones y Actualización de la Base de Datos

#Abre la consola de NuGet Package Manager

# Asegúrate de estar posicionado en el proyecto de infraestructura
cPrueba.Tekton.Infraestructure


# Aplicar migraciones a la base de datos
Update-Database

##Ejecutar proyecto Api:
Prueba.Tekton.Api


## los logs se alamcenan dentro del proyecto en la ruta:
Prueba.Tekton.Api/log/