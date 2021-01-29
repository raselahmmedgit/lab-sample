using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.Models
{
    public class OwlCarouselViewModel
    {
        public OwlCarouselViewModel()
        {
            OwlCarouselItemViewModels =  new List<OwlCarouselItemViewModel>();
        }
        public string CarouseId { get; set; }
        public string SectionName { get; set; }
        public IList<OwlCarouselItemViewModel> OwlCarouselItemViewModels { get; set; }
    }

    public class OwlCarouselItemViewModel
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string TitleDesc { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
    }
}
