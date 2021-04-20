using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookush.DAL.DBO
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Publisher")]
        public string Name { get; set; }

        public string Country { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
