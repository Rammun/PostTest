using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PostTest.Core.Entities;
using PostTest.Core.Models;

namespace PostTest.Core.Mapping.Profiles
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<Parcel, ParcelViewModel>()
                .ForMember(x => x.RecipientFullName, y => y.MapFrom(z => $"{z.Recipient.LastName} {z.Recipient.FirstName} {z.Recipient.Patronymic}"))
                .ForMember(x => x.SenderFullName, y => y.MapFrom(z => $"{z.Sender.LastName} {z.Sender.FirstName} {z.Sender.Patronymic}"))
                .ForMember(x => x.RecipientAdress, y => y.MapFrom(z => z.Recipient.Address))
                .ForMember(x => x.SenderAdress, y => y.MapFrom(z => z.Sender.Address));

            CreateMap<Member, MemberViewModel>();
        }
    }
}
