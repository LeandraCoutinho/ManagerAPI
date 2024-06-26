using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels;

public class UpdateUserViewModel
{
    [Required(ErrorMessage = "O Id não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O nome não pode ser nulo.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
    public string Name { get;  set; }
    
    [Required(ErrorMessage = "O email não pode ser nulo.")]
    [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
    [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres")]
    // [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "O email não é válido.")]
    public string Email { get;  set; }
    
    [Required(ErrorMessage = "A senha não pode ser nula.")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    [MaxLength(30, ErrorMessage = "A senha deve ter no máximo 30 caracteres")]
    public string Password { get;  set; }
}