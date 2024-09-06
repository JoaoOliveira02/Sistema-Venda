using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class ClienteViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Cliente!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ_CPF do Cliente!")]
        public string? CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Informe o Email do Cliente!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe o Celular do Cliente!")]
        public string? Celular { get; set; }
    }
}
