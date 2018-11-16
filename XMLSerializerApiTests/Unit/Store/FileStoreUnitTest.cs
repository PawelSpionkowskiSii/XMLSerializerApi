using FizzWare.NBuilder;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using XMLSerializerApi.Helpers;
using XMLSerializerApi.Models;
using XMLSerializerApi.Store.Data;
using Xunit;

namespace XMLSerializerApiTests.Unit.Store
{
    public class FileStoreUnitTest : BaseFileStoreUnitTest
    {
        [Fact]
        public async void UpdoadDataMustReturnOptionTrue()
        {
            WitchRunInternalJobTOUpdoadFiles();
            WitchGetRequestModelListReturnsOptionalRequestModelList();

            IDataStore dataStore = new DataStore(_mockDatabaseHandler.Object, _mockFileGenerator.Object);
            var optionResult = dataStore.UpdoadData();

            bool result = optionResult.ValueOr(false);

            optionResult.Should().NotBeNull();
            result.Should().BeTrue();
        }

        [Fact]
        public async void UpdoadDataMustReturnOptionException()
        {
            const string expectedErrorMessage = "Internal Server Error - data was not added to database.";

            WitchRunInternalJobTOUpdoadFiles();
            WitchGetRequestModelListReturnsOptionalException(expectedErrorMessage);

            IDataStore dataStore = new DataStore(_mockDatabaseHandler.Object, _mockFileGenerator.Object);
            var optionResult = dataStore.UpdoadData();

            Exception exception = optionResult.ExceptionOr(() => throw new InvalidOperationException("Error"));

            optionResult.Should().NotBeNull();
            exception.Message.Should().Be(expectedErrorMessage);
        }

        [Fact]
        public async void SaveFilesWithCorrectRequestListMustReturnOptionTrue()
        {
            List<RequestModel> requestModelList = Builder<RequestModel>
                .CreateListOfSize(10)
                .All()
                .Build().ToList();

            WitchUploadRequestModelListReturnsOptionalTrue();

            IDataStore dataStore = new DataStore(_mockDatabaseHandler.Object, _mockFileGenerator.Object);
            var optionResult = dataStore.SaveData(requestModelList);

            bool result = optionResult.ValueOr(false);

            optionResult.Should().NotBeNull();
            result.Should().BeTrue();
        }

        [Fact]
        public async void SaveFilesWithIncorrectRequestListMustReturnOptionException()
        {
            const string expectedErrorMessage = "Internal Server Error - data was saved in XML file.";

            List<RequestModel> requestModelList = Builder<RequestModel>
            .CreateListOfSize(10)
            .All()
            .Build().ToList();

            WitchUploadRequestModelListReturnsOptionalException(expectedErrorMessage);

            IDataStore dataStore = new DataStore(_mockDatabaseHandler.Object, _mockFileGenerator.Object);
            var optionResult = dataStore.SaveData(requestModelList);

            Exception exception = optionResult.ExceptionOr(() => throw new InvalidOperationException("Error"));

            optionResult.Should().NotBeNull();
            exception.Message.Should().Be(expectedErrorMessage);
        }
    }
}
