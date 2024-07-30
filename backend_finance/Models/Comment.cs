using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apl_project.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int? StockId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Stock? Stock { get; set; }
    }
}