

namespace IS.Data.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : DeletableEntity
    {        
        public int Id { get; set; }
        public string Content { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        public string ISUserId { get; set; }
        [ForeignKey("ISUserId")]
        public virtual ISUser ISUser { get; set; }
    }
} 
