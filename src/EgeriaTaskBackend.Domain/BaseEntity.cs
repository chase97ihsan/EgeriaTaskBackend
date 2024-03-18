using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeriaTaskBackend.Domain
{
    public class BaseEntity
    {
        public string Name { get; set; } = null!;
        public string AssociationNo { get; set; } = null!;
        public string Objkey { get; set; } = null!;
    }
}
