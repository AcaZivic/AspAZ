using AspAZ.Application.DataTransfer;
using AspAZ.Application.UseCases.Queries;
using AspAZ.Application;
using AspAZ.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspAZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogs : ControllerBase
    {

        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public UseCaseLogs(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }





        // GET: api/<UseCaseLogs>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] UseCaseLogSearchDTO search,
            [FromServices] IGetUseCaseLogQuery query)
        {
            //var manufacturers = _gameContext.Manufacturers.ToList();
            return Ok(_executor.ExecuteQuery(query, search));
        }


        //// POST api/<UseCaseLogs>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UseCaseLogs>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UseCaseLogs>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
