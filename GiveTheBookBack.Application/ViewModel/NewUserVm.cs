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
    public class NewUserVm : IMapFrom<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewUserVm, User>();
        }
    }
}
