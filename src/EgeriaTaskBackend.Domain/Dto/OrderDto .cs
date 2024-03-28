using AutoMapper;
using EgeriaTaskBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EgeriaTaskBackend.Domain.Dto
{
    public class OrderDto
    {
        public string OrderNo { get; set; } = null!;

        public string CustomerName { get; set; }

        public string DateEntered { get; set; }

        public string State { get; set; } = null!;

        public string Objkey { get; set; } = null!;
        

    }
    public class OrderDtoProfile : Profile
    {
        public OrderDtoProfile()
        {
          CreateMap<Order, OrderDto>().ForMember(dest => dest.CustomerName, opt => opt.MapFrom(source => source.customer.Name))
                 .ForMember(dest => dest.DateEntered, opt => opt.MapFrom(source => source.DateEntered.ToString("yyyy-MM-dd HH:mm:ss")))

          .ReverseMap();
           
        }
    }
}
