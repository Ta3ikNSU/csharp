using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.DAO;

public class ContenderDao
{
    public ContenderDao(string name, string patronymic)
    {
        Name = name;
        Patronymic = patronymic;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("patronymic")]
    public string Patronymic { get; set; }
    
    
}