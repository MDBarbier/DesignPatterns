
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternWithGenerics.Models
{
    public class Game
    {
        public Game()
        {

        }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        [Key]
        public int _id { get; set; }
    }
}
