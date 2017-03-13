
namespace IS.Web.ViewModels.BranchViewModels
{
    using Infrastructure.Enumerations;
    using Models;
    using System.ComponentModel.DataAnnotations;

    public class BranchViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Град")]
        public TownType Town { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Фирма")]
        public Business Firm { get; set; }
    }
}