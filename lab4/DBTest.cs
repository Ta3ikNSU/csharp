using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace lab4;

public class DBTest
{
    private static DbContextOptions<AttemptContext> DbContextOptions =
        (DbContextOptions<AttemptContext>)new DbContextOptionsBuilder()
            .UseInMemoryDatabase(databaseName: "attempts_test")
            .Options;
    
    private AttemptContext _context;
    
    [OneTimeSetUp]
    public void Setup()
    {
        _context = new AttemptContext(DbContextOptions);
        _context.Database.EnsureCreated();
    }
    
    [OneTimeTearDown]
    public void Cleanup()
    {
        _context.Database.EnsureDeleted();
    }
}