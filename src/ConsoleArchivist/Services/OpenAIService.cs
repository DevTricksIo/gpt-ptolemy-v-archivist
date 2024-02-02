using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text;
using ConsoleArchivist.Models.Responses;
using ConsoleArchivist.Services.Abstractions;

namespace ConsoleArchivist.Services
{
    public class OpenAIService(IHttpClientFactory httpClientFactory, IPharaohBodyBuilderService bodyBuilder) : IOpenAIService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OpenAIAPI");
        private readonly IPharaohBodyBuilderService bodyBuilder = bodyBuilder;

        public async Task<string> GetAYamlTranslationBasedOnTemplate(string targetLanguage)
        {
            return await GetAsync(bodyBuilder.BuildGetTranslationBodyRequest(targetLanguage));
        }

        public async Task<string> IsAGoodTranslation(string yamlTranslation)
        {
            return await GetAsync(bodyBuilder.BuildIsAcceptableTranslationBodyRequest(yamlTranslation));
        }

        private async Task<string> GetAsync(object requestBody)
        {
            var url = "/v1/chat/completions";

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody, options);

            var payload = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, payload);

            response.EnsureSuccessStatusCode();

            var jsonResponse = JsonSerializer.Deserialize<JsonResponse>(await response.Content.ReadAsStringAsync());

            var theResponseHasContent = jsonResponse != null && jsonResponse.Choices != null && jsonResponse.Choices.Length > 0;

            if (theResponseHasContent)
            {
                return jsonResponse!.Choices![0].Message.Content;
            }

            throw new Exception("Unknow error!");
        }
    }
}
