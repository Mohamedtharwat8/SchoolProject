using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorsRepository : GenericRepositoryAsync<Instructor>, IInstructorsRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion

        #region Constructors
        public InstructorsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
