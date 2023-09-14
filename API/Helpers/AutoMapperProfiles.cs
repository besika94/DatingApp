using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl,
                                opt => opt.MapFrom(
                                    src => src.Photos.FirstOrDefault(
                                         x => x.IsMain).Url))
                .ForMember(dest => dest.Age, 
                            opt => opt.MapFrom(
                                src => src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Message, MessageDto>()
                .ForMember(d => d.SenderPhotoUrl, 
                                o => o.MapFrom(
                                    src => src.Sender.Photos.FirstOrDefault(
                                        p => p.IsMain).Url))
                .ForMember(dest => dest.ReipientPhotoUrl, 
                                o => o.MapFrom(
                                    src => src.Recipient.Photos.FirstOrDefault(
                                        p => p.IsMain).Url));
        }
    }
}
