﻿ 

namespace SchoolProject.Infrastructure.InfrastructureBases
{
    public interface IGenericRepositoryAsync<T> where T : class
    {

        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}