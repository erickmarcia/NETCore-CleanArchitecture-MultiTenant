# Proyecto .NET CORE 8 con Clean Arquitect y CQRS.

1. Clean Arquitect
2. CQRS
3. Soporte Multitenant (middleware TenantMiddleware)
4. Configuración para 2 Bases de Datos dependiendo del Multitenant
5. Configuracion para manejar los siguientes gestores de base de datos SQLServer, PostgreSQL y MySQL (Por defecto MySQL)
6. Migracion a Base de Datos
7. Consultas con Entity Framework
8. Soporte para JWT

# Notas
## Para probar el Multitenant en productos
tenantSlug = Nombre de la organización
https://localhost:5101/Organizacion1/producto

## Para ejecutar las migraciones 
En appsettings.json configurar las conexiones a base de datos para el gestor MySQL
   "OrgDb": "server=localhost;port=3306;database=OrgDb;user=root;password=;",
   "ProductDb": "server=localhost;port=3306;database=OrgDb;user=root;password=;"

En la consola de Administracion de paquetes de Visual Ubicarse en MultiTenantService.Persistence y ejecutar los siguiente comandos
Update-DataBase -Context ProductoDbContext
Update-DataBase -Context OrgDbContext
