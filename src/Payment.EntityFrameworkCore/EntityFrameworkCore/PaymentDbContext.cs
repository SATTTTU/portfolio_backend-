using Microsoft.EntityFrameworkCore;
using Payment.Entities;
using System.Collections.Generic;
using System.Text.Json;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Payment.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class PaymentDbContext :
    AbpDbContext<PaymentDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Entities.Overview> Overviews { get; set; }
    public DbSet<Entities.Skills> Skills { get; set; }
    public DbSet<Entities.Projects> Projects { get; set; }
    public DbSet<Working> Workings { get; set; }
    public DbSet<WorkingDescription> WorkingDescriptions { get; set; }
    public DbSet<Visitor> Visitors { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        
        builder.Entity<Entities.Overview>(builder =>
        {
            builder.ToTable(PaymentConsts.DbTablePrefix + "Overviews", PaymentConsts.DbSchema);
            builder.ConfigureByConvention(); //auto configure for the base class props
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.ImageUrl);
                   
        
                                        //...
        });
        builder.Entity<Working>(builder =>
        {
            builder.ToTable(PaymentConsts.DbTablePrefix + "Workings", PaymentConsts.DbSchema);
            builder.ConfigureByConvention();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasMany(w => w.Descriptions)
                .WithOne()
                .HasForeignKey("WorkingId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(w => w.Descriptions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.StartedAt).IsRequired();
            builder.Property(x => x.LeftAt);
            builder.Property(x => x.IsWorking).IsRequired();
            builder.Property(x => x.WorkedAt)
                .IsRequired()
                .HasMaxLength(200);
        });
        builder.Entity<WorkingDescription>(builder =>
        {
              builder.ToTable("WorkingDescription", "public");

            builder.ConfigureByConvention();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Value)
                   .IsRequired()
                   .HasMaxLength(500);
        });
        builder.Entity<Entities.Skills>(builder =>
        {
            builder.ToTable(PaymentConsts.DbTablePrefix + "Skills", PaymentConsts.DbSchema);
            builder.ConfigureByConvention();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.ImageUrl);
        });

        builder.Entity<Entities.Projects>(builder =>
        {
            builder.ToTable(PaymentConsts.DbTablePrefix + "Projects", PaymentConsts.DbSchema);
            builder.ConfigureByConvention();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.ProjectUrl);
            builder.Property(x => x.GithubUrl);
        });
        builder.Entity<Visitor>(b =>
        {
            b.ToTable(PaymentConsts.DbTablePrefix + "Visitors", PaymentConsts.DbSchema);
            b.ConfigureByConvention();


            b.Property(x => x.Identity)
            .IsRequired()
            .HasMaxLength(100);


            b.HasIndex(x => x.Identity).IsUnique();
        });
    }
}
