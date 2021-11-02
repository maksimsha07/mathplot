using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class Page
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Page(){
            Comments = new List<Comment>();
        }

    }
}
