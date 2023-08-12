using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace main6project.Models;

public partial class Main4projectContext : DbContext
{
    public Main4projectContext()
    {
    }

    public Main4projectContext(DbContextOptions<Main4projectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citytable> Citytables { get; set; }

    public virtual DbSet<Maintable> Maintables { get; set; }

    public virtual DbSet<Provinetable> Provinetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-18OOV1I;Database=main4project;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
