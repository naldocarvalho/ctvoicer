using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    class TestHelper
    {
        /// <summary>
        /// Returns <see cref="SQLiteContext"/> with Entity Framework Core In-Memory Database.
        /// </summary>
        public static DbContextOptions<SQLiteContext> GetSQLiteContextInMemory
        {
            get
            {
                DbContextOptions<SQLiteContext> options = new DbContextOptionsBuilder<SQLiteContext>().UseInMemoryDatabase(databaseName: "fleetmanager").Options;
                return options;
            }
        }
    }
}