using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.models;

namespace WebApi.Dtos.characters
{
    public class UpdateCharacterDto
    {
        public int id { get; set; }
        public string name { get; set; } = "sidharth";

        public int hitPoints { get; set; }=100;
        public int strength { get; set; }=10;
        public int defence { get; set; }=10;
        public int intelligence { get; set; }=10;
        public RpgClass Class{ get; set; } = RpgClass.knight;
    }
}