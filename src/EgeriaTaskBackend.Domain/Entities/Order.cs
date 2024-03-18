using System;
using System.Collections.Generic;

namespace EgeriaTaskBackend.Domain.Entities;

public  class Order
{
    public string OrderNo { get; set; } = null!;

    public string CustomerNo { get; set; }
    public Customer customer { get; set; }

    public DateTime DateEntered { get; set; }

    public string State { get; set; } = null!;

    public string Objkey { get; set; } = null!;
}
