using AspAZ.DataAccess;
using AspAZ.Domain;
using AspAZ.API;
using Microsoft.AspNetCore.Mvc;
using AspAZ.DataTransfer;
using AspAZ.API.Core;
using AspAZ.Implementation;
using AspAZ.Application.DataTransfer;
using AspAZ.Application.UseCases.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspAZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {

        private UseCaseHandler _handler;

        public ManufacturersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<ManufacturerController>
        [HttpGet]
        public IActionResult Get()
        {
            //var manufacturers = _gameContext.Manufacturers.ToList();
            return Ok();
        }

        //// GET api/<ManufacturerController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var manufacturer = _gameContext.Manufacturers.FirstOrDefault(x => x.Id == id);

        //    if (manufacturer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(manufacturer);
        //}

        //public IActionResult Get([FromQuery] ManufacturerSearchDTO search, [FromServices] IGetManufacturerQuery query)
        //   => Ok(_handler.HandleQuery(query, search));

        // POST api/<ManufacturerController>
        //[HttpPost]
        //public IActionResult Post([FromBody] ManufacturerDTO dto)
        //{

        //    var manufacturer = new Manufacturer
        //    {
        //        Name = dto.Name,
        //        Description = dto.Description,
        //    };

        //    _gameContext.Manufacturers.Add(manufacturer);


        //    try
        //    {
        //        _gameContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }


        //    return StatusCode(StatusCodes.Status201Created);




        //}

        //// PUT api/<ManufacturerController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] ManufacturerUpdateDTO dto)
        //{

        //    var manufacturer = _gameContext.Manufacturers.FirstOrDefault(x => x.Id == id);

        //    if (manufacturer == null)
        //    {
        //        return NotFound();
        //    }

        //    if (dto.Description == null)
        //    {
        //        return BadRequest();

        //    }

        //    manufacturer.Description = dto.Description;

        //    try
        //    {
        //        manufacturer.ModifiedAt = DateTime.UtcNow;
        //        _gameContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return NoContent();







        //}

        //// DELETE api/<ManufacturerController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var manufacturer = _gameContext.Manufacturers.FirstOrDefault(x => x.Id == id);

        //    if (manufacturer == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        var products = _gameContext.Products.Where(x => x.ManufacturerId == id).Count();
        //        if (products > 0)
        //        {
        //            manufacturer.IsDeleted = true;
        //            manufacturer.isActive = false;
        //            manufacturer.DeletedAt = DateTime.UtcNow;
        //        }
        //        else
        //        {
        //            _gameContext.Manufacturers.Remove(manufacturer);
        //        }
        //        _gameContext.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return NoContent();


        //}
    }
}
