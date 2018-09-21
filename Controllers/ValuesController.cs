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
        public IEnumerable<Breed> Get()
        {         
            List<Breed> r = _BreedService.Get();
            return r.AsEnumerable();
            // return new string[] { "value1", "value2" };         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Breed Get(int id)
        {
            Breed r =  _BreedService.Get(id);       
            // if (r == null) return ""; 
            // return r.Name;
            return r;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromForm]Breed u)
        {
            Breed r = new Breed(){
                Name = u.Name
            };
            _BreedService.Add(r);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm]Breed u)
        {
            Breed r = new Breed(){
                BreedId = id,
                Name = u.Name
            };
            _BreedService.Edit(r);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _BreedService.Delete(id);
        }

        // [Route("test1")]
        // public string test1()
        // {
        //     return "tttt";
        // }
    }
}
