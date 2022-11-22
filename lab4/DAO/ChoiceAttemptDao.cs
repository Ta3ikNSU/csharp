using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using lab2.model.Interfaces;
using lab4.DAO;

namespace lab4;

[Table("choice_attempt")]
public class ChoiceAttemptDao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("number_attempt")]
    public int NumberAttempt { get; set; }

    [Required]
    [Column("number_in_attempt")]
    public int Number { get; set; }

    [Required]
    [Column("rating")]
    public int Rating { get; set; }

    [Required]
    [Column("contender")]
    public ContenderDao ContenderDao { get; set; }
}