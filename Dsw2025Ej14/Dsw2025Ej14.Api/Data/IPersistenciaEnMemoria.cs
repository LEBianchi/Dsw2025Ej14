using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Data
{
    public interface IPersistenciaEnMemoria
    {
        Product? GetProduct(string sku);
        IEnumerable<Product> GetProducts();
    }
}