using System.Text.Json;
using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria : IPersistenciaEnMemoria
    {
        private List<Product> _products = [];
        private bool _cargando = false;


        public PersistenciaEnMemoria()
        {
            LoadProducts();
        }

        public Product? GetProduct(string sku)
        {
           return _products.FirstOrDefault(p => p.Sku == sku);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products.Where(p => p.IsActive);
        }
        public void LoadProducts()
        {
            var json = File.ReadAllText("products.json");
            var productos = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true, }
            ) ?? [];
            _products = productos;
        }
    }
}
