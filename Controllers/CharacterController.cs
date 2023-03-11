using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        
        private ICharacter _characterService;
public CharacterController(ICharacter CharacterService)
{
    _characterService=CharacterService;
}
        [HttpGet("GetAll")]
        public async Task< ActionResult<Character>> Get()
        {
            return Ok(await _characterService.getAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id)
        {    
            return Ok(await _characterService.GetCharacter(id));
        }
        [HttpPost("addCharacter")]
        public async Task<ActionResult<List<Character>>> addCharacter(Character character)
        {   
            
             return Ok(await _characterService.addCharacter(character));
        }
    }
}