using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
               .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmementId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameEn))
               .ForMember(dest => dest.StudId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
