using System.Text.Json.Serialization;

namespace lab5.DTO;

public class ContenderDTO
{
    [JsonPropertyName("name")]
    public string? name{ get; set; }

    public ContenderDTO(string? name)
    {
        Console.WriteLine("name : " + name);
        if (name != null)
        {
            this.name = name;
        }
    }
}