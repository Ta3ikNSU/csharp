using System.Text.Json.Serialization;
using Lombok.NET;
using Swashbuckle.AspNetCore.Annotations;

namespace lab6.DTO;

[SwaggerSchema("Pair of Contenders")]
[ToString]
public partial class PairContenderNameDTO
{
    public PairContenderNameDTO(string? nameFirstContender, string? nameSecondConteder)
    {
        NameFirstContender = nameFirstContender;
        NameSecondConteder = nameSecondConteder;
    }

    [JsonPropertyName("name1")] public string? NameFirstContender { get; set; }

    [JsonPropertyName("name2")] public string? NameSecondConteder { get; set; }
}