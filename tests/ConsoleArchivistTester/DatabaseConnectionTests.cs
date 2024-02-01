using ConsoleArchivist.Database;

namespace ConsoleArchivistTester
{
    public class DatabaseConnectionTests
    {

        [Fact]
        public void ArchivistDbContextInstantiate_Success()
        {
            //Arrange
            //Act
            var dbContext = ArchivistDbContext.Instance;

            //Assert
            Assert.NotNull(dbContext);
        }

        [Fact]
        public void CanReadDatabase_Success()
        {
            //Check if 'InitialMigration' in Migrations folder exists and run 'dotnet ef database update' to create the database

            //Arrange
            var sut = ArchivistDbContext.Instance;

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
            var sut = ArchivistDbContext.Instance;

            //Act
            //Assert
            Assert.NotEmpty(sut.Translations);
        }

        [Fact]
        public void ArchivistDbContextHasADbPath_Success()
        {
            //Arrange
            var sut = ArchivistDbContext.Instance;

            //Act
            //Assert
            Assert.EndsWith(".db", sut.DbPath);
        }
    }
}