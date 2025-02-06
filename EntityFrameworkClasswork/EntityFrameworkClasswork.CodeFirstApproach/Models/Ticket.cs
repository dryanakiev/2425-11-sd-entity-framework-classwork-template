using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_classwork.Models;

[Table("Tickets")]
public class Ticket
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Number { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime DepartureTime { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime ArrivalTime { get; set; }
    [ForeignKey("Trains")]
    public Train Train { get; set; }
}