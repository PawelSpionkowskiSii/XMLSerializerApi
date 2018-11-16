using Optional;
using System;
using System.Collections.Generic;
using XMLSerializerApi.Configuration.Context.DatabaseManager;
using XMLSerializerApi.Generator.File;
using XMLSerializerApi.Models;

namespace XMLSerializerApi.Store.Data
{
    public class DataStore : IDataStore
    {
        private readonly IDatabaseHandler _databaseHandler;
        private readonly IFileGenerator _fileGenerator;

        public DataStore(IDatabaseHandler databaseHandler, IFileGenerator fileGenerator)
        {
            _databaseHandler = databaseHandler;
            _fileGenerator = fileGenerator;
        }

        public Option<bool, Exception> SaveData(List<RequestModel> requestList)
        {
            return _databaseHandler.UploadRequestModelList(requestList);
        }

        public Option<bool, Exception> UpdoadData()
        {
            try
            {
                var optionRequestModelList = _databaseHandler.GetRequestModelList();
                if (optionRequestModelList.HasValue)
                {
                    List<RequestModel> requestModelList = optionRequestModelList.ValueOr(new List<RequestModel>());
                    _fileGenerator.RunInternalJobTOUpdoadFiles(requestModelList);
                    return Option.Some<bool, Exception>(true);
                }
                else
                {
                    return Option.None<bool, Exception>(new Exception("Internal Server Error - data was not added to database."));
                }
            }
            catch (Exception ex)
            {
                Option<bool, Exception> errorResult = Option.None<bool, Exception>(ex);
                return errorResult;

            }
        }
    }
}