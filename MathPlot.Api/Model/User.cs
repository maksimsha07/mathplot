using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPlot.Api.Model
{
   public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Укажите Фамилию")]
        public string LastName { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Логин от 3 до 20")]
        public string Login { get; set; }
        public DateTime Birthday { get; set; }
        public bool Genre { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public long Phone { get; set; }
        [Required(ErrorMessage = "Укажите пароль")]
        public string Password { get; set; }

    }
}
