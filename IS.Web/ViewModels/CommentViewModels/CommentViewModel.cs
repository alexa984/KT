
namespace IS.Web.ViewModels.CommentViewModels
{
    using IS.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel
    {        
        public int Id { get; set; }
        [Display(Name ="Съдържание")]
        public string Content { get; set; }

        [Display(Name = "Услуга")]
        public Service Service { get; set; }

        [Display(Name = "Потребител")]
        public ISUser ISUser { get; set; }

        [Display(Name ="Дата")]
        public DateTime CreatedOn { get; set; }
    }
}