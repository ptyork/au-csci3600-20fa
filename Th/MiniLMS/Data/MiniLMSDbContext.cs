using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniLMS.Models;

namespace MiniLMS.Data
{
    public class MiniLMSDbContext : IdentityDbContext
    {
        public MiniLMSDbContext(DbContextOptions<MiniLMSDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}
