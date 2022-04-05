using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginAndRegister.Models
{
    public class LoginVM
    {
        [
           EmailAddress(ErrorMessage = "E-Posta formatında giriş yapınız..."),
           Required(ErrorMessage = "E-Posta alanı zorunludur..."),
           DisplayName("E-Posta")
       ]
        public string Email { get; set; }
        [
           Required(ErrorMessage = "Parola alanı zorunludur..."),
           DisplayName("Parola")
       ]
        public string Password { get; set; }
        [DisplayName("Beni Hatırla")]
        public bool IsPersist { get; set; }
    }
}