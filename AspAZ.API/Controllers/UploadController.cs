﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspAZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        //// GET: api/<UploadController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UploadController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UploadController>
        [HttpPost]
        public void Post([FromForm] UploadDto img)
        {
            var imgName = Guid.NewGuid();
            var ext = Path.GetExtension(img.ImageFile.FileName);

            var fileName = imgName + ext;

            var path = Path.Combine("wwwroot", "images", fileName);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                img.ImageFile.CopyTo(fs);
            }

        }

        //// PUT api/<UploadController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UploadController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        public class UploadDto
        {
            public IFormFile ImageFile { get; set; }
        }
    }
}
