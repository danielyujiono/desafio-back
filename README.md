# AnalisaPalavraAPI

Este é um projeto de uma API em .NET Core que recebe um JSON via POST contendo uma propriedade "texto" e retorna se o texto é um palíndromo ou não, juntamente com a contagem de ocorrências de caracteres.

## Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado em sua máquina:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Como executar

1. Clone este repositório para o seu computador:

git clone https://github.com/danielyujiono/desafio-back.git

2. Navegue até o diretório do projeto: cd AnalisaPalavraAPI
3. Execute o projeto usando o comando dotnet: dotnet run
4. Acesse os endpoints da API em `https://localhost:7280/swagger/index.html1` (ou em outra porta se especificada).

A API possui um endpoint POST `/api/manipulacaostring` que espera receber um JSON com a propriedade "texto" contendo a string que você deseja analisar.

Exemplo de requisição:

{
  "texto": "arara"
}

A API retornará um JSON com a propriedade "palindromo" indicando se a string é um palíndromo e "ocorrencias_caracteres" contendo a contagem de ocorrências de caracteres na string. 

Caracteres acentudas serão considerados caracteres sem acentuação.

Limite de caracteres estabelecido em 1.000 caracteres para prevenir ataques de negação de serviço (DoS).

Exemplo de resposta:

{
  "palindromo": true,
  "ocorrencias_caracteres": {
    "a": 3,
    "r": 2
  }
}

## Utilização em produção

A solução está hospedada em:
https://danielono.azurewebsites.net/api/ManipulacaoString 

A requisição à API pode ser feita através de Postman ou de cUrl.

Exemplo em cUrl:
curl -X POST -H "Content-Type: application/json" -d '{" texto ": "banana"}' https://danielono.azurewebsites.net/api/ManipulacaoString

As requisições via Postman ou cUrl precisam serem feitas fora da rede Caixa.
