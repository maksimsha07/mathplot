using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class MappingFunctions
    {
        [Required]
        public double r { get; set; }
        [Required]
        public bool lestlameri { get; set; }
        [Required]
        public bool bifur { get; set; }
        [Required]
        public bool pokazlapuniva { get; set; }
        public string login { get; set; }
    }
}
