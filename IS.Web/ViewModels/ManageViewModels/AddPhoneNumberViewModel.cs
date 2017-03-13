
namespace IS.Web.ViewModels.ManageViewModels
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