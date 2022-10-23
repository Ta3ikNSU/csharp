using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab2.model.Interfaces;

namespace lab4;

public class ChoiceAttempt
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public int NumberAttempt{ get; set; }

    public Dictionary<IContender, int> ContendersRating { get; set;}
    
    public Queue<IContender> Contenders { get; set;}
}