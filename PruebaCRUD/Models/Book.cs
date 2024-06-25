using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaCRUD.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public DateTime PublicationYear { get; set; }
        public string Genre {  get; set; }
    }
}
