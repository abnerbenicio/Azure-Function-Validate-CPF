//Pacotes Necessários
using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

//Namespace da Classe da Function
namespace ValidadorCPF_AZ204
{
    //Classe da Function
    public class Function1
    {
        //Variável de Log
        private readonly ILogger _logger;

        //Construtor para definir variável de Log
        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        //Azure Function
        [Function("ValidateCPF")]
        /*
         - Variável com trigger do tipo requisição HTTP
         - Nível de autorização anônima - Qualquer um pode utilizar
         - Trigger vai ser do tipo HTTP Get Requisition
         - req representa a resposta HTPP
         - cpf é o cpf passado na rota
         */
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "validate-cpf/{cpf}")] HttpRequestData req,
            string cpf)
        {
            //Criando log
            _logger.LogInformation($"Iniciando a validação do CPF");

            // Validação do CPF
            bool isValid = ValidateCPF(cpf);

            //Criando resposta HTPP
            var response = req.CreateResponse(isValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            //Definindo Mensagem
            var message = isValid
                ? $"O CPF {cpf} é válido."
                : $"O CPF {cpf} é inválido.";

            //Definindo HEADERS
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            //Criando JSON de Resposta
            await response.WriteStringAsync(JsonSerializer.Serialize(new { message, cpf, isValid }));

            //Retornando Resposta
            return response;
        }

        //Função de validação de CPF
        private bool ValidateCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            //Validando Tamanho do CPF
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            //Listando multiplicadores
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            //Realizando cálculos de validação
            string tempCpf = cpf.Substring(0, 9);
            int soma = tempCpf.Select((t, i) => int.Parse(t.ToString()) * multiplicadores1[i]).Sum();

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            soma = tempCpf.Select((t, i) => int.Parse(t.ToString()) * multiplicadores2[i]).Sum();
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            //Retornando CPF
            return cpf.EndsWith(digito);
        }
    }
}
