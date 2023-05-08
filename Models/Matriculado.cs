using System;
using System.Collections.Generic;

namespace Clases_Interfaces.Models;

public partial class Matriculado
{
    public int IdEstudiante { get; set; }

    public string IdAsignatura { get; set; } = null!;

    public string IdPrimaryKey { get; set; } = null!;
}
