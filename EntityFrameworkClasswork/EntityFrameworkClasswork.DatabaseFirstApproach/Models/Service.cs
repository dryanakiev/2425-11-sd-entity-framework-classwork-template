using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

public partial class Service
{
    [Key]
    public int ServiceId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int UserId { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("UserId")]
    [InverseProperty("Services")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("Services")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
