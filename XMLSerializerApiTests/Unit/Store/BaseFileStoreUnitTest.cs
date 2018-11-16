using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using XMLSerializerApi.Configuration.Context.DatabaseManager;
using XMLSerializerApi.Generator.File;
using XMLSerializerApi.Models;
using Optional;

namespace XMLSerializerApiTests.Unit.Store
{
    public class BaseFileStoreUnitTest
    {
        public Mock<IFileGenerator> _mockFileGenerator;
        public Mock<IDatabaseHandler> _mockDatabaseHandler;

        public BaseFileStoreUnitTest()
        {
            _mockDatabaseHandler = new Mock<IDatabaseHandler>();
            _mockFileGenerator = new Mock<IFileGenerator>();
        }

        public void WitchRunInternalJobTOUpdoadFiles()
        {
            _mockFileGenerator.Setup(foo => foo.RunInternalJobTOUpdoadFiles(It.IsAny<List<RequestModel>>()));
        }

        public void WitchGetRequestModelListReturnsOptionalRequestModelList()
        {
            IList<RequestModel> requestModelList = Builder<RequestModel>
                .CreateListOfSize(10)
                .All()
                .Build();

            _mockDatabaseHandler.Setup(foo => foo.GetRequestModelList()).Returns(Option.Some<List<RequestModel>, Exception>(requestModelList.ToList()));
        }

        public void WitchGetRequestModelListReturnsOptionalException(string errorMessage)
        {
            _mockDatabaseHandler.Setup(foo => foo.GetRequestModelList()).Returns(Option.None<List<RequestModel>, Exception>(new Exception(errorMessage)));
        }

        public void WitchUploadRequestModelListReturnsOptionalTrue()
        {
            _mockDatabaseHandler.Setup(foo => foo.UploadRequestModelList(It.IsAny<List<RequestModel>>())).Returns(Option.Some<bool, Exception>(true));
        }

        public void WitchUploadRequestModelListReturnsOptionalException(string errorMessage)
        {
            _mockDatabaseHandler.Setup(foo => foo.UploadRequestModelList(It.IsAny<List<RequestModel>>())).Returns(Option.None<bool, Exception>(new Exception(errorMessage)));
        }
    }
}
