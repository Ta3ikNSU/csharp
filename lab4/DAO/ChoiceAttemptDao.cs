using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using lab2.model.Interfaces;

namespace lab4;

[Table("ChoiceAttempt")]
public class ChoiceAttemptDao
{
    public ChoiceAttemptDao(int numberAttempt, IDictionary<IContender, int> contendersRating, IEnumerable<IContender> contenders)
    {
        NumberAttempt = numberAttempt;
        ContendersRating = new Dictionary<IContender, int>(contendersRating);
        Contenders = new Queue<IContender>(contenders);
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("number_attempt")]
    public int NumberAttempt { get; set; }

    [Required]
    [Column("contenders_rating")]
    [NotNull]
    public Dictionary<IContender, int> ContendersRating { get; set; }

    [Required]
    [Column("contenders")]
    [NotNull]
    
    public Queue<IContender> Contenders { get; set; }
}