
using System.Text.Json.Serialization;
namespace WebApi.models
{   [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        knight =1,
        maze =2,
        cleric =3
    }
}