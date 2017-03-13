
namespace IS.Models
{
    using Data.Contracts;
    using Infrastructure.Enumerations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Branch : DeletableEntity
    {
        public int Id { get; set; }
        public string BusinessId { get; set; }
        public TownType Town { get; set; }
        public string Address { get; set; }

        [ForeignKey("BusinessId")]
        public virtual Business Firm { get; set; }
    }
}
