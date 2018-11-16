using FluentAssertions;
using RestEase;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XMLSerializerApiTests.Integration.Controller.Data
{
    public class SaveFilesIntegrationTest
    {
        const string _apiDataUrl = "http://localhost:58010/";

        IDataApi _api;
        public SaveFilesIntegrationTest()
        {
            _api = RestClient.For<IDataApi>(_apiDataUrl);
        }

        public interface IDataApi
        {
            [Get("api/jobs/saveFiles")]
            [AllowAnyStatusCode]
            Task<HttpResponseMessage> SaveFiles();
        }

        [Fact]
        public async void SaveFilesMustReturnHttpCodeOk()
        {
            HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            var result = await _api.SaveFiles();

            result.Should().NotBeNull();
            result.IsSuccessStatusCode.Should().BeTrue();
            result.StatusCode.Should().Be(expectedHttpStatusCode);
        }
    }
}