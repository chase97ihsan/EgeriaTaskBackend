using EgeriaTaskBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EgeriaTaskBackend.Domain.Entities;

public  class Customer:BaseEntity
{
    public string CustomerId { get; set; } = null!;
    public DateOnly CreationDate { get; set; }
    public List<Order> Orders { get; set; }

}
