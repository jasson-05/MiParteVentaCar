using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiParteVentaCar.AppWebMVC.Models;

public partial class Auto
{
    public int Id { get; set; }

    [Display(Name = "Vendedor")]
    public int IdVendedor { get; set; }

    [Display(Name = "Departamento")]
    public int IdDepartamento { get; set; }

    [Display(Name = "Marca")]
    public int IdMarca { get; set; }

    [Display(Name = "Año de fabricacion")]
    public string? AnnoFabricacion { get; set; }

    [Required(ErrorMessage = "El modelo es obligatorio.")]
    [Display(Name = "Modelo")]
    public string Modelo { get; set; } = null!;

    [Required(ErrorMessage = "La Descripción es obligatoria.")]
    [Display(Name = "Descripción")]
    public string DescripcionA { get; set; } = null!;

    public decimal? Kilometraje { get; set; }

    public string? Estado { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Display(Name = "Precio")]
    public decimal Precio { get; set; }


    [Required(ErrorMessage = "La Foto es obligatoria.")]
    [Display(Name = "Foto")]
    public string Urlimagen { get; set; } = null!;

    [Required(ErrorMessage = "La utima revición tecnológica es obligatoria.")]
    [Display(Name = "Utima revición tecnológica")]
    public DateTime Urt { get; set; }

    [Display(Name = "Disponible hasta")]
    public DateTime? FechaRp { get; set; }

    public byte? Actividad { get; set; }

    public string? Comentario { get; set; }

    public virtual ICollection<DetalleVenta>? DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Departamento? IdDepartamentoNavigation { get; set; } = null!;

    public virtual Marca? IdMarcaNavigation { get; set; } = null!;

    public virtual Vendedore? IdVendedorNavigation { get; set; } = null!;
}
