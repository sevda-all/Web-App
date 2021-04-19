using System;
using System.Collections.Generic;
using System.Text;

namespace Bookush.DAL.Repositories
{
    public abstract class BaseRepo
    {
        protected readonly BookDBContext _context;
        protected BaseRepo(BookDBContext context)
        {
            _context = context;
        }
    }
}
