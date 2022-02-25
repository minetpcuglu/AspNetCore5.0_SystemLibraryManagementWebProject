using AutoMapper;
using DataAccessLayer.Models.VMs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
   public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, UserSignInVM>().ReverseMap();
            CreateMap<UserSignInVM, AppUser>().ReverseMap();
        
        }
    }
}
