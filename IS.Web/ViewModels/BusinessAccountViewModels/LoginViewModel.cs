
namespace IS.Web.ViewModels.BusinessAccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Парола")]
        public string PasswordHash { get; set; }

        [Display(Name = "Запомни ме")]
        public bool RememberMe { get; set; }
    }
}