using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.MappingProfiles
{
    public class NotificationMaping:Profile
    {
        public NotificationMaping()
        {
            CreateMap<Notification, CreateNotification>().ReverseMap();
        }
    }
}
