using Microsoft.EntityFrameworkCore;
using PersonalRecordAPI.Models;

namespace PersonalRecordAPI

{
    public class RecordEntryContext : DbContext
    {
        #region Constructor setup
        public RecordEntryContext() { }

        public RecordEntryContext(DbContextOptions<RecordEntryContext> options)
           : base(options)
        { }
        #endregion

        #region OnConfiguring 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase();//This version is deprecated. Replace this with the non-deprecated version eventually.
            }
        }
        #endregion

        public DbSet<RecordEntry> recordListAPI { get; set; }
    }
}