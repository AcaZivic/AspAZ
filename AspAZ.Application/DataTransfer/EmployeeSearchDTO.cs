using AspAZ.Application.DataTransfer;

namespace AspAZ.DataTransfer
{
    public class EmployeeSearchDTO : PagedSearch
    {
        public int? Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? GroupEmpId { get; set; }
        public bool? HasChlidren { get; set; }

    }
}
