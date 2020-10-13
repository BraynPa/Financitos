using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financitos.Models
{
    public class Account
    {
        public int id { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression("\\s", ErrorMessage = "no espacios")]
        public string Name { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Currency { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]

        public decimal Amount { get; set; }
    }
}
