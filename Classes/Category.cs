using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassFormWithDb.Classes
{
    [Table("category")]
    public class Category
    {
        [Column("categoryId")]
        [Key]
        public int CategoryId { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [InverseProperty("Category")]
        public List<Task> Tasks { get; set; }
    }
}
