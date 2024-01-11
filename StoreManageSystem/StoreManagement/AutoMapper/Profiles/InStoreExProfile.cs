using AutoMapper;
using StoreManagement.Model;

namespace StoreManagement.AutoMapper.Profiles
{
    public class InStoreExProfile:Profile
    {
        public InStoreExProfile()
        {
            CreateMap<InStore, InStoreEx>();
        }

    }
}
