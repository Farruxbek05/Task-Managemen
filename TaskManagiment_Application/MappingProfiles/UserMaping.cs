using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.MappingProfiles
{
    public class UserMaping:Profile
    {
        public UserMaping()
        {
            CreateMap<User, CreateUser>().ReverseMap();
        }
    }
}
