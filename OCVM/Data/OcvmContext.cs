using Microsoft.EntityFrameworkCore;
using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data
{
    public class OcvmContext : DbContext
    {
        public OcvmContext(DbContextOptions<OcvmContext> options):base(options)
        {

        }
        public virtual DbSet<PersonalDetail> PersonalDetail { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<Contact>  Contacts { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<PersonalDetail>()
        //        .HasOne(b => b.PersonalID)
        //        .WithMany()
        //        .HasForeignKey(a => a.PersonalID);

           

        //    base.OnModelCreating(builder);
        //}
    }
    
}
