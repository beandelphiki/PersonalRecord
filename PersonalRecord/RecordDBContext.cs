using System;
using System.Linq;
using System.Data.Common;
using PersonalRecord.Models;
using Microsoft.EntityFrameworkCore;



namespace PersonalRecord
{
    public class RecordDBContext : Microsoft.EntityFrameworkCore.DbContext
    {

        #region Constructor setup
        public RecordDBContext() {}

        public RecordDBContext(DbContextOptions<RecordDBContext> options)
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

        public DbSet<Record> recordList { get; set; }
    }
}
