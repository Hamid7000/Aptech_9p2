using System.ComponentModel.DataAnnotations;

namespace _9p2.Models
{
    public class category
    {
        [Key]
        public int cat_id
        {
        get; set; }
        [Required]
        public string cat_name
        {
        get; set; }
    }
}
