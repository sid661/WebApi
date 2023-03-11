using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.models;

namespace WebApi.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters= new List<Character>{
            new Character (),
            new Character {id=1, name="Rushikesh"}
        };

        [HttpGet("GetAll")]
        public ActionResult<Character> Get(){
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault(c=>c.id==id));
        }

        
    }
}