using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchoolERP.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public int? ParentId { get; set; }
    }
}
