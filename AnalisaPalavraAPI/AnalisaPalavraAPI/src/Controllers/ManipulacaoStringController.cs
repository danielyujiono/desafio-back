using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AnalisaPalavraAPI.Helpers;
using AnalisaPalavraAPI.Models;

namespace AnalisaPalavraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManipulacaoStringController : ControllerBase
    {
        private const int CumprimentoMaximoTexto = 1000; // Tamanho máximo para o texto,
                                                         // a fim de prevenir ataques de negação de serviço (DoS) e
                                                         // garantir que a aplicação não seja sobrecarregada com
                                                         // dados excessivamente grandes.
        [HttpPost]
        public ActionResult<Resposta> Post([FromBody] Requisicao requestData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string inputText = requestData.Texto.ToString();

                if (string.IsNullOrWhiteSpace(inputText))
                {
                    return BadRequest("O texto não pode estar vazio ou conter apenas espaços em branco.");
                }
                if (inputText.Length > CumprimentoMaximoTexto)
                {
                    return BadRequest($"O texto fornecido excede o tamanho máximo permitido de {CumprimentoMaximoTexto} caracteres.");
                }

                // Verificar se a string é um palíndromo
                bool ehPalindromo = StringHelpers.EhPalindromo(inputText);

                // Contar a ocorrência de caracteres na string
                Dictionary<char, int> ocorrenciasCaracteres = StringHelpers.ContaOcorrenciasCaracteres(inputText);

                // Criar objeto de resultado
                var resposta = new Resposta
                {
                    Palindromo = ehPalindromo,
                    Ocorrencias_caracteres = ocorrenciasCaracteres
                };

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a requisição: {ex.Message}");
            }
        }


    }
}