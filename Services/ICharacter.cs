using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.models;

namespace WebApi.Services
{
    public interface ICharacter
    {
        Task<ServiceResponse<List<Character>>> getAllCharacter();
        Task<ServiceResponse<Character>> GetCharacter(int id);
        Task<ServiceResponse<List<Character>>> addCharacter(Character character);
        
    }
}