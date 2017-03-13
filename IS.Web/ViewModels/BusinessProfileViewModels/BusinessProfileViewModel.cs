

namespace IS.Web.ViewModels.BusinessProfileViewModels
{
    using Data.Models;
    using Infrastructure.Enumerations;
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class BusinessProfileViewModel
    {
        public string Id { get; set; }


        [StringLength(25, ErrorMessage = "Името трябва да е с дължина между 2 и 25 символа.", MinimumLength = 2)]
        [Display(Name = "Име на фирмата")]
        public string FirmName { get; set; }

        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(13, ErrorMessage = "Булстатът е с дължина 9, 10 или 13 цифри.", MinimumLength = 9)]
        [Display(Name = "Булстат")]
        public string Bulstat { get; set; }

        [Display(Name = "Вид на фирмата")]
        public FirmType Type { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Дължината на телефонния номер трябва да е между 3 и 20 символа.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефонен номер")]
        public string Telephone { get; set; }

        [Display(Name = "Адреси")]
        public IList<Branch> Branches { get; set; }

        [MaxLength(500, ErrorMessage = "Допълнителната информация не трябва да надвишава 500 символа.")]
        [Display(Name = "Допълнителна информация")]
        [DataType(DataType.MultilineText)]
        public string AdditionalInfo { get; set; }

        [Display(Name = "Услуги")]
        public IList<Service> Services { get; set; }

        [Display(Name = "Профилна снимка")]
        public byte[] Image { get; set; }
    }
}