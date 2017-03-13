
namespace IS.Web.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}