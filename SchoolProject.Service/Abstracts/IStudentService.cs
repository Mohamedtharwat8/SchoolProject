using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();

        public Task<Student> GetStudentByIDWithIncludeAsync(int id);

        public Task<Student> GetByIDAsync(int id);

        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameEnExist(string nameEn);

        public Task<string> EditAsync(Student student);

        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);

        public Task<string> DeleteAsync(Student student);


    }
}
