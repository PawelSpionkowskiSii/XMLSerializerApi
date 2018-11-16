using System.Collections.Generic;
using XMLSerializerApi.Models;

namespace XMLSerializerApi.Generator.File
{
    public interface IFileGenerator
    {
        void RunInternalJobTOUpdoadFiles(List<RequestModel> requestModelList);
    }
}