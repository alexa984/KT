

namespace IS.Models
{
    using Infrastructure.Enumerations;
    using IS.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Business : ISUser
    {
        private IList<Branch> branches;
        private IList<Service> services;
        public Business()
        {
            this.branches = new List<Branch>();
            this.services = new List<Service>();
        }

        [StringLength(25, MinimumLength = 2)]
        public string FirmName { get; set; }

        [StringLength(13, MinimumLength = 9)]
        public string Bulstat { get; set; }

        [Required]
        public FirmType Type { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Telephone { get; set; }        

        [StringLength(500)]
        public string AdditionalInfo { get; set; }
        public int Rating { get; set; }
        public virtual IList<Service> Services
        {
            get
            {
                return this.services;
            }

            set
            {
                this.services = value;
            }
        }
        public virtual IList<Branch> Branches
        {
            get
            {
                return this.branches;
            }

            set
            {
                this.branches = value;
            }
        }
        public bool RememberMe { get; set; }
    }
}
