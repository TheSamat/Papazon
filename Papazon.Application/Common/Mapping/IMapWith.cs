using AutoMapper;

namespace Papazon.Application.Common.Mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile);
    }
}
