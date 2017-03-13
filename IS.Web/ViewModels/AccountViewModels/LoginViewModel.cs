

namespace IS.Web.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string PasswordHash { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }

        
    }
}