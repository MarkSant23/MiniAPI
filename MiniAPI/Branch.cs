using System.ComponentModel.DataAnnotations;

namespace MiniAPI
{
    public class Branch
    {
        [Key]
        public int BranchId{ get; set; }
        
        public string BranchName { get; set; }

        public ICollection<SuperHero>? SuperHeroes { get; set; }

    }
}
