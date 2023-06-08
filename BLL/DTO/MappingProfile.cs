using AutoMapper;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shipment, ShipmentDTO>();
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
