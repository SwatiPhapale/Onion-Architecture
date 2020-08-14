using RepoProject.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepoProject.Services.Interface
{
   public interface IJobService
    {
        IEnumerable<AddJobDetails> GetAll();
        AddJobDetails GetById(int Id);
        Task Create(AddJobDetails addJobDetails);
    }
}
