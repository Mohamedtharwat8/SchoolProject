using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region constructors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion
        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetStudentByIDWithIncludeAsync(int id)
        {
            // var student = await _studentRepository.GetByIdAsync(id);
            var student = _studentRepository.GetTableNoTracking()
                                          .Include(x => x.Department)
                                          .Where(x => x.StudId.Equals(id))
                                          .FirstOrDefault();
            return student;
        }



        public async Task<Student> GetByIDAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            //Added Student
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //Check if the name is Exist Or not
            var student = _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(nameEn)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }


        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepository.GetTableNoTracking()
                .Where(x => x.Name.Equals(nameEn) & !x.StudId.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                student.Address = "cairo";
                await _studentRepository.UpdateAsync(student);
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }

        }

        #endregion


    }
}
