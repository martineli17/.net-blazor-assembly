using AutoMapper;

namespace Apresentation.Services.Base
{
    public class InjectorServiceBaseApresentation
    {
        public readonly IMapper Mapper;
        public InjectorServiceBaseApresentation(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
