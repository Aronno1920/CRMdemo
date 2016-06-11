using CRM.Data.Configuration;
using CRM.Entity.Authentication;
using CRM.Entity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class CRMEntities : IdentityDbContext<ApplicationUser, ApplicationRole,
        string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public CRMEntities()
            : base("CRMEntities")
        {
        }

        static CRMEntities()
        {
            Database.SetInitializer<CRMEntities>(new CRMSeedData());
        }

        public static CRMEntities Create()
        {
            return new CRMEntities();
        }

        // Add the ApplicationGroups property:
        public virtual IDbSet<ApplicationGroup> ApplicationGroups { get; set; }
        // Add the ApplicationUsers property:
        //public virtual IDbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        //public CRMEntities() : base("CRMEntities") {
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CRMEntities>());
        //}

        public DbSet<CountryEntity> Countrys { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }
        public DbSet<ContactTypeEntity> ContactTypes { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ChannelTypeEntity> ChannelTypes { get; set; }
        public DbSet<CityEntity> Citys { get; set; }
        public DbSet<CityTypeEntity> CityTypes { get; set; }
        public DbSet<CurrentOutcomeCodeEntity> CurrentOutcomeCode { get; set; }
        public DbSet<FlightRouteCategoryEntity> FlightRouteCategorys { get; set; }
        public DbSet<FlightRouteEntity> FlightRoutes { get; set; }
        public DbSet<InteractionEntity> Interactions { get; set; }
        public DbSet<PriorityEntity> Prioritys { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategorys { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductTypeEntity> ProductTypes { get; set; }
        public DbSet<ServiceAdditionalDetailEntity> ServiceAdditionalDetails { get; set; }
        public DbSet<ServiceCenterEntity> ServiceCenters { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<ServiceStatusEntity> ServiceStatuses { get; set; }
        public DbSet<ServiceSupplementalDetailEntity> ServiceSupplementalDetails { get; set; }
        public DbSet<ServiceTypeDetailEntity> ServiceTypeDetails { get; set; }
        public DbSet<ServiceTypeEntity> ServiceTypes { get; set; }
        public DbSet<StationEntity> Stations { get; set; }
        public DbSet<StationCategoryEntity> StationCategorys { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //  modelBuilder.Entity<ApplicationUserLogin>().HasKey(l => new { l.UserId,l.LoginProvider,l.ProviderKey });
            //  modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            // modelBuilder.Entity<ApplicationUserLogin>().HasKey(l =>  l.UserId, l => l.LoginProvider, l => l.ProviderKey );
            // modelBuilder.Entity<ApplicationUserRole>().HasKey(r =>  r.RoleId, r => r.UserId );
            modelBuilder.Entity<ApplicationUserRole>()
            .HasKey(r => new { r.UserId, r.RoleId })
            .ToTable("ApplicationUserRoles");

            modelBuilder.Entity<ApplicationUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("ApplicationUserLogins");
            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithRequired().HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
            modelBuilder.Entity<ApplicationUserGroup>()
                .HasKey((ApplicationUserGroup r) =>
                    new
                    {
                        ApplicationUserId = r.ApplicationUserId,
                        ApplicationGroupId = r.ApplicationGroupId
                    }).ToTable("ApplicationUserGroups");

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithRequired().HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
            modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
                new
                {
                    ApplicationRoleId = gr.ApplicationRoleId,
                    ApplicationGroupId = gr.ApplicationGroupId
                }).ToTable("ApplicationGroupRoles");

            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new TitleConfiguration());
            modelBuilder.Configurations.Add(new ContactTypeConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ChannelTypeConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CityTypeConfiguration());
            modelBuilder.Configurations.Add(new CurrentOutcomeCodeConfiguration());
            modelBuilder.Configurations.Add(new FlightRouteCategoryConfiguration());
            modelBuilder.Configurations.Add(new FlightRouteConfiguration());
            modelBuilder.Configurations.Add(new InteractionConfiguration());
            modelBuilder.Configurations.Add(new PriorityConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new ServiceAdditionalDetailConfiguration());
            modelBuilder.Configurations.Add(new ServiceCenterConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new ServiceStatusConfiguration());
            modelBuilder.Configurations.Add(new ServiceSupplementalDetailConfiguration());
            modelBuilder.Configurations.Add(new ServiceTypeDetailConfiguration());
            modelBuilder.Configurations.Add(new ServiceTypeConfiguration());
            modelBuilder.Configurations.Add(new StationConfiguration());
            modelBuilder.Configurations.Add(new StationCategoryConfiguration());

        }
    }
}
