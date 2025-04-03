using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiParteVentaCar.AppWebMVC.Models;

public partial class Vendedore
{
    public int Id { get; set; }

    [Display(Name = "Vendedor")]
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int Telefono { get; set; }

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Dui { get; set; }

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();

    public virtual ICollection<Repuesto> Repuestos { get; set; } = new List<Repuesto>();
}
