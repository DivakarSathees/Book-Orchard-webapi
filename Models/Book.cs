using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        public string BookName { get; set; }

        public string AuthorName { get; set; }
        public string Genre{ get; set; }
    }
}
