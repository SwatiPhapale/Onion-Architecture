using RepoProject.Core.DTOs;
using RepoProject.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepoProject.Services.JobServices
{
    public class JobService : IJobService
    {
        private IRepository<AddJobDetails> _repository;

        public JobService(IRepository<AddJobDetails> repository)
        {
            _repository = repository;
        }

        public IEnumerable<AddJobDetails> GetAll()
        {
            return _repository.GetAll();
        }

        public AddJobDetails GetById(int Id)
        {
            return _repository.GetById(Id);
        }

        public async Task Create(AddJobDetails addJobDetails)
        {
            await _repository.Create(addJobDetails);
        }
    }
}
