using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class MappingPlank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double r { get; set; }
        [Required]
        public bool lestlameri { get; set; }
        [Required]
        public bool bifur { get; set; }
        [Required]
        public bool pokazlapuniva { get; set; }
    }
}
