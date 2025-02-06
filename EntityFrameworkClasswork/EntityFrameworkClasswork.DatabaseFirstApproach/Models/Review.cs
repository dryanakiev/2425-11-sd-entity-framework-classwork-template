using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

public partial class Review
{
    [Key]
    public int ReviewId { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? Rating { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }

    public int ServiceId { get; set; }

    public int UserId { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("Reviews")]
    public virtual Service Service { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User User { get; set; } = null!;
}
