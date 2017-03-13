
namespace IS.Web.ViewModels.BusinessManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; }
    }
}