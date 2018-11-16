using FluentAssertions;
using RestEase;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XMLSerializerCommon.Models;
using XMLSerializerCommon.Shared;
using Xunit;

namespace XMLSerializerApiTests.Integration.Controller.Data
{
    public class UpdoadDataIntegrationTest
    {
        IDataApi _api;
        public UpdoadDataIntegrationTest()
        {
            _api = RestClient.For<IDataApi>("http://localhost:58010/");
        }

        public interface IDataApi
        {
            [Post("api/data")]
            [AllowAnyStatusCode]
            Task<HttpResponseMessage> UpdoadData([Body] List<RequestApiModel> requestApiModel);
        }

        [Fact]
        public async void UpdoadDataWithCorrectListOfRequestApiModelMustReturnHttpCodeOk()
        {
            int countOfGeneratedRequestApiModelItems = 10;
            List<RequestApiModel> requestApiModelList = RequestApiModelDataGenerator.GetRandomRequestApiModel(countOfGeneratedRequestApiModelItems);
            HttpStatusCode expectedHttpStatusCode = HttpStatusCode.OK;

            var result = await _api.UpdoadData(requestApiModelList);

            result.Should().NotBeNull();
            result.IsSuccessStatusCode.Should().BeTrue();
            result.StatusCode.Should().Be(expectedHttpStatusCode);
        }

        [Fact]
        public async void UpdoadDataWithEmptyListOfRequestApiModelMustReturnHttpCodeBadRequest()
        {
            List<RequestApiModel> requestApiModelListWithNull = null;
            HttpStatusCode expectedHttpStatusCode = HttpStatusCode.BadRequest;

            var result = await _api.UpdoadData(requestApiModelListWithNull);

            result.Should().NotBeNull();
            result.IsSuccessStatusCode.Should().BeFalse();
            result.StatusCode.Should().Be(expectedHttpStatusCode);
        }
    }
}