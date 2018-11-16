using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLSerializerApi.Models;

namespace XMLSerializerApi.Configuration.Context.DatabaseManager
{
    public interface IDatabaseHandler
    {
        Option<bool, Exception> UploadRequestModelList(List<RequestModel> requestList);
        Option<List<RequestModel>, Exception> GetRequestModelList();

    }
}