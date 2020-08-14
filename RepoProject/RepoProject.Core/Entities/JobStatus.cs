using System;
using System.Collections.Generic;
using System.Text;

namespace RepoProject.Core.Entities
{
  public  class JobStatus
    {
        public int EmployeeId { get; set; }
        public string JobId { get; set; }
        public string Rego { get; set; }
        public string JobState { get; set; }
        public string JobRequest { get; set; }
        public string LeadRepo { get; set; }
        public string DropoffImages { get; set; }

        public virtual User Id { get; set; }
        public virtual JobDetails Job { get; set; }
        public virtual CarDetails RegoNavigation { get; set; }
    }
}
