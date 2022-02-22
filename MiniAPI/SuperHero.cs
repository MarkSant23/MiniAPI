using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAPI
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } 


        public string LastName { get; set; } 

        public string HeroName { get; set; } 

 
        public int? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }
    }

}

