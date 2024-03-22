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
        private const int CumprimentoMaximoTexto = 1000; // Tamanho m�ximo para o texto,
                                                         // a fim de prevenir ataques de nega��o de servi�o (DoS) e
                                                         // garantir que a aplica��o n�o seja sobrecarregada com
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
                    return BadRequest("O texto n�o pode estar vazio ou conter apenas espa�os em branco.");
                }
                if (inputText.Length > CumprimentoMaximoTexto)
                {
                    return BadRequest($"O texto fornecido excede o tamanho m�ximo permitido de {CumprimentoMaximoTexto} caracteres.");
                }

                // Verificar se a string � um pal�ndromo
                bool ehPalindromo = StringHelpers.EhPalindromo(inputText);

                // Contar a ocorr�ncia de caracteres na string
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
                return StatusCode(500, $"Ocorreu um erro ao processar a requisi��o: {ex.Message}");
            }
        }


    }
}