using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.MappingProfiles
{
    public class ProjectMaping:Profile
    {
        public ProjectMaping()
        {
            CreateMap<Project, CreateProject>().ReverseMap();
        }
    }
}
