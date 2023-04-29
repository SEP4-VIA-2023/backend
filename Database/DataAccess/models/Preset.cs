using System;
using System.Collections.Generic;

namespace DataAccess.models;

public partial class Preset
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MinHumidity { get; set; }

    public int MaxHumidity { get; set; }

    public int MinCo2 { get; set; }

    public int MaxCo2 { get; set; }

    public int MinTemperature { get; set; }

    public int MaxTemperature { get; set; }

    public int? DeviceId { get; set; }

    public virtual Iotdevice? Device { get; set; }
}
