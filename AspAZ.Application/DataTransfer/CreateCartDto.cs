// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AspAZ.DataTransfer;
using AspAZ.Domain;
using System.Collections.Generic;

namespace AspYt.Application.DTO
{
    public class CreateCartDto
    {
        public int RetailShopId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? dateRealization { get; set; }
        public virtual IEnumerable<ProductCartDto> ProductCarts { get; set; } = new HashSet<ProductCartDto>();

    }




    public class ProductCartDto
    {
        public int ProductId{ get; set; }
        public int Quantity {  get; set; }



    }

    public class UpdateCartDto : CreateCartDto
    {
        public int Id { get; set; }
    }
}
