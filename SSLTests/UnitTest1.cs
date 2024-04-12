namespace SSLTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task RequestForAzurePortal()
        {
            using var client = new HttpClient();
            var result = await client.GetAsync("https://portal.azure.com");
            Assert.Equal(result.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}