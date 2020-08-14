using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoProject.Core.DTOs;
using RepoProject.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class JobController : ControllerBase
    {
        private readonly IJobService _repo;
        public JobController(IJobService repo)
        {
            _repo = repo;
        }
        [HttpGet("GetJobDetails")]
        public IActionResult GetJobDetails()
        {
            var jobDetails = _repo.GetAll();
            return Ok(jobDetails);
        }

        [HttpPost("AddJobDetails")]
        public IActionResult AddJobDetails(AddJobDetails addJobDetails)
        {
            var jobDetails = _repo.Create(addJobDetails);
            return Ok(jobDetails);
        }
    }
}
