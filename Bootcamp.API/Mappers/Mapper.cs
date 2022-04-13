using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Models;

namespace Bootcamp.API.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
