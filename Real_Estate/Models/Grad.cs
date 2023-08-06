using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Models
{
    public class Grad
    {
        [Key]
        public int IdGrada { get; set; }
        public string? NazivGrada { get; set; }

        public ICollection<Agencija> Agencije { get; set; }
    }

}
