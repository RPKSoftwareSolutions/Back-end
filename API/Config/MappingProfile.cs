using AutoMapper;
using TKD.DomainModel.TKDModels;
using TKD.ReadModel.Contract;

namespace API.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SekaniLevel, SekaniLevelDto>().ReverseMap();

            CreateMap<EnglishWord, EnglishWordDto>().ReverseMap();

            CreateMap<SekaniCategory, SekaniCategoryDto>().ReverseMap();

            CreateMap<SekaniForm, SekaniFormDto>().ReverseMap();

            CreateMap<SekaniRoot, SekaniRootDto>().ReverseMap();

            CreateMap<SekaniRootEnglishWord, SekaniRootEnglishWordDto>().ReverseMap();

            CreateMap<SekaniRootImage, SekaniRootImageDto>().ReverseMap();
        
            CreateMap<SekaniRootTopic, SekaniRootTopicDto>().ReverseMap();

            CreateMap<SekaniWordAttribute, SekaniWordAttributeDto>().ReverseMap();

            CreateMap<SekaniWordAudio, SekaniWordAudioDto>().ReverseMap();

            CreateMap<SekaniWord, SekaniWordDto>().ReverseMap();

            CreateMap<SekaniWordExampleAudio, SekaniWordExampleAudioDto>().ReverseMap();

            CreateMap<SekaniWordExample, SekaniWordExampleDto>().ReverseMap();

            CreateMap<Topic, TopicDto>().ReverseMap();

            CreateMap<UserActivityStat, UserActivityStatDto>().ReverseMap();

            CreateMap<UserFailedWord, UserFailedWordDto>().ReverseMap();

            CreateMap<UserLearnedWord, UserLearnedWordDto>().ReverseMap();
        }

    }
}
