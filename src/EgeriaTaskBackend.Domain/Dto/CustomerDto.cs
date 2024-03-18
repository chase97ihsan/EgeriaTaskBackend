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
    public class CustomerDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string AssociationNo { get; set; } 
        public string Objkey { get; set; } 
        public DateOnly CreationDate { get; set; }
       // public string OrderNumbers {  get; set; }

    }
    public class CustomerDtoProfile : Profile
    {
        public CustomerDtoProfile()
        {
          CreateMap<Customer, CustomerDto>()
          //.ForMember(dest => dest.OrderNumbers, opt => opt.MapFrom(source => string.Join(",", source.Orders.Select(x => x.OrderNo).ToList())))
          .ReverseMap();
           
        }
    }
}
