using AspAZ.Application.DataTransfer;

namespace AspAZ.DataTransfer
{
    public class CategorySearchDTO : PagedSearch
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public bool? HasChlidren { get; set; }

    }
}
