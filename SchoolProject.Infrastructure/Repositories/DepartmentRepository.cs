﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            departments = dbContext.Set<Department>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
