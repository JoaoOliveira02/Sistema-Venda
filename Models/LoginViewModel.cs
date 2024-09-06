using System.ComponentModel.DataAnnotations;
namespace SistemaVenda.Models

{
    public class LoginViewModel
    {    
        [Required(ErrorMessage = "Informe o Email!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha!!")]
        public string Senha { get; set; }
    }
}
