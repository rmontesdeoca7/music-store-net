using AutoMapper;
using MusicStore.Dto.Request;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services.Profiles
{
    public class ConcertProfile: Profile
    {
        public ConcertProfile()
        {
            CreateMap<ConcertDtoRequest, Concert>()
                .ForMember(destino => destino.GenderId, origen => origen.MapFrom(x => x.IdGender))
                .ForMember(destino => destino.Title, origen => origen.MapFrom(x => x.Title))
                .ForMember(destino => destino.Description, origen => origen.MapFrom(x => x.Description))
                .ForMember(destino => destino.TicketsQuantity, origen => origen.MapFrom(x => x.TicketsQuantity))
                .ForMember(destino => destino.UnitPrice, origen => origen.MapFrom(x => x.UnitPrice))
                .ForMember(destino => destino.Place, origen => origen.MapFrom(x => x.Place));
                
        }
    }
}
