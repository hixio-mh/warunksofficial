using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WarunkStream.Models.ViewModels
{
    public class Account
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Nama lengkap wajib diisi")]
        public string FullName { get; set; }
        [Remote("IsValidEmail", "Account", HttpMethod = "POST", ErrorMessage = "Nama id sudah digunakan")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        [Required(ErrorMessage = "Alamat email wajib diisi")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Phone number is not valid")]
        [Required(ErrorMessage = "Nomor telepon wajib diisi")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        [RegularExpression(@"^(1[ \-\+]{0,3}|\+1[ -\+]{0,3}|\+1|\+)?((\(\+?1-[2-9][0-9]{1,2}\))|(\(\+?[2-8][0-9][0-9]\))|(\(\+?[1-9][0-9]\))|(\(\+?[17]\))|(\([2-9][2-9]\))|([ \-\.]{0,3}[0-9]{2,4}))?([ \-\.][0-9])?([ \-\.]{0,3}[0-9]{2,4}){2,3}$", ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Kata sandi wajib diisi")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Panjang karakter minimal 6.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Kata sandi harus sama.")]
        public string ConfirmPassword { get; set; }
    }
}