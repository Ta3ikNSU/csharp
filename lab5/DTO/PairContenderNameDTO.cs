using System.Text.Json.Serialization;
using Lombok.NET;
using Swashbuckle.AspNetCore.Annotations;

namespace lab5.DTO;

[SwaggerSchema("Pair of Contenders")]
[ToString]
public partial class PairContenderNameDTO
{
    public PairContenderNameDTO(string? nameFirstContender, string? nameSecondConteder)
    {
        this.nameFirstContender = nameFirstContender;
        this.nameSecondConteder = nameSecondConteder;
    }

    [JsonPropertyName("name1")] public string? nameFirstContender { get; set; }

    [JsonPropertyName("name2")] public string? nameSecondConteder { get; set; }
}