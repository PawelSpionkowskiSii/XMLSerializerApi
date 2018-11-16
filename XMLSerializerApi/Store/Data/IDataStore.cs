using Optional;
using System;
using System.Collections.Generic;
using XMLSerializerApi.Models;

namespace XMLSerializerApi.Store.Data
{
    public interface IDataStore
    {
        Option<bool, Exception> SaveData(List<RequestModel> request);
        Option<bool, Exception> UpdoadData();
    }
}