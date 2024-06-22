using AspAZ.Application.DataTransfer;

namespace AspAZ.DataTransfer
{
    public class CreateCustomerDTO  
    {
        public string? Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public int? TaxID { get; set; }
    }

    public class CustomerDTO
    {
       public string? Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public int? TaxID { get; set; }
    }
    public class CustomerSearchDTO : PagedSearch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public int? TaxID { get; set; }
    }
}
