using System;
using System.Collections.Generic;
using System.Globalization;
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
            CreateMap<ParcelRegisterViewModel, Parcel>()
                .ForMember(x => x.Weight, y => y.MapFrom(z => ToDouble(z.Weight)));

            CreateMap<MemberViewModel, Member>();
        }

        private double ToDouble(string param)
        {
            double temp;
            double.TryParse(param.Replace(',','.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out temp);
            return temp;
        }
    }
}
