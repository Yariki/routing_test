using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    public class NoActionResult
    {
        [HttpGet]
        [Route("stringnoaction")]
        public string StringNoAction()
        {
            return "String Without ActionResult";
        }


        [HttpGet]
        [Route("simpledata")]
        public SimpleData GetSimpleData()
        {
            return new SimpleData(){Name = "Mictosoft", Year = 2019};
        }

        [HttpGet]
        [Route("simple")]
        public SimpleData GetSimple([FromBody] SimpleData data)
        {
            return new SimpleData()
            {
                Name = data.Name, Year = data.Year + 1
            };
        }
        
    }
}