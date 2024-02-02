using Microsoft.EntityFrameworkCore.Design;
using ConsoleArchivist.Database;

namespace ConsoleArchivist;

public  class ArchivistDbContextFactory: IDesignTimeDbContextFactory<ArchivistDbContext>
{
    public ArchivistDbContext CreateDbContext(string[] args)
    {
        return ArchivistDbContext.Instance;
    }
}
