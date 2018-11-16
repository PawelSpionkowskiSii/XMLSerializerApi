using AutoMapper;
using System.Globalization;
using XMLSerializerApi.Models;
using XMLSerializerApi.Models.XmlSerializer;
using XMLSerializerCommon.Models;

namespace XMLSerializerApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RequestApiModel, RequestModel>();
                cfg.CreateMap<RequestModel, RequestWithoutVisits>()
                .ForMember(x => x.Ix, m => m.MapFrom(a => a.Id))
                .ForMember(x => x.Content, m => m.MapFrom(a => new ContentWithoutVisits { DateRequested = a.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), Name = a.Name }));
                cfg.CreateMap<RequestModel, RequestVisits>()
                .ForMember(x => x.Ix, m => m.MapFrom(a => a.Id))
                .ForMember(x => x.Content, m => m.MapFrom(a => new ContentVisits { DateRequested = a.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), Name = a.Name, Vistis = a.Visits ?? default(int) }));
            });
        }
    }
}