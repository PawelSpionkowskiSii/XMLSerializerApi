using AutoMapper;
using System.Collections.Generic;
using XMLSerializerApi.Models;
using XMLSerializerCommon.Models;

namespace XMLSerializerApi.Helpers
{
    public static class ResponseModelConverter
    {
        public static List<RequestModel> Convert(this List<RequestApiModel> requestApiModel)
        {
            return Mapper.Map<List<RequestApiModel>, List<RequestModel>>(requestApiModel);
        }
    }
}