using AspAZ.DataAccess;
using AspAZ.Domain;
using AspAZ.API;
using Microsoft.AspNetCore.Mvc;
using AspAZ.DataTransfer;
using AspAZ.API.Core;
using AspAZ.Implementation;
using AspAZ.Application.DataTransfer;
using AspAZ.Application.UseCases.Queries;
using AspAZ.Application;
using AspAZ.Application.UseCases.Commands;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspAZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;
        

        public ProductsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<ManufacturerController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] ProductSearchDTO search,
            [FromServices] IGetProductQuery query)
        {
            //var manufacturers = _gameContext.Manufacturers.ToList();
            return Ok(_executor.ExecuteQuery(query,search));
        }



        // POST api/<ManufacturerController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDTO dto, [FromServices] ICreateProductCommand command)
        {


            _executor.ExecuteCommand(command, dto); 

            return StatusCode(StatusCodes.Status201Created);


            }

        //// PUT api/<ManufacturerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductDTO dto, [FromServices] IUpdateProductCommand command)
        {

            dto.Id = id;

            _executor.ExecuteCommand(command, dto);

            return NoContent();







        }

        //// DELETE api/<ManufacturerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {

            _executor.ExecuteCommand(command, id);
            return NoContent();


        }
    }
}
