using System.Runtime.Serialization;

namespace CatalogApi.Dtos
{
    public class ProductDto
    {
        public string SkuCode { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
