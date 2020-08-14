using System;
using System.Collections.Generic;
using System.Text;

namespace RepoProject.Core.DTOs
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
    }
}
