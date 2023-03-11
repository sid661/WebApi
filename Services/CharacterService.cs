using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.models;

namespace WebApi.Services
{
    public class CharacterService : ICharacter
    {     private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {id=1, name="Rushikesh"}
        };
       
        public async Task<ServiceResponse<List<Character>>> addCharacter(Character character)
        {
             characters.Add(character);
             return characters;
        }

        public async Task<ServiceResponse<List<Character>>> getAllCharacter()
        {
             return characters;
        }

        public async Task<ServiceResponse<Character>> GetCharacter(int id)
        {   var character = characters.FirstOrDefault(c=> c.id== id);
        if(character!=null){
            return character;
        }
           throw new Exception("character not found");
        }
    }
}