using Bookush.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookush.DAL
{
    public class BookDBContext: DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
    }
}
