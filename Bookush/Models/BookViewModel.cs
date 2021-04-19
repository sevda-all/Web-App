using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookush.DAL.DBO;


namespace Bookush.Models
{
    public class BookViewModel : Book
    {
        public SelectList Publishers{get; set;}
    }
}
