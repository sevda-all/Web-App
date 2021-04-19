using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookush.DAL.DBO
{
    public class Book: IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        public string Authors { get; set; }

        [Required]
        public string Edition { get; set; }
        
        [DisplayName("Date of publication")]
        public DateTime DateOfPublished { get; set; }
        
        public Genres Genres { get; set; }

        public string Barcode { get; set; }

        public int? PublisherId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResult = new List<ValidationResult>();

            return validationResult;
        }
        public virtual Publisher Publisher { get; set; }
    }

    public enum Genres
    {
        Fiction,
        Detective,
        Novel,
        Fantasy

    }
}
