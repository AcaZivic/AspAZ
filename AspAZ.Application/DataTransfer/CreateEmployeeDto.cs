// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AspAZ.DataTransfer;
using AspAZ.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AspYt.Application.DTO
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? ParentId { get; set; }
        public int GroupEmpId { get; set; }

        public List<int>? ChildIds { get; set; }
        public List<int>? UseCases { get; set; }


    }




    public class EmployeeDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
        public int GroupEmpId { get; set; }

        public string? ParentName { get; set; }
        public int ParentId { get; set; }
        
        public IEnumerable<EmployeeDTO> Children { get; set; }
        



    }

    public class UpdateEmployeeDto : CreateEmployeeDto
    {
        public int Id { get; set; }
    }

}
