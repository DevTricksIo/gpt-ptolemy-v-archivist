using ConsoleArchivist.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleArchivist.Database;

public class ArchivistDbContext : DbContext
{
    private static readonly ArchivistDbContext _single = new();

    public static ArchivistDbContext Instance => _single;

    public DbSet<Translation> Translations { get; set; }

    public string DbPath { get; }

    private ArchivistDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "translations.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite($"Data Source={DbPath}");

        base.OnConfiguring(optionsBuilder);
    }
}
