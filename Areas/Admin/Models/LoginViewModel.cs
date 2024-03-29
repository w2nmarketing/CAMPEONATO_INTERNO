﻿using System.ComponentModel.DataAnnotations;

namespace Campeonato.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required][Display(Name = "Login")]
        public string Login { get; set; }

        [Required][Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
