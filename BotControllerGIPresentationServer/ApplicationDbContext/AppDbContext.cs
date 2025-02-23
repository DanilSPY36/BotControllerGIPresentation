using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Models;

namespace  BotControllerGIPresentationServer.ApplicationDbContext;

public partial class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<BeanCategoriesDim> BeanCategoriesDims { get; set; }

    public virtual DbSet<BranchesDim> BranchesDims { get; set; }

    public virtual DbSet<CategoriesDim> CategoriesDims { get; set; }

    public virtual DbSet<CategoriesItemsDim> CategoriesItemsDims { get; set; }

    public virtual DbSet<ContainersDim> ContainersDims { get; set; }

    public virtual DbSet<HrPosition> HrPositions { get; set; }

    public virtual DbSet<HrpositionSpot> HrpositionSpots { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<KbjuTtk> KbjuTtks { get; set; }

    public virtual DbSet<MasterCategoriesDim> MasterCategoriesDims { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<RolesDim> RolesDims { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<SingleOrigin> SingleOrigins { get; set; }

    public virtual DbSet<SingleOriginTypesDim> SingleOriginTypesDims { get; set; }

    public virtual DbSet<SpotsDim> SpotsDims { get; set; }

    public virtual DbSet<Ttk> Ttks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersSpot> UsersSpots { get; set; }

    public virtual DbSet<VolumesDim> VolumesDims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("PresentationDB");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BeanCategoriesDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bean_category_dim_pk");

            entity.ToTable("bean_categories_dim", "single_origin_prod", tb => tb.HasComment("Линейка зерна (create, innovate, basse)"));

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.BeanCategory)
                .HasColumnType("character varying")
                .HasColumnName("bean_category");
        });

        modelBuilder.Entity<BranchesDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("branches_dim_pk");

            entity.ToTable("branches_dim", "statistic_prod");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Branch)
                .HasColumnType("character varying")
                .HasColumnName("branch");
        });

        modelBuilder.Entity<CategoriesDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_dim_pkey");

            entity.ToTable("categories_dim", "ttk_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Category)
                .HasColumnType("character varying")
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<CategoriesItemsDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_items_dim_pk");

            entity.ToTable("categories_items_dim", "shipper_prod");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasColumnType("character varying")
                .HasColumnName("category");
        });

        modelBuilder.Entity<ContainersDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("containers_dim_pkey");

            entity.ToTable("containers_dim", "ttk_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Container)
                .HasColumnType("character varying")
                .HasColumnName("container");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<HrPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hr_position_pkey");

            entity.ToTable("hr_position", "user_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<HrpositionSpot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hrposition_spots_pkey");

            entity.ToTable("hrposition_spots", "user_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.HrPositionId).HasColumnName("hr_position_id");
            entity.Property(e => e.Spotid).HasColumnName("spotid");

            entity.HasOne(d => d.HrPosition).WithMany(p => p.HrpositionSpots)
                .HasForeignKey(d => d.HrPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hrposition_spots_hr_position_id_fkey");

            entity.HasOne(d => d.Spot).WithMany(p => p.HrpositionSpots)
                .HasForeignKey(d => d.Spotid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hrposition_spots_spotid_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("items_pk");

            entity.ToTable("items", "shipper_prod");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Allergens)
                .HasColumnType("character varying")
                .HasColumnName("allergens");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Composition)
                .HasColumnType("character varying")
                .HasColumnName("composition");
            entity.Property(e => e.DairyFree).HasColumnName("dairy_free");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Energy).HasColumnName("energy");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("character varying")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.GlutenFree).HasColumnName("gluten_free");
            entity.Property(e => e.IsArchive).HasColumnName("is_archive");
            entity.Property(e => e.MasterCatLvl2Id).HasColumnName("master_cat_lvl_2_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Natural100).HasColumnName("natural100");
            entity.Property(e => e.PhotoPath)
                .HasColumnType("character varying")
                .HasColumnName("photo_path");
            entity.Property(e => e.Proteins).HasColumnName("proteins");
            entity.Property(e => e.ShipperId).HasColumnName("shipper_id");
            entity.Property(e => e.SoyaFree).HasColumnName("soya_free");
            entity.Property(e => e.StorageCond)
                .HasColumnType("character varying")
                .HasColumnName("storage_cond");
            entity.Property(e => e.SugarFree).HasColumnName("sugar_free");
            entity.Property(e => e.Vegan).HasColumnName("vegan");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("items_categories_items_dim_fk");

            entity.HasOne(d => d.MasterCatLvl2).WithMany(p => p.Items)
                .HasForeignKey(d => d.MasterCatLvl2Id)
                .HasConstraintName("items_master_categories_dim_fk");

            entity.HasOne(d => d.Shipper).WithMany(p => p.Items)
                .HasForeignKey(d => d.ShipperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("items_shippers_fk");
        });

        modelBuilder.Entity<KbjuTtk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("kbju_ttk_pkey");

            entity.ToTable("kbju_ttk", "ttk_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Caffeine).HasColumnName("caffeine");
            entity.Property(e => e.Caffeine100).HasColumnName("caffeine100");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Calories100).HasColumnName("calories100");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.Carbohydrates100).HasColumnName("carbohydrates100");
            entity.Property(e => e.Energy).HasColumnName("energy");
            entity.Property(e => e.Energy100).HasColumnName("energy100");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.Fats100).HasColumnName("fats100");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Proteins).HasColumnName("proteins");
            entity.Property(e => e.Proteins100).HasColumnName("proteins100");
            entity.Property(e => e.TtkId).HasColumnName("ttk_id");
            entity.Property(e => e.Variety)
                .HasColumnType("character varying")
                .HasColumnName("variety");
            entity.Property(e => e.VolumeId).HasColumnName("volume_id");

            entity.HasOne(d => d.Ttk).WithMany(p => p.KbjuTtks)
                .HasForeignKey(d => d.TtkId)
                .HasConstraintName("kbju_ttk_ttk_fk");

            entity.HasOne(d => d.Volume).WithMany(p => p.KbjuTtks)
                .HasForeignKey(d => d.VolumeId)
                .HasConstraintName("kbju_ttk_volumes_dim_fk");
        });

        modelBuilder.Entity<MasterCategoriesDim>(entity =>
        {
            entity.HasKey(e => e.IdLvl2).HasName("master_categories_pk");

            entity.ToTable("master_categories_dim", "master_cat_prod", tb => tb.HasComment("Категории первого и второго уровня"));

            entity.Property(e => e.IdLvl2)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_lvl_2");
            entity.Property(e => e.CategoryLvl1)
                .HasColumnType("character varying")
                .HasColumnName("category_lvl_1");
            entity.Property(e => e.CategoryLvl2)
                .HasColumnType("character varying")
                .HasColumnName("category_lvl_2");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("operations_pk");

            entity.ToTable("operations", "statistic_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.IsFake).HasColumnName("is_fake");
            entity.Property(e => e.IsSearch).HasColumnName("is_search");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.Operations)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operations_branches_dim_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.Operations)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operations_items_fk");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operations_single_origins_fk");

            entity.HasOne(d => d.Product1).WithMany(p => p.Operations)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operations_ttk_fk");
        });

        modelBuilder.Entity<RolesDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_dim_pkey");

            entity.ToTable("roles_dim", "user_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shippers_pk");

            entity.ToTable("shippers", "shipper_prod");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasColumnType("character varying")
                .HasColumnName("full_name");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Region)
                .HasColumnType("character varying")
                .HasColumnName("region");
        });

        modelBuilder.Entity<SingleOrigin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("single_origins_pk");

            entity.ToTable("single_origins", "single_origin_prod");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Acidity)
                .HasColumnType("character varying")
                .HasColumnName("acidity");
            entity.Property(e => e.Aftertaste)
                .HasColumnType("character varying")
                .HasColumnName("aftertaste");
            entity.Property(e => e.BeanCategoryId).HasColumnName("bean_category_id");
            entity.Property(e => e.Body)
                .HasColumnType("character varying")
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Flavor)
                .HasColumnType("character varying")
                .HasColumnName("flavor");
            entity.Property(e => e.Height)
                .HasColumnType("character varying")
                .HasColumnName("height");
            entity.Property(e => e.IsArchive).HasColumnName("is_archive");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Process)
                .HasColumnType("character varying")
                .HasColumnName("process");
            entity.Property(e => e.Q).HasColumnName("q");
            entity.Property(e => e.Region)
                .HasColumnType("character varying")
                .HasColumnName("region");
            entity.Property(e => e.Station)
                .HasColumnType("character varying")
                .HasColumnName("station");
            entity.Property(e => e.Taste)
                .HasColumnType("character varying")
                .HasColumnName("taste");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Variety)
                .HasColumnType("character varying")
                .HasColumnName("variety");

            entity.HasOne(d => d.BeanCategory).WithMany(p => p.SingleOrigins)
                .HasForeignKey(d => d.BeanCategoryId)
                .HasConstraintName("single_origins_bean_categories_dim_fk");

            entity.HasOne(d => d.Type).WithMany(p => p.SingleOrigins)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("single_origins_single_origin_types_dim_fk");
        });

        modelBuilder.Entity<SingleOriginTypesDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("single_origin_types_dim_pk");

            entity.ToTable("single_origin_types_dim", "single_origin_prod");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<SpotsDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("spots_dim_pkey");

            entity.ToTable("spots_dim", "user_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Region)
                .HasColumnType("character varying")
                .HasColumnName("region");
            entity.Property(e => e.SpotName)
                .HasColumnType("character varying")
                .HasColumnName("spot_name");
            entity.Property(e => e.Inn)
                    .HasColumnType("character varying")
                    .HasColumnName("inn"); 
            entity.Property(e => e.FullAdress)
                .HasColumnType("character varying")
                .HasColumnName("full_adress");
        });

        modelBuilder.Entity<Ttk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("drinks_ttk_pk");

            entity.ToTable("ttk", "ttk_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Additives)
                .HasColumnType("character varying")
                .HasColumnName("additives");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ContainerId).HasColumnName("container_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.HowToCook)
                .HasColumnType("character varying")
                .HasColumnName("how_to_cook");
            entity.Property(e => e.Ingridients)
                .HasColumnType("character varying")
                .HasColumnName("ingridients");
            entity.Property(e => e.IsArchive).HasColumnName("is_archive");
            entity.Property(e => e.KbjuId).HasColumnName("kbju_id");
            entity.Property(e => e.MasterCatLvl2Id).HasColumnName("master_cat_lvl_2_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PhotoPath)
                .HasColumnType("character varying")
                .HasColumnName("photo_path");
            entity.Property(e => e.Prep)
                .HasColumnType("character varying")
                .HasColumnName("prep");
            entity.Property(e => e.SpotId).HasColumnName("spot_id");
            entity.Property(e => e.VolumeId).HasColumnName("volume_id");
            entity.Property(e => e.Weight)
                .HasColumnType("character varying")
                .HasColumnName("weight");

            entity.HasOne(d => d.Category).WithMany(p => p.Ttks)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("ttk_categories_dim_fk");

            entity.HasOne(d => d.Container).WithMany(p => p.Ttks)
                .HasForeignKey(d => d.ContainerId)
                .HasConstraintName("ttk_containers_dim_fk");

            entity.HasOne(d => d.MasterCatLvl2).WithMany(p => p.Ttks)
                .HasForeignKey(d => d.MasterCatLvl2Id)
                .HasConstraintName("ttk_master_categories_dim_fk");

            entity.HasOne(d => d.Volume).WithMany(p => p.Ttks)
                .HasForeignKey(d => d.VolumeId)
                .HasConstraintName("ttk_volumes_dim_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users", "user_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.ChatId).HasColumnName("chat_id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.IsAccess).HasColumnName("is_access");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.MainSpotId).HasColumnName("main_spot_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Passwordhash)
                .HasColumnType("character varying")
                .HasColumnName("passwordhash");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.TgUserId).HasColumnName("tg_user_id");

            entity.HasOne(d => d.MainSpot).WithMany(p => p.Users)
                .HasForeignKey(d => d.MainSpotId)
                .HasConstraintName("users_spots_dim_fk");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_roles_dim_fk");
            entity.Property(e => e.HrPositionId).HasColumnName("hr_position_id");
            entity.HasOne(d => d.HrPosition) 
                .WithMany(p => p.Users) 
                .HasForeignKey(d => d.HrPositionId)
                .HasConstraintName("users_hr_position_fk");

        });

        modelBuilder.Entity<UsersSpot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_spots_pkey");

            entity.ToTable("users_spots", "user_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Spotid).HasColumnName("spotid");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Spot).WithMany(p => p.UsersSpots)
                .HasForeignKey(d => d.Spotid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_spots_spotid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UsersSpots)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_spots_user_id_fkey");
        });

        modelBuilder.Entity<VolumesDim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("volumes_dim_pkey");

            entity.ToTable("volumes_dim", "ttk_prod");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Volume)
                .HasColumnType("character varying")
                .HasColumnName("volume");
        });
        modelBuilder.HasSequence("categories_dim_id_seq", "ttk_prod");
        modelBuilder.HasSequence("containers_dim_id_seq", "ttk_prod");
        modelBuilder.HasSequence("hr_position_id_seq", "user_prod");
        modelBuilder.HasSequence("kbju_ttk_id_seq", "ttk_prod");
        modelBuilder.HasSequence("operations_id_seq", "statistic_prod").HasMax(2147483647L);
        modelBuilder.HasSequence("roles_dim_id_seq", "user_prod");
        modelBuilder.HasSequence("spots_dim_id_seq", "user_prod");
        modelBuilder.HasSequence("ttk_id_seq", "ttk_prod");
        modelBuilder.HasSequence("users_id_seq", "user_prod");
        modelBuilder.HasSequence("volumes_dim_id_seq", "ttk_prod");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
