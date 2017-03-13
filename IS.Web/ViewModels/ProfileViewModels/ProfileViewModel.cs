
namespace IS.Web.ViewModels.ProfileViewModels
{
    using IS.Data.Models;
    using IS.Infrastructure.Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Първо име")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Град")]
        public TownType Town { get; set; }

        [Display(Name = "Профилна снимка")]
        public byte[] Image { get; set; }

        [Display(Name ="Коментари")]
        public List<Comment> Comments { get; set; }
    }
} 