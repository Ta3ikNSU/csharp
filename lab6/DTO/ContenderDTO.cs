using System.Text.Json.Serialization;
using Lombok.NET;

namespace lab6.DTO;

[ToString]
public partial class ContenderDTO
{
    public ContenderDTO(string? name)
    {
        if (name != null) this.Name = name;
    }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}