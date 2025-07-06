using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public abstract class AuditEntity : BaseEntity
    {
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
