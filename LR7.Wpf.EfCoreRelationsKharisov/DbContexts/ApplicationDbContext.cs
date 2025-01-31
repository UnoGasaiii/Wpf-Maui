using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Microsoft.EntityFrameworkCore;
using LR7.Wpf.EfCoreRelationsKharisov.Entities;

namespace LR7.Wpf.EfCoreRelationsKharisov.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<UserRoles> UserRoles { get; set; } = null!;

        public DbSet<Note> Notes { get; set; } = null!;

        public DbSet<Permission> Permissions { get; set; } = null!;

        public DbSet<RolePermissions> RolePermissions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(usersConfiguration =>
            {
                usersConfiguration.HasKey(p => p.Id);
                usersConfiguration.HasIndex(p => p.Login).IsUnique().HasPrefixLength(32);

                usersConfiguration.HasMany(u => u.Roles).WithMany(u => u.Users).UsingEntity<UserRoles>(
                                                                                                       l => l.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                                                                                                       r => r.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId));

                usersConfiguration.HasMany(n => n.Notes).WithOne(u => u.User);
            });

            modelBuilder.Entity<Role>(rolesConfiguration =>
            {
                rolesConfiguration.HasKey(p => p.Id);
                rolesConfiguration.HasIndex(p => p.Title).IsUnique().HasPrefixLength(32);
                rolesConfiguration.HasIndex(p => p.Description).HasPrefixLength(512);

                rolesConfiguration.HasMany(u => u.Users).WithMany(u => u.Roles).UsingEntity<UserRoles>(
                                                                                                        l => l.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId),
                                                                                                        r => r.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId));

                rolesConfiguration.HasMany(p => p.Permissions).WithMany(r => r.Roles).UsingEntity<RolePermissions>(
                                                                                                        l => l.HasOne(ur => ur.Permission).WithMany().HasForeignKey(ur => ur.PermissionsId),
                                                                                                        r => r.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId));
            });

            modelBuilder.Entity<Note>(notesConfiguration =>
            {
                notesConfiguration.HasKey(n => n.Id);
                notesConfiguration.HasIndex(n => n.Title).IsUnique().HasPrefixLength(32);
                notesConfiguration.HasIndex(n => n.Description).HasPrefixLength(512);

                notesConfiguration.HasOne(u => u.User).WithMany(n => n.Notes).HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<Permission>(permissionConfiguration =>
            {
                permissionConfiguration.HasKey(p => p.Id);
                permissionConfiguration.HasIndex(p => p.Title).IsUnique().HasPrefixLength(32);
                permissionConfiguration.HasIndex(p => p.Description).HasPrefixLength(512);

                permissionConfiguration.HasMany(r => r.Roles).WithMany(p => p.Permissions).UsingEntity<RolePermissions>(
                                                                                                        l => l.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                                                                                                        r => r.HasOne(ur => ur.Permission).WithMany().HasForeignKey(ur => ur.PermissionsId));
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=!Dang2237.;database=LR7;", new MySqlServerVersion(new Version(8, 0, 40)));
        }
    }
}

