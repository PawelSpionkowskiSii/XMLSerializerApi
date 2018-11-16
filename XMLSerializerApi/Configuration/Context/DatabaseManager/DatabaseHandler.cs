using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Optional;
using XMLSerializerApi.Models;

namespace XMLSerializerApi.Configuration.Context.DatabaseManager
{
    public class DatabaseHandler : IDatabaseHandler
    {
        static SerializerDatabaseContext _dbContext = new SerializerDatabaseContext();

        public Option<List<RequestModel>, Exception> GetRequestModelList()
        {
            List<RequestModel> requestModelList = _dbContext.requestModel.ToList();
            return Option.Some<List<RequestModel>, Exception>(requestModelList);
        }

        public Option<bool, Exception> UploadRequestModelList(List<RequestModel> requestList)
        {
            List<RequestModel> requestModelFromDatabase;
            RequestModel singleRequestModel;
            var customers = _dbContext.Set<RequestModel>();

            foreach (RequestModel requestModel in requestList)
            {
                requestModelFromDatabase = _dbContext.requestModel.Where(x => x.Index == requestModel.Index && x.Name == requestModel.Name).ToList();

                if (requestModelFromDatabase.Any())
                {
                    singleRequestModel = requestModelFromDatabase.Single();
                    singleRequestModel.Visits = requestModel.Visits;
                    singleRequestModel.Date = requestModel.Date;
                }
                else
                {
                    customers.Add(requestModel);
                }

            }

            _dbContext.SaveChanges();

            return Option.Some<bool, Exception>(true);
        }
    }
}