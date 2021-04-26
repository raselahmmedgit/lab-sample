﻿using System.ComponentModel.DataAnnotations;

namespace PlacovuSeniorCare.Models.TokenAuth
{
    public class ExternalAuthenticateModel
    {
        [Required]
        [StringLength(250)]
        public string AuthProvider { get; set; }

        [Required]
        [StringLength(250)]
        public string ProviderKey { get; set; }

        [Required]
        public string ProviderAccessCode { get; set; }
    }
}
