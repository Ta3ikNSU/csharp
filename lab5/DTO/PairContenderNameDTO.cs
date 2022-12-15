using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace lab5.DTO;

[SwaggerSchema("Pair of Contenders")]
public class PairContenderNameDTO
{
    [JsonProperty("name1")]
    public string? nameFirstContender{ get; set; }
    
    [JsonProperty("name2")]
    public string? nameSecondConteder{ get; set; }

    public PairContenderNameDTO(string? nameFirstContender, string? nameSecondConteder)
    {
        this.nameFirstContender = nameFirstContender;
        this.nameSecondConteder = nameSecondConteder;
    }
}