// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AspAZ.DataTransfer;
using System.Collections.Generic;

namespace AspYt.Application.DTO
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public List<int>? ChildIds { get; set; }
        public List<int>? Properties { get; set; }

    }




    public class CategoryDto : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public IEnumerable<CategoryDto> Children { get; set; }
        public IEnumerable<CategoryPropertyDto> Properties { get; set; }

    }
    public class CategoryPropertyDto
    {
        public int PropertyId { get; set; }

    }
    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
    }
}
