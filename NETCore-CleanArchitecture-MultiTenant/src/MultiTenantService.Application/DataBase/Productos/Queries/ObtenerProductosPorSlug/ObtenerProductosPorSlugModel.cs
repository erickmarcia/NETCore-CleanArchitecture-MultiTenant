namespace MultiTenantService.Application.DataBase.Productos.Queries.ObtenerProductosPorSlug
{
    public class ObtenerProductosPorSlugModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int OrganizacionId { get; set; }
    }
}
