

namespace IS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Infrastructure.Enumerations;

    public class ISUser : IdentityUser
    {
        private ICollection<Comment> comments;
        public ISUser()
        {
            this.comments = new HashSet<Comment>();
        }

        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }
        public TownType Town { get; set; }

        [DefaultValue(0)]
        public int ForumPoints { get; set; }

        public IEnumerable<ForumPost> ForumPosts { get; set; }

        public byte[] Image { get; set; }

        

        public virtual ICollection<Comment> Comments
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ISUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("Fullname", this.FirstName + " " + this.LastName));

            // Add custom user claims here
            return userIdentity;
        }
    }
}
