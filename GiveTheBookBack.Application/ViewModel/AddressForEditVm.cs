using AutoMapper;
using GiveTheBookBack.Application.Mapper;
using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.ViewModel
{
    public class AddressForEditVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int UserRef { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressForEditVm>().ReverseMap();
        }
    }
}
