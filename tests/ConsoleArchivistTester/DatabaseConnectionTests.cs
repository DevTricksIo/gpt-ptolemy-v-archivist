using ConsoleArchivist.Database;
using ConsoleArchivist.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleArchivistTester
{
    public class DatabaseConnectionTests: SetupTest
    {

        [Fact]
        public void CanInstantiateArchivistDbContext_Success()
        {
            //Arrange
            //Act
            var dbContext = host.Services.GetService<ArchivistDbContext>();

            //Assert
            Assert.NotNull(dbContext);
        }

        [Fact]
        public void CanReadDatabase_Success()
        {
            //Check if 'InitialMigration' in Migrations folder exists and run 'dotnet ef database update' to create the database

            //Arrange
            var sut = host.Services.GetService<ArchivistDbContext>();

            //Act
            bool canAccessDatabase;
            try
            {
                _ = sut.Translations.Take(1).ToList();
                canAccessDatabase = true;
            }
            catch (Exception)
            {
                throw;
            }

            //Assert
            Assert.True(canAccessDatabase);
        }

        [Fact]
        public void DatabaseIsPopulated_Success()
        {
            //Check if 'CreateSeedDataWithLanguagesNames' in Migrations folder exists and seed data in OnModelCreating

            //Arrange
            var sut = host.Services.GetService<ArchivistDbContext>();

            //Act
            //Assert
            Assert.NotEmpty(sut.Translations);
        }

        [Fact]
        public void ArchivistDbContextHasADbPath_Success()
        {
            //Arrange
            var sut = host.Services.GetService<ArchivistDbContext>();

            //Act
            //Assert
            //Assert.EndsWith(".db", sut.DbPath);
        }
    }
}