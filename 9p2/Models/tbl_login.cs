using System.ComponentModel.DataAnnotations;

namespace _9p2.Models
{
    public class tbl_login
    {
        [Key]
        public int login_id
        {
        get; set; }
        [Required]
        public string login_name
        {
        get; set; }
        [Required]
        public string login_email
        {
            get; set;
        }
        [Required]
        public string login_pass
        {
            get; set;
        }

    }
}
