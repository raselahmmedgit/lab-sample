﻿using System.ComponentModel.DataAnnotations;

namespace PlacovuSeniorCare.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(250)]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        
        public bool RememberClient { get; set; }
    }
}
