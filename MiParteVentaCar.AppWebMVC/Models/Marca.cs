using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiParteVentaCar.AppWebMVC.Models;

public partial class Marca
{
    public int Id { get; set; }

    [Display(Name = "Marca")]
    public string Marca1 { get; set; } = null!;

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();
}
