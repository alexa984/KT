
namespace IS.Web.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}