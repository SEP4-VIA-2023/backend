using System;
using System.Collections.Generic;

namespace DataAccess.models;

public partial class Measurement
{
    public int Id { get; set; }

    public int Value { get; set; }

    public DateTime Time { get; set; }

    public int Humidity { get; set; }

    public int Co2 { get; set; }

    public int Temperature { get; set; }

    public int? DeviceId { get; set; }

    public virtual Iotdevice? Device { get; set; }
}
