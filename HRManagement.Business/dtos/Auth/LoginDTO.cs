﻿using System.ComponentModel.DataAnnotations;

namespace HRManagement.Business.dtos.Auth;

public class LoginDTO
{
    [Required(ErrorMessage = "Email Is Required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password Is Required")]
    public string Password { get; set; }
}
