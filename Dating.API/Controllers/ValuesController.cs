using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dating.API.Models;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dating.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        //When you have multiple parameter in constructor it does not mean you have to define multiple constructors
        //just sort out with this method
        //you have DataContext and Logger
        private readonly DataContext _context;
        private readonly ILogger<ValuesController> _logger;

        //Summerize both constructor within one
        public ValuesController(DataContext context,ILogger<ValuesController> logger)
        {
            _context = context;
             _logger = logger;

        }

//Now you can remove thiss empty constructor
        // public ValuesController()
        // {
           
        // }

        [HttpGet]
        public async Task<IActionResult> GetValues()
       // public List<Value> Get()
        {
            var values =await _context.Values.ToListAsync();
            return Ok(values);
           // Value value = new Value();
            //value.Id = 1;
            //value.Name = "Fahad";

            //List<Value> values = new List<Value>();
            //values.Add(value);

            //return values;

        }
         [HttpGet("{id}")]
         public async Task<IActionResult> GetValues(int id)
         {
             var value =await _context.Values.FirstOrDefaultAsync(x =>x.Id == id);
             return Ok(value);//yaha pay usny value likha hai but ma likhu to error
         }
        
    }
}
