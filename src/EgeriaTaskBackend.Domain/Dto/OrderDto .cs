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

        public string CustomerNo { get; set; }

        public DateTime DateEntered { get; set; }

        public string State { get; set; } = null!;

        public string Objkey { get; set; } = null!;
        

    }
    public class OrderDtoProfile : Profile
    {
        public OrderDtoProfile()
        {
          CreateMap<Order, OrderDto>()
          .ReverseMap();
           
        }
    }
}
