#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Online_store.Models;

namespace Online_store.Data;

public partial class OnlineStoreContext : DbContext
{
    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<CityModel> Cities { get; set; }

    public virtual DbSet<CountryModel> Countries { get; set; }

    public virtual DbSet<OrderModel> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<ProductModel> Products { get; set; }

    public virtual DbSet<StateModel> States { get; set; }

    public virtual DbSet<TransactionModel> Transactions { get; set; }

    public virtual DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1B0187F84A");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.StreetAddress)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Addresses__CityI__17F790F9");
        });

        modelBuilder.Entity<CityModel>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A96D950DD61");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cities__StateID__151B244E");
        });

        modelBuilder.Entity<CountryModel>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BFDD37CFBC");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderModel>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF21985CE9");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__UserID__208CD6FA");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A13987C306");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__236943A5");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__245D67DE");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED24BBE59F");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<StateModel>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__States__C3BA3B5AB91242D4");

            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.StateName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__States__CountryI__123EB7A3");
        });

        modelBuilder.Entity<TransactionModel>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B304EA347");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Order__2739D489");
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC85C18997");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.BillingAddressId).HasColumnName("BillingAddressID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddressID");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.UserBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__BillingAd__1BC821DD");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.UserShippingAddresses)
                .HasForeignKey(d => d.ShippingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__ShippingA__1AD3FDA4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}