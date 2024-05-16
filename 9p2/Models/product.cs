using System.ComponentModel.DataAnnotations;

namespace _9p2.Models
{
    public class product
    {
        [Key]
        public int pro_id
        {
        get; set; }
        public string pro_name
        {
        get; set; }
        public float price
        {
            get; set;
        }
        public int qty
        {
            get; set;
        }
        public int categorycat_id
        {
            get; set;
        }
        public category category
        {
        get; set; }
        public string pro_image
        {
            get; set;
        }
    }
}
