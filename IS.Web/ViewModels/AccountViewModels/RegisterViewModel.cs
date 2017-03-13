
namespace IS.Web.ViewModels.AccountViewModels
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
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
        public byte[] Image { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Паролата трябва да се състои поне от {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("PasswordHash", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
        
    }
}