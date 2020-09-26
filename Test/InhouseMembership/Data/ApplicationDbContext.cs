﻿using System;
using System.Collections.Generic;
using System.Text;
using InhouseMembership.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static InhouseMembership.Models.Schedule;

namespace InhouseMembership.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Enrollment>()
        //        .HasKey(t => new { t.ScheduleId, t.MemberId });

        //    modelBuilder.Entity<Enrollment>()
        //        .HasOne(pt => pt.Schedule)
        //        .WithMany(p => p.Enrollments)
        //        .HasForeignKey(pt => pt.ScheduleId);

        //    modelBuilder.Entity<Enrollment>()
        //        .HasOne(pt => pt.Member)
        //        .WithMany(t => t.Enrollments)
        //        .HasForeignKey(pt => pt.TagId);
        //}
    }
}
