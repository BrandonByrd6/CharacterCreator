using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CC.Data.Entities;

namespace CC.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    DbSet<CharacterEntity> Characters { get; set; } = null!;
    DbSet<FeatureEntity> Features { get; set; } = null!;
    public DbSet<TeamEntity> Teams { get; set; } = null!;

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);


    //     modelBuilder.Entity<UserEntity>().ToTable("Users");
    //     modelBuilder.Entity<PostEntity>().HasOne(n => n.Author).WithMany(u => u.Posts).HasForeignKey(n => n.AuthorId);
    //     modelBuilder.Entity<CommentEntity>().HasOne(n => n.Author).WithMany().HasForeignKey(n => n.AuthorId);
    //     modelBuilder.Entity<CommentEntity>().HasOne(n => n.Post).WithMany(u => u.Comments).HasForeignKey(n => n.PostId);
    //     modelBuilder.Entity<ReplyEntity>().HasOne(n => n.Author).WithMany().HasForeignKey(n => n.AuthorId);
    //     modelBuilder.Entity<ReplyEntity>().HasOne(n => n.Parent).WithMany().HasForeignKey(n => n.ParentId);
    //     modelBuilder.Entity<PostEntity>().HasOne(n => n.Author).HasForeignKey(n => n.AuthorId);
    // }

}