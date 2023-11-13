using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataServices.DBModels;

public partial class PubsContext : DbContext
{
    public PubsContext()
    {
    }

    public PubsContext(DbContextOptions<PubsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:BookStore");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId }).HasName("UPKCL_sales");

            entity.ToTable("sales");

            entity.HasIndex(e => e.TitleId, "titleidind");

            entity.Property(e => e.StorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stor_id");
            entity.Property(e => e.OrdNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ord_num");
            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");
            entity.Property(e => e.OrdDate)
                .HasColumnType("datetime")
                .HasColumnName("ord_date");
            entity.Property(e => e.Payterms)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("payterms");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.Title).WithMany(p => p.Sales)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__title_id__4BAC3F29");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("UPKCL_titleidind");

            entity.ToTable("titles");

            entity.HasIndex(e => e.Title1, "titleind");

            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");
            entity.Property(e => e.Advance)
                .HasColumnType("money")
                .HasColumnName("advance");
            entity.Property(e => e.Notes)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pub_id");
            entity.Property(e => e.Pubdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("pubdate");
            entity.Property(e => e.Royalty).HasColumnName("royalty");
            entity.Property(e => e.Title1)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('UNDECIDED')")
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
