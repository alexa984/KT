
namespace IS.Web.ViewModels.BusinessManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Телефонен номер")]
        public string Number { get; set; }
    }
}