using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
    public class UserImage
    {
        public IFormFile file { get; set; }
        public string login { get; set; }
    }
}
