using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos.characters;
using WebApi.models;

namespace WebApi.Services
{
    public interface ICharacter
    {
        Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> addCharacter(AddCharacterDto characterDto);
        Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto characterDto);
        Task<ServiceResponse<List<GetCharacterDto>>> deleteCharacter(int id);
    }
}