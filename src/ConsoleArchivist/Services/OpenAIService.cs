using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text;
using ConsoleArchivist.Models.Responses;
using ConsoleArchivist.Helpers;
using Microsoft.Extensions.Configuration;

namespace ConsoleArchivist.Services
{
    public class OpenAIService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : IOpenAIService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OpenAIAPI");
        private readonly IConfiguration _configuration = configuration;

        public async Task<string?> GetTranslation(string prompt)
        {
            var url = "/v1/chat/completions";

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonRequest = JsonSerializer.Serialize(BuildGetTranslationBodyRequest(prompt), options);

            var payload = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, payload);

            response.EnsureSuccessStatusCode();

            var responseObj = JsonSerializer.Deserialize<JsonResponse>(await response.Content.ReadAsStringAsync());

            var theResponseHasContent = responseObj != null && responseObj.Choices != null && responseObj.Choices.Length > 0;

            if (theResponseHasContent)
            {
                return responseObj!.Choices![0].Message.Content;
            }

            return null;
        }

        public async Task<string?> IsAAcceptableTranslation(string yamlTranslation)
        {
            var url = "/v1/chat/completions";

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonRequest = JsonSerializer.Serialize(BuildIsAcceptableTranslationBodyRequest(yamlTranslation), options);

            var payload = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, payload);

            response.EnsureSuccessStatusCode();

            var jsonResponse = JsonSerializer.Deserialize<JsonResponse>(await response.Content.ReadAsStringAsync());

            var theResponseHasContent = jsonResponse != null && jsonResponse.Choices != null && jsonResponse.Choices.Length > 0;
            
            if (theResponseHasContent)
            {
                return jsonResponse!.Choices![0].Message.Content;
            }

            return null;
        }

        private object BuildGetTranslationBodyRequest(string targetLanguage)
        {
            return new
            {
                model = "gpt-4",
                messages = new List<object>
                {
                    new
                    {
                        role = "system",
                        content = _configuration.GetSection("Prompt:InstructionForTranslation").Value
                    },
                    new
                    {
                        role = "user",
                        content = targetLanguage
                    }
                }
            };
        }

        private object BuildIsAcceptableTranslationBodyRequest(string yamlTranslation)
        {
            return new
            {
                model = "gpt-4",
                messages = new List<object>
                {
                    new
                    {
                        role = "system",
                        content = _configuration.GetSection("Prompt:InstructionForReviewing").Value
                    },
                    new
                    {
                        role = "user",
                        content = $"Target language: {TranslationHelper.GetEnglishLangName(yamlTranslation)}  Content: {yamlTranslation}"
                    }
                }
            };
        }

    }
}
