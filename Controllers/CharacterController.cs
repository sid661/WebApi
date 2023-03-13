using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.characters;
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
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get()
        {
            return Ok(await _characterService.getAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {    
            return Ok(await _characterService.GetCharacter(id));
        }
        [HttpPost("addCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> addCharacter(AddCharacterDto character)
        {   
            
             return Ok(await _characterService.addCharacter(character));
        }

        [HttpPut("updateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> updateCharacter(UpdateCharacterDto updatedcharacter)
        {   
            var ServiceResponse =await _characterService.updateCharacter(updatedcharacter);
            if(ServiceResponse.Data is null){
                return NotFound(ServiceResponse);
            }

             return Ok(ServiceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> deleteCharacter(int id)
        {    
             var ServiceResponse =await _characterService.deleteCharacter(id);
            if(ServiceResponse.Data is null){
                return NotFound(ServiceResponse);
            }

             return Ok(ServiceResponse);
        }
    }
}