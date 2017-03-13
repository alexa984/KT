
namespace IS.Web.ViewModels.ServiceViewModels
{
    using Data.Models;
    using IS.Infrastructure.Enumerations;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Вид на услугата")]
        public ServiceType Type { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name ="Харесвания")]
        public int NumberOfLikes { get; set; }

        [Display(Name = "Фирма")]
        public Business Firm { get; set; }

        [Display(Name ="Дата на добавяне")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Коментари")]
        public ICollection<Comment> Comments { get; set; }

    }
}