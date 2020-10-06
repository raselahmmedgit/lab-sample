using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.PageViewModels
{
    public class AddressTypePageViewModel
    {
        [Required]
        public int TypeId { get; set; }

        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
    }
}
