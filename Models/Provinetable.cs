using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace main6project.Models;

[Table("provinetable")]
public partial class Provinetable
{
    [Key]
    [Column("ProvinceID")]
    public int ProvinceId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProvinceName { get; set; } = null!;
}
