using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPlot.Api.Entity
{
   public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Укажите Фамилию")]
        public string LastName { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Логин содержит символы 3 до 20")]
        public string Login { get; set; }
        public bool Genre { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public long Phone { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Пароль должен содержать больше 8 символов")]
        public string Password { get; set; }
        public string ImagePath { get; set; }

        public List<Comment> Comments = new List<Comment>();

        public List<MappingPlank> MappingPlanks = new List<MappingPlank>();

        public List<MappingSinus> MappingSinuss = new List<MappingSinus>();
        public List<MappingTwo> MappingTwos = new List<MappingTwo>();
        public List<MappingLogistic> MappingLogistics = new List<MappingLogistic>();
        public List<MappingGauss> MappingGausss = new List<MappingGauss>();

    }
}
