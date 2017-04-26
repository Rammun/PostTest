using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PostTest.Core.Entities;
using PostTest.Core.Models;

namespace PostTest.Core.Mapping.Profiles
{
    public class ViewModelToEntitylMappingProfile : Profile
    {
        public ViewModelToEntitylMappingProfile()
        {
            CreateMap<ParcelRegisterViewModel, Parcel>();

            CreateMap<MemberViewModel, Member>();
        }
    }
}
