using System;
using System.Collections.Generic;

namespace EgeriaTaskBackend.Domain.Entities;

public  class Supplier:BaseEntity
{
    public string SupplierId { get; set; } = null!;
    public DateOnly CreationDate { get; set; }

}
