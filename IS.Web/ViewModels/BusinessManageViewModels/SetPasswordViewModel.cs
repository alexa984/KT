

namespace IS.Web.ViewModels.BusinessManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Паролата трябва да се състои поне от {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("NewPassword", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}