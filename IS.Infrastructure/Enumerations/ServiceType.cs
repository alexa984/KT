
using System.ComponentModel.DataAnnotations;

namespace IS.Infrastructure.Enumerations
{
    public enum ServiceType
    {
        [Display(Name = "Въведи вид")]
        Въведи = 0,

        [Display(Name = "Административни услуги")]
        Административни = 1,

        [Display(Name = "Кетъринг")]
        Кетъринг = 2,

        [Display(Name = "Монтьорски услуги")]
        Монтьорски = 3,

        [Display(Name = "Строителство")]
        Строителство = 4,

        [Display(Name = "Селскостопански услуги")]
        Селскостопански = 5,

        [Display(Name = "Социални услуги")]
        Социални = 6,

        [Display(Name = "Софтуер")]
        Софтуер = 7,

        [Display(Name = "Транспорт")]
        Транспорт = 8,

        [Display(Name = "Медицински услуги")]
        Медицински = 9,

        [Display(Name = "Други услуги")]
        Други = 10,


    }
}
