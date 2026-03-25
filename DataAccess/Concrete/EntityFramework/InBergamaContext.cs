using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class InBergamaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PC\\ALı;Database=inbergama;Integrated Security=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            //var connectionString =
            //"server=nufusistatistikleri.online;" +
            //"database=u407062882_QrMenu;" +
            //"user=u407062882_admin;" +
            //"password=Admin.9674;";

            //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }


        public DbSet<User> Users{ get; set; }   
        public DbSet<Business> Businesses{ get; set; }
        public DbSet<Advertising> Advertisings { get; set; }

        public DbSet<BusinessCategory> BusinessCategories { get; set; }

        public DbSet<BusinessPhoto> BusinessPhotos{ get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Comment> Comments{ get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Influencer> Influencers{ get; set; }

        public DbSet<JobPosting> JobPostings{ get; set; }

        public DbSet<Service> Services{ get; set; }


        public DbSet<Vacation> Vacations{ get; set; }

        public DbSet<VacationPhoto> VacationPhotos{ get; set; }

        //yetki
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }




    }
}
