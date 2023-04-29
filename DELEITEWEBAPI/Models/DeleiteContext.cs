using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DELEITEWEBAPI.Models
{
    public partial class DeleiteContext : DbContext
    {
        public DeleiteContext()
        {
        }

        public DeleiteContext(DbContextOptions<DeleiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Billing> Billings { get; set; } = null!;
        public virtual DbSet<BillingDetail> BillingDetails { get; set; } = null!;
        public virtual DbSet<Buy> Buys { get; set; } = null!;
        public virtual DbSet<BuyDeatil> BuyDeatils { get; set; } = null!;
        public virtual DbSet<Deal> Deals { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemTipe> ItemTipes { get; set; } = null!;
        public virtual DbSet<MethodPage> MethodPages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=STEVENVR;DATABASE=Deleite;INTEGRATED SECURITY=TRUE;User Id=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billing>(entity =>
            {
                entity.ToTable("Billing");

                entity.Property(e => e.BillingId).HasColumnName("BillingID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.IdbillingDetail).HasColumnName("IDBillingDetail");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.IdbillingDetailNavigation)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.IdbillingDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBilling918677");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBilling859720");
            });

            modelBuilder.Entity<BillingDetail>(entity =>
            {
                entity.HasKey(e => e.IdbillingDetail)
                    .HasName("PK__BillingD__930351EEEB5DB560");

                entity.ToTable("BillingDetail");

                entity.Property(e => e.IdbillingDetail).HasColumnName("IDBillingDetail");

                entity.Property(e => e.Discount).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Iva).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.MethodPageId).HasColumnName("MethodPageID");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.MethodPage)
                    .WithMany(p => p.BillingDetails)
                    .HasForeignKey(d => d.MethodPageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBillingDet575714");
            });

            modelBuilder.Entity<Buy>(entity =>
            {
                entity.ToTable("Buy");

                entity.Property(e => e.BuyId).HasColumnName("BuyID");

                entity.Property(e => e.Activa)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BuyDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BuyNote)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBuy353718");
            });

            modelBuilder.Entity<BuyDeatil>(entity =>
            {
                entity.HasKey(e => new { e.BuyBuyId, e.ItemItemId })
                    .HasName("PK__BuyDeati__4C93AFBA4E530C93");

                entity.ToTable("BuyDeatil");

                entity.Property(e => e.BuyBuyId).HasColumnName("BuyBuyID");

                entity.Property(e => e.ItemItemId).HasColumnName("ItemItemID");

                entity.Property(e => e.Priceunit)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("priceunit");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.BuyBuy)
                    .WithMany(p => p.BuyDeatils)
                    .HasForeignKey(d => d.BuyBuyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBuyDeatil285004");

                entity.HasOne(d => d.ItemItem)
                    .WithMany(p => p.BuyDeatils)
                    .HasForeignKey(d => d.ItemItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBuyDeatil106771");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.DealsId)
                    .HasName("PK__Deals__48275EDC3D02A6E7");

                entity.Property(e => e.DealsId).HasColumnName("DealsID");

                entity.Property(e => e.BuyId).HasColumnName("BuyID");

                entity.Property(e => e.Descount).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Descrption)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Buy)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.BuyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDeals85458");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.IdbillingDetail).HasColumnName("IDBillingDetail");

                entity.Property(e => e.ItemTapeId).HasColumnName("ItemTapeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Qr)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QR");

                entity.HasOne(d => d.IdbillingDetailNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdbillingDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItem517048");

                entity.HasOne(d => d.ItemTape)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTapeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItem52840");
            });

            modelBuilder.Entity<ItemTipe>(entity =>
            {
                entity.HasKey(e => e.ItemTapeId)
                    .HasName("PK__ItemTipe__BB328DAA2FB1EF8C");

                entity.ToTable("ItemTipe");

                entity.Property(e => e.ItemTapeId).HasColumnName("ItemTapeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MethodPage>(entity =>
            {
                entity.ToTable("MethodPage");

                entity.Property(e => e.MethodPageId).HasColumnName("MethodPageID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser854768");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser943402");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
