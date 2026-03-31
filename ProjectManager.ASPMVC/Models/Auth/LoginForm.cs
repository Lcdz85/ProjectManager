using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectManager.ASPMVC.Models.Auth
{
    public class LoginForm
    {
        [DisplayName("Email : ")]
        [EmailAddress(ErrorMessage = "L'Email n'est pas d'un format valide.")]
        [Required(ErrorMessage = "L'Email est obligatoire.")]
        public string Email { get; set; }
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le Password est obligatoire.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&=\-+])[a-zA-Z\d@$!%*?&=\-+]{8,64}$", ErrorMessage = "Le mot de passe doit contenir entre 8 et 64 caractères, avec au moins une lettre majuscule, une lettre minuscule, un chiffre et un caractère spécial parmi @$!%*?&=-+.")]
        public string Password { get; set; }
    }
}
