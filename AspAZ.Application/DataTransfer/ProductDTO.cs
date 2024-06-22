using AspAZ.Application.DataTransfer;
using AspAZ.Domain;

namespace AspAZ.DataTransfer
{
    public class ProductDTO 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public int PriceListId { get; set; }
        public double Price { get; set; }

        public IEnumerable<ProductPropertyDTO> Properties { get; set; }


    }

    



}
