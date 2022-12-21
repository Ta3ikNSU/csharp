using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace lab5.DTO;

[SwaggerSchema("Pair of Contenders")]
public class PairContenderNameDTO
{
    [JsonPropertyName("name1")]
    public string? nameFirstContender{ get; set; }
    
    [JsonPropertyName("name2")]
    public string? nameSecondConteder{ get; set; }

    public PairContenderNameDTO(string? nameFirstContender, string? nameSecondConteder)
    {
        this.nameFirstContender = nameFirstContender;
        this.nameSecondConteder = nameSecondConteder;
    }
}