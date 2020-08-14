using System;
using System.Collections.Generic;
using System.Text;

namespace RepoProject.Core.Entities
{
   public class JobDetails
    {
        public string JobId { get; set; }
        public string JobType { get; set; }
        public string JobDescription { get; set; }
        public DateTime JobDate { get; set; }
        public TimeSpan JobTime { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int NoOfRepo { get; set; }
    }
}
