

namespace IS.Web.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}