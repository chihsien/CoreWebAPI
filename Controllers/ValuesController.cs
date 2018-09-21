using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBreedService _BreedService;

        public ValuesController(IBreedService BreedService )
        {
            _BreedService = BreedService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {         
            return new string[] { "value1", "value2" };         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Breed r =  _BreedService.Get(id);          
            return r.Name;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
