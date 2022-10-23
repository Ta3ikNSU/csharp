using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab2.model.Interfaces;

namespace lab4;

[Table("ChoiceAttempt")]
public class ChoiceAttempt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Required] [Column("number_attempt")] public int NumberAttempt { get; set; }

    // [Required]
    // [Column("contenders_rating")]
    // public Dictionary<IContender, int> ContendersRating { get; set; }
    //
    // [Required] [Column("contenders")] public Queue<IContender> Contenders { get; set; }
}