using ConsoleArchivist.Helpers;

namespace ConsoleArchivistTester
{
    public  class ConfigurationExtensionsTests : SetUp
    {
        //TODO Refactor this how test with other values?
        [Fact]
        public void CanInstantiateGitHubAPIClient_Success()
        {
            //Arrange
            var token = Configuration.GetGitHubToken();

            //Act

            //Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
    }
}
