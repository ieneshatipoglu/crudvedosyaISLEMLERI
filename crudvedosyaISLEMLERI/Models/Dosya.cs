using System.ComponentModel.DataAnnotations;

namespace crudvedosyaISLEMLERI.Models
{
    public class Dosya
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }   
        public long Boyut { get; set; }
        public string? Tip { get; set; }  
    }
}
