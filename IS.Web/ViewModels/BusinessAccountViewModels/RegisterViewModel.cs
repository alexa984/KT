

namespace IS.Web.ViewModels.BusinessAccountViewModels
{
    using IS.Infrastructure.Enumerations;
    using System.ComponentModel.DataAnnotations;
    public class RegisterViewModel
    {

        [Required]
        [StringLength(25, ErrorMessage = "Името трябва да е с дължина между 2 и 25 символа.", MinimumLength = 2)]
        [Display(Name = "Име на фирмата")]
        public string FirmName { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Булстатът е с дължина 9, 10 или 13 цифри.", MinimumLength = 9)]
        [Display(Name = "Булстат")]
        public string Bulstat { get; set; }

        [Required]
        [Display(Name = "Вид на фирмата")]
        public FirmType Type { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Дължината на телефонния номер трябва да е между 3 и 20 символа.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефонен номер")]
        public string Telephone { get; set; }

        [MaxLength(500, ErrorMessage = "Допълнителната информация не трябва да надвишава 500 символа.")]
        [Display(Name = "Допълнителна информация")]
        [DataType(DataType.MultilineText)]
        public string AdditionalInfo { get; set; }

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