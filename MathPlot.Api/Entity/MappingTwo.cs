using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Entity
{
    public class MappingTwo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double r { get; set; }
        [Required]
        public bool bifur { get; set; }
        [Required]
        public bool pokazlapuniva { get; set; }
        public string path { get; set; }
        public Guid UserId { get; set; }
        public User user { get; set; }
    }
}
