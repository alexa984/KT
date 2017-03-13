

namespace IS.Data.Models
{
    using Contracts;
    using IS.Infrastructure.Enumerations;
    using IS.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Service : DeletableEntity
    {
        private ICollection<Comment> comments;

        public Service()
        {
            this.comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }

        public string BusinessId { get; set; }

        public ServiceType Type { get; set; }

        public string Description { get; set; }

        public int NumberOfLikes { get; set; }

        [ForeignKey("BusinessId")]
        public virtual Business Firm { get; set; }

        public ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
        
    }
}
