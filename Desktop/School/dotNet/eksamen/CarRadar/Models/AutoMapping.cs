using AutoMapper;
using CarRadar.Models;

namespace CarRadar.Models
{
    public class AutoMapping : Profile
    {
       public AutoMapping()
        {
            CreateMap<Car, CarPublic>();
//            CreateMap<CarPublic, Car>();
        }
    }
}