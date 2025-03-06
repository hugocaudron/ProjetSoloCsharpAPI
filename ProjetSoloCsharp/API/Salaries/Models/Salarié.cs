using System;
using System.Collections.Generic;

namespace ProjetSoloCsharp.API.Salaries;

public partial class Salarié
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;

    public string Prénom { get; set; } = null!;

    public int TelFixe { get; set; }

    public int TelPortable { get; set; }

    public string Email { get; set; } = null!;

    public int IdServices { get; set; }

    public int IdSite { get; set; }
    
}
