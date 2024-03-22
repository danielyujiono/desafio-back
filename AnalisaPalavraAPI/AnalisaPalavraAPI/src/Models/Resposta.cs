using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalisaPalavraAPI.Models
{
    public class Resposta
    {
        [JsonProperty("palindromo")]
        public bool Palindromo { get; set; }

        [JsonProperty("ocorrencias_caracteres")]
        public Dictionary<char, int> Ocorrencias_caracteres { get; set; }
    }
}
