using ConsoleArchivist.Services;
using ConsoleArchivist.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text;

namespace ConsoleArchivistTester
{
    public class OpenAIServiceTests
    {
        [Fact]
        public async Task A()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var bodyBuilder = new Mock<IPharaohBodyBuilderService>();
            var configurationMock = new Mock<IConfiguration>(); // Se necessário

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Aqui vai a resposta esperada", Encoding.UTF8, "application/json"),
            };

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://api.openai.com")
            };

            dynamic expectedBody = new
            {
                model = "gpt-4",
                messages = "body messages"
            };

            bodyBuilder.Setup(b => b.BuildGetTranslationBodyRequest(It.IsAny<string>())).Returns(expectedBody);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Supondo que OpenAIService usa IHttpClientFactory e IPharaohBodyBuilderService
            var sut = new OpenAIService(httpClientFactoryMock.Object, bodyBuilder.Object);

           

            // Configurar bodyBuilder para retornar um payload específico, se necessário

            // Act
            var data = await sut.GetAYamlTranslationBasedOnTemplate("pt");

            // Assert
            bodyBuilder.Verify(service => service.BuildGetTranslationBodyRequest("pt"), Times.Once());
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(), // Verifica se SendAsync foi chamado uma vez
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri.ToString().Contains("api.openai.com")), // Adapte conforme necessário
                ItExpr.IsAny<CancellationToken>()
            );

        }

    }
}
