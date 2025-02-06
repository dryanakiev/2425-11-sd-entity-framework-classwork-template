using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_classwork.Models;

[Table("Trains")]
public class Train
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("[Name]")]
    public string Name { get; set; }
    [Column("[Type]")]
    public string Type { get; set; }
}