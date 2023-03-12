using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Dtos.characters;
using WebApi.models;

namespace WebApi.Services
{
    public class CharacterService : ICharacter
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {id=1, name="Rushikesh"}
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> addCharacter(AddCharacterDto character)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character1 = _mapper.Map<Character>(character);
            character1.id = characters.Max(c => c.id) + 1;
            characters.Add(character1);
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacter()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.id == id);
            // if (character != null)
            // {
            //     return character;
            // }
            // throw new Exception("character not found in list");
            ServiceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto updatedcharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = characters.FirstOrDefault(c => c.id == updatedcharacter.id);
                if(character is null){
                    throw new Exception($"Character with id '{updatedcharacter.id}' is not found");
                }
                character.name = updatedcharacter.name;
                character.hitPoints = updatedcharacter.hitPoints;
                character.strength = updatedcharacter.strength;
                character.defence = updatedcharacter.defence;
                character.intelligence = updatedcharacter.intelligence;
                character.Class = updatedcharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
               serviceResponse.sucess=false;
               serviceResponse.message=ex.Message;
            }

            return serviceResponse;
        }
    }
}