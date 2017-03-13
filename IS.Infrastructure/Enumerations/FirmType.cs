
using System.ComponentModel.DataAnnotations;

namespace IS.Infrastructure.Enumerations
{
    public enum FirmType
    {
        [Display(Name = "Въведи вид")]
        Въведи = 0,

        [Display(Name ="ЕТ")]
        ЕТ = 1,

        [Display(Name = "ЕООД")]
        ЕООД = 2,

        [Display(Name = "КД")]
        КД = 3,

        [Display(Name = "СД")]
        СД = 4,

        [Display(Name = "ООД")]
        ООД = 5,

        [Display(Name = "АД")]
        АД = 6,

        [Display(Name = "КДА")]
        КДА = 7
    }
}
