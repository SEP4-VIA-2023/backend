using System;
using System.Collections.Generic;

namespace DataAccess.models;

public partial class Iotdevice
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public virtual ICollection<Preset> Presets { get; set; } = new List<Preset>();

    public virtual User? User { get; set; }
}
