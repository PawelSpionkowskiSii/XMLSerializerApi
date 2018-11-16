using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLSerializerCommon.Models;

namespace XMLSerializerCommon.Shared
{
    public class RequestApiModelDataGenerator
    {
        public static List<RequestApiModel> GetRandomRequestApiModel(int argNumber)
        {
            List<RequestApiModel> RequestApiModelList = new Faker<RequestApiModel>()
                .RuleFor(o => o.Date, f => f.Date.Past())
                .RuleFor(o => o.Index, f => f.IndexFaker)
                .RuleFor(o => o.Name, (f, u) => f.Name.LastName())
                .RuleFor(o => o.Visits, (f, u) => f.Random.Int(1, 99999)).Generate(argNumber).ToList();

            RequestApiModelList.Take(1).Single().Visits = null;

            return RequestApiModelList;
        }
    }
}
