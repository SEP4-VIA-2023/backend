﻿using System;
using System.Collections.Generic;

namespace DataAccess.models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Iotdevice> Iotdevices { get; set; } = new List<Iotdevice>();
}