using System.ComponentModel.DataAnnotations;

namespace AnalisaPalavraAPI.Models
{
    public class Requisicao
    {
        [Required(ErrorMessage = "A propriedade 'texto' é obrigatória.")]
        public string Texto { get; set; }

    }
}
