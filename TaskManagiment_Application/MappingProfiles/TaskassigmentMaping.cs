using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.MappingProfiles
{
    public class TaskassigmentMaping :Profile
    {
        public TaskassigmentMaping()
        {
            CreateMap<TaskAssignment, CreateTaskAssignment>().ReverseMap();
        }
    }
}
