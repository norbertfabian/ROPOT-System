﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TestScheme> TestSchemes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Test> Tests { get; set; }
        public AppDbContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());
        }
    }
}
