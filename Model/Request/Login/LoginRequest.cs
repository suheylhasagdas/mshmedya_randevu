using System.ComponentModel.DataAnnotations;

namespace Model.Request.Login
{
    public class LoginRequest
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        public string LoginName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        public string Password { get; set; }
    }
}
