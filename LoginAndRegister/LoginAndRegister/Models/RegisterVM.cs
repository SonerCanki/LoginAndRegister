using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginAndRegister.Models
{
    public class RegisterVM
    {
        [
          Required(ErrorMessage = "İsim alanı zorunludur..."),
          DisplayName("İsim")
      ]
        public string FirstName { get; set; }
        [
          Required(ErrorMessage = "Soyisim alanı zorunludur..."),
          DisplayName("Soyisim")
      ]
        public string LastName { get; set; }
        [
          EmailAddress(ErrorMessage = "E-Posta formatında giriş yapınız..."),
          Required(ErrorMessage = "E-Posta alanı zorunludur..."),
          DisplayName("E-Posta")
      ]
        public string Email { get; set; }
        [
          DisplayName("Parola")
      ]
        public string Password { get; set; }
        [
          DisplayName("Parola doğrula")
      ]
        public string PasswordVerify { get; set; }
    }
}