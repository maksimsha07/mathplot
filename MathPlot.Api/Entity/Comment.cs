using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Entity
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string commented { get; set; }

        public Guid UserId { get; set; }
        public User user { get; set; }
        public int PageId { get; set; }
        public Page page { get; set; }
    }
}
