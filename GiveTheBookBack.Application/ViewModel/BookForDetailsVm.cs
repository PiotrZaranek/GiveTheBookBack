﻿using AutoMapper;
using GiveTheBookBack.Application.Mapper;
using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.ViewModel
{
    public class BookForDetailsVm : IMapFrom<Book>
    {        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }        
        public User User { get; set; }    
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForDetailsVm>();
        }
    }
}
