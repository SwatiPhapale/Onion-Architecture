using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RepoProject.Core.DTOs;

namespace RepoProject.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);
        Task Create(T entity);


    }
}
