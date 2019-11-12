﻿using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext() : base("name=DefaultConnection")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieStoreDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public Task<int> CommitAsync()
        {
            try
            {
                return base.SaveChangesAsync();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCast> ProjectCasts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
