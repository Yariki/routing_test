using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    public class NumbersController //: ControllerBase
    {
        private int[] data = {1,4,78,9,5,3,34,6,8,556,98};


        [HttpGet]
        [Route("all")]
        public IActionResult GetNumbers()
        {
            return new ObjectResult(data);
        }
        
        [HttpGet]
        [Route("number/{index}")]
        public IActionResult GetNumber(int index)
        {
            if (index >= data.Length)
            {
                return new BadRequestResult();
            }
            return new ObjectResult(data[index]);
        }
        
    }
}