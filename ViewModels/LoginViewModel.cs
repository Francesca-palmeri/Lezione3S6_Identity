using System.ComponentModel.DataAnnotations;

namespace AjaxMvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
