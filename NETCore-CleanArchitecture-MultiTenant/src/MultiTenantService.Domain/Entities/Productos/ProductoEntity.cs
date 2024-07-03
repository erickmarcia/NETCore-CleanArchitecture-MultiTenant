namespace MultiTenantService.Domain.Entities.Producto
{
	public class ProductoEntity
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public int OrganizacionId { get; set; }
	}
}

