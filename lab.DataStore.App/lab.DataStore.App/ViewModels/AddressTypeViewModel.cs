﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.ViewModels
{
    public class AddressTypeViewModel
    {
        [Key]
        public int TypeId { get; set; }
        [StringLength(120)]
        public string TypeName { get; set; }
    }
}
