using System.Globalization;
using System.Text;

namespace AnalisaPalavraAPI.Helpers
{
    public static class StringHelpers
    {
        public static bool EhPalindromo(string text)
        {
            // Normaliza a string para remover diacríticos
            string textoNormalizado = RemoveDiacriticos(text.ToLower());

            // Verifica se a string normalizada é um palíndromo
            int left = 0;
            int right = textoNormalizado.Length - 1;

            while (left < right)
            {
                if (textoNormalizado[left] != textoNormalizado[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public static Dictionary<char, int> ContaOcorrenciasCaracteres(string text)
        {
            string normalizedText = RemoveDiacriticos(text);

            return normalizedText
                .Where(c => !char.IsControl(c)) // Filtra caracteres de controle
                .GroupBy(c => c) // Agrupa caracteres iguais
                .ToDictionary(g => g.Key, g => g.Count()); // Converte para um dicionário de caracteres e suas contagens
        }

        private static string RemoveDiacriticos(string text)
        {
            string textoNormalizado = text.Normalize(System.Text.NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in textoNormalizado)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}