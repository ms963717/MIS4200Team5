using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MIS4200Team5.Models;

namespace MIS4200Team5.DAL
{
    public class ProfileContext : DbContext
    {
        public ProfileContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Profile> Profile { get; set; }

        public System.Data.Entity.DbSet<MIS4200Team5.Models.EmployeeQuestions> EmployeeQuestions { get; set; }
    }
}