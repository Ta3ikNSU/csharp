using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab2.model.Interfaces;

namespace lab4.DAO;

[Table("contenders")]
public class ContenderDao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [Column("patronymic")]
    public string Patronymic { get; set; }

    public ContenderDao(string name, string patronymic)
    {
        this.Name = name;
        this.Patronymic = patronymic;
    }
}