using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiRouting.Controllers
{
    [ApiController]
    public class ValuesController //: ControllerBase
    {

        private string[] data = {"value1", "valuee2"};
        
        // GET api/values
        [Route("get")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return data;
        }

        [Route("get/{id}")]
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id >= data.Length)
            {
                return "The id is not valid";
            }
            return data[id];
        }
        
        [Authorize]
        [HttpGet("{id}")]
        [Route("auth/{id}")]
        public IActionResult GetA(int id)
        {
            return new ObjectResult($"Auth {id}");
        }
        

    }
}