﻿using System;
using System.Collections.Generic;

namespace Clases_Interfaces.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Edad { get; set; }

    public string FechaNacimiento { get; set; } = null!;
}
