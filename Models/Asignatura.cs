using System;
using System.Collections.Generic;

namespace Clases_Interfaces.Models;

public partial class Asignatura
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Código { get; set; }

    public DateOnly FechaActualizacion { get; set; }
}
