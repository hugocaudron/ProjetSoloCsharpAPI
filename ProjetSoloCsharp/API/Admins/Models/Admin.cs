﻿using System;
using System.Collections.Generic;

namespace ProjetSoloCsharp.API.Admins.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;
    
    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;
}
