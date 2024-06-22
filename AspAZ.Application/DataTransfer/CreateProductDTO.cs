using AspAZ.Domain;

namespace AspAZ.DataTransfer
{
    public class CreateProductDTO 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int PriceListId { get; set; }

        public IEnumerable<ProductPropertyDTO> Properties { get; set; }


    }

    

        public class ProductPropertyDTO
    {
        public int PropertyId { get; set; }
        public string Value { get; set; }
    }

    public class UpdateProductDTO : CreateProductDTO
    {
        public int Id { get; set; }
    }
}
