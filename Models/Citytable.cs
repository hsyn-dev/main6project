using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace main6project.Models;

[Table("citytable")]
public partial class Citytable
{
    [Key]
    [Column("CityID")]
    public int CityId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CityName { get; set; } = null!;

    [Column("ProvinceID")]
    public int ProvinceId { get; set; }
}
