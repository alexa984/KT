

namespace IS.Data.Models
{
    using Data.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ForumPost : DeletableEntity
    {
        private ICollection<Comment> comments;

        public ForumPost()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string ISUserId { get; set; }

        [ForeignKey("ISUserId")]
        public virtual ISUser ISUser { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                this.comments = value;
            }
        }
    }
}
