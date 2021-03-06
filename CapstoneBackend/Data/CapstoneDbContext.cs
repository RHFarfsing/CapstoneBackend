﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapstoneBackend.Models;

namespace CapstoneBackend.Data {
    public class CapstoneDbContext : DbContext {
        public CapstoneDbContext(DbContextOptions<CapstoneDbContext> options)
            : base(options) {
        }

        public CapstoneDbContext() {
        }

        public DbSet<CapstoneBackend.Models.Request> Request { get; set; }
        public DbSet<CapstoneBackend.Models.Product> Product { get; set; }
        public DbSet<CapstoneBackend.Models.User> User { get; set; }
        public DbSet<CapstoneBackend.Models.Vendor> Vendor { get; set; }
        public DbSet<CapstoneBackend.Models.RequestLine> RequestLine { get; set; }

        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>(e => {
                e.ToTable("Users");
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).HasMaxLength(30).IsRequired();
                e.Property(x => x.Password).HasMaxLength(30).IsRequired();
                e.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.Property(x => x.IsReviewer).HasDefaultValue(0);
                e.Property(x => x.IsAdmin).HasDefaultValue(0);
                e.HasIndex(x => x.Username).IsUnique();
            });
            model.Entity<Vendor>(e => {
                e.ToTable("Vendors");
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Address).HasMaxLength(30).IsRequired();
                e.Property(x => x.City).HasMaxLength(30).IsRequired();
                e.Property(x => x.State).HasMaxLength(2).IsRequired();
                e.Property(x => x.Zip).HasMaxLength(5).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(225);
                e.HasIndex(x => x.Code).IsUnique();
            });
            model.Entity<Product>(e => {
                e.ToTable("Products");
                e.HasKey(x => x.Id);
                e.Property(x => x.PartNbr).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price).HasColumnType("decimal(11,2)");
                e.Property(x => x.Unit).HasMaxLength(30).IsRequired();
                //e.Property(x => x.PhotoPath).HasMaxLength(225);
                e.HasOne(x => x.Vendor).WithMany(x => x.Products).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Restrict);
            });
            model.Entity<Request>(e => {
                e.ToTable("Requests");
                e.HasKey(x => x.Id);
                e.Property(x => x.Description).HasMaxLength(80).IsRequired();
                e.Property(x => x.Justification).HasMaxLength(80).IsRequired();
                e.Property(x => x.RejectionReason).HasMaxLength(80);
                e.Property(x => x.DeliveryMode).HasMaxLength(20).IsRequired().HasDefaultValue("Pickup");
                e.Property(x => x.Status).HasMaxLength(10).IsRequired().HasDefaultValue("New");
                e.Property(x => x.Total).HasColumnType("decimal(11,2)").HasDefaultValue(0);
                e.HasOne(x => x.User).WithMany(x => x.Requests).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            });
            model.Entity<RequestLine>(e => {
                e.ToTable("Requestlines");
                e.HasKey(x => x.Id);
                e.Property(x => x.Quantity).HasDefaultValue(1);
                e.HasOne(x => x.Product).WithMany(x => x.RequestLines).HasForeignKey(x => x.ProductId);
                e.HasOne(x => x.Request).WithMany(x => x.RequestLines).HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
