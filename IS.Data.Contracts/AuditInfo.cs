

namespace IS.Data.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AuditInfo : IAuditInfo
     {
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
