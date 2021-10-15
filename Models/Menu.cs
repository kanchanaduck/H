using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class Menu
    {
        [Key]
        public string menu_code { get; set; }
        [Required]
        public string menu_name { get; set; }
        public string parent_menu_code { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string spare1 { get; set; }
        public string spare2 { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime update_date { get; set; }
        [Required]
        public string update_by { get; set; }
        [ForeignKey("parent_menu_code")]
        public virtual Menu parent { get; set; }
        public virtual ICollection<Menu> children { get; set; }
    }
}