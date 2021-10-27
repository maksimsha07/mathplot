using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string commented { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
