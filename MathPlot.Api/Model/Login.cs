using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class Login
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
    }
}
