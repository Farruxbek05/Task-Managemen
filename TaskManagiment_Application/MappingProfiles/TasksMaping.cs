using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.MappingProfiles
{
    public class TasksMaping:Profile
    {
        public TasksMaping()
        {
            CreateMap<Tasks, CreateTasks>().ReverseMap();
        }
    }
}
