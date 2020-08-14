using RepoProject.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepoProject.Services.JobServices
{
    public interface IJobService
    {
         IEnumerable<AddJobDetails> GetAll();
        public AddJobDetails GetById(int Id);
        public Task Create(AddJobDetails addJobDetails);
    }
}
