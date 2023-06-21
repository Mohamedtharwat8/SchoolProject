using AutoMapper; 
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results; 
using SchoolProject.Service.Abstracts; 

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler 
        : ResponseHandler, 
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>

    {

        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }



        #endregion

        #region Handle Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }


        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIDWithIncludeAsync(request.Id);
            if (student == null) 
                return NotFound<GetSingleStudentResponse>
                    ("NotFound");
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }






        #endregion
    }
}
