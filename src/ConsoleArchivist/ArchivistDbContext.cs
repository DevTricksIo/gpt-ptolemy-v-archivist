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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>().HasData(
            new Translation { Id = 1, Name = "Árabe - Arab" },
            new Translation { Id = 2, Name = "Armênio - Armn" },
            new Translation { Id = 3, Name = "Assamês - Beng" },
            new Translation { Id = 4, Name = "Azeri (Latim) - Latn" },
            new Translation { Id = 5, Name = "Azeri (Cirílico) - Cyrl" },
            new Translation { Id = 6, Name = "Basco - Latn" },
            new Translation { Id = 7, Name = "Bielorrusso - Cyrl" },
            new Translation { Id = 8, Name = "Bengali - Beng" },
            new Translation { Id = 9, Name = "Búlgaro - Cyrl" },
            new Translation { Id = 10, Name = "Birmanês - Mymr" },
            new Translation { Id = 11, Name = "Catalão - Latn" },
            new Translation { Id = 12, Name = "Cherokee - Cher" },
            new Translation { Id = 13, Name = "Chinês (Simplificado) - Hans" },
            new Translation { Id = 14, Name = "Chinês (Tradicional) - Hant" },
            new Translation { Id = 15, Name = "Copta - Copt" },
            new Translation { Id = 16, Name = "Croata - Latn" },
            new Translation { Id = 17, Name = "Tcheco - Latn" },
            new Translation { Id = 18, Name = "Dinamarquês - Latn" },
            new Translation { Id = 19, Name = "Divehi - Thaa" },
            new Translation { Id = 20, Name = "Holandês - Latn" },
            new Translation { Id = 21, Name = "Inglês - Latn" },
            new Translation { Id = 22, Name = "Esperanto - Latn" },
            new Translation { Id = 23, Name = "Estoniano - Latn" },
            new Translation { Id = 24, Name = "Éwé - Latn" },
            new Translation { Id = 25, Name = "Faroês - Latn" },
            new Translation { Id = 26, Name = "Filipino - Latn" },
            new Translation { Id = 27, Name = "Finlandês - Latn" },
            new Translation { Id = 28, Name = "Francês - Latn" },
            new Translation { Id = 29, Name = "Frísio - Latn" },
            new Translation { Id = 30, Name = "Gaélico (Escocês) - Latn" },
            new Translation { Id = 31, Name = "Georgiano - Geor" },
            new Translation { Id = 32, Name = "Alemão - Latn" },
            new Translation { Id = 33, Name = "Grego - Grek" },
            new Translation { Id = 34, Name = "Groenlandês - Latn" },
            new Translation { Id = 35, Name = "Gujarati - Gujr" },
            new Translation { Id = 36, Name = "Hausa - Latn" },
            new Translation { Id = 37, Name = "Hebraico - Hebr" },
            new Translation { Id = 38, Name = "Hindi - Deva" },
            new Translation { Id = 39, Name = "Húngaro - Latn" },
            new Translation { Id = 40, Name = "Islandês - Latn" },
            new Translation { Id = 41, Name = "Igbo - Latn" },
            new Translation { Id = 42, Name = "Indonésio - Latn" },
            new Translation { Id = 43, Name = "Irlandês - Latn" },
            new Translation { Id = 44, Name = "Italiano - Latn" },
            new Translation { Id = 45, Name = "Japonês - Jpan (abrangendo Kanji, Hiragana, Katakana)" },
            new Translation { Id = 46, Name = "Javanês (Latim) - Latn" },
            new Translation { Id = 47, Name = "Kannada - Knda" },
            new Translation { Id = 48, Name = "Cazaque (Cirílico) - Cyrl" },
            new Translation { Id = 49, Name = "Cazaque (Latim) - Latn" },
            new Translation { Id = 50, Name = "Khmer - Khmr" },
            new Translation { Id = 51, Name = "Coreano - Hang" },
            new Translation { Id = 52, Name = "Curdo (Latim) - Latn" },
            new Translation { Id = 53, Name = "Quirguiz (Cirílico) - Cyrl" },
            new Translation { Id = 54, Name = "Lao - Laoo" },
            new Translation { Id = 55, Name = "Latim - Latn" },
            new Translation { Id = 56, Name = "Letão - Latn" },
            new Translation { Id = 57, Name = "Lituano - Latn" },
            new Translation { Id = 58, Name = "Macedônio - Cyrl" },
            new Translation { Id = 59, Name = "Malaiala - Mlym" },
            new Translation { Id = 60, Name = "Malaio (Latim) - Latn" },
            new Translation { Id = 61, Name = "Malaio (Árabe) - Arab" },
            new Translation { Id = 62, Name = "Maldiviano - Thaa" },
            new Translation { Id = 63, Name = "Maltês - Latn" },
            new Translation { Id = 64, Name = "Maori - Latn" },
            new Translation { Id = 65, Name = "Marathi - Deva" },
            new Translation { Id = 66, Name = "Mongol (Cirílico) - Cyrl" },
            new Translation { Id = 67, Name = "Nepalês - Deva" },
            new Translation { Id = 68, Name = "Norueguês - Latn" },
            new Translation { Id = 69, Name = "Oriya - Orya" },
            new Translation { Id = 70, Name = "Oromo - Latn" },
            new Translation { Id = 71, Name = "Pashto - Arab" },
            new Translation { Id = 72, Name = "Persa - Arab" },
            new Translation { Id = 73, Name = "Polonês - Latn" },
            new Translation { Id = 74, Name = "Português - Latn" },
            new Translation { Id = 75, Name = "Punjabi (Gurmukhi) - Guru" },
            new Translation { Id = 76, Name = "Punjabi (Árabe) - Arab" },
            new Translation { Id = 77, Name = "Romeno - Latn" },
            new Translation { Id = 78, Name = "Russo - Cyrl" },
            new Translation { Id = 79, Name = "Sânscrito - Deva" },
            new Translation { Id = 80, Name = "Sérvio (Latim) - Latn" },
            new Translation { Id = 81, Name = "Sindhi - Arab" },
            new Translation { Id = 82, Name = "Cingalês - Sinh" },
            new Translation { Id = 83, Name = "Eslovaco - Latn" },
            new Translation { Id = 84, Name = "Esloveno - Latn" },
            new Translation { Id = 85, Name = "Somali - Latn" },
            new Translation { Id = 86, Name = "Espanhol - Latn" },
            new Translation { Id = 87, Name = "Suaíli - Latn" },
            new Translation { Id = 88, Name = "Sueco - Latn" },
            new Translation { Id = 89, Name = "Tâmil - Taml" },
            new Translation { Id = 90, Name = "Tártaro (Cirílico) - Cyrl" },
            new Translation { Id = 91, Name = "Telugu - Telu" },
            new Translation { Id = 92, Name = "Tailandês - Thai" },
            new Translation { Id = 93, Name = "Tibetano - Tibt" },
            new Translation { Id = 94, Name = "Tigrinya - Ethi" },
            new Translation { Id = 95, Name = "Turco - Latn" },
            new Translation { Id = 96, Name = "Turcomano (Latim) - Latn" },
            new Translation { Id = 97, Name = "Ucraniano - Cyrl" },
            new Translation { Id = 98, Name = "Urdu - Arab" },
            new Translation { Id = 99, Name = "Uzbeque (Latim) - Latn" },
            new Translation { Id = 100, Name = "Uzbeque (Cirílico) - Cyrl" },
            new Translation { Id = 101, Name = "Vietnamita - Latn" },
            new Translation { Id = 102, Name = "Galês - Latn" },
            new Translation { Id = 103, Name = "Xhosa - Latn" },
            new Translation { Id = 104, Name = "Iídiche - Hebr" },
            new Translation { Id = 105, Name = "Iorubá - Latn" },
            new Translation { Id = 106, Name = "Zulu - Latn" },
            new Translation { Id = 107, Name = "Sérvio (Cirílico) - Cyrl" }
        );

        base.OnModelCreating(modelBuilder);
    }
}
