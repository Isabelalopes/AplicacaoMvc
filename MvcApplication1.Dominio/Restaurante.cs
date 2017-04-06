using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication1.Dominio
{
    public class Restaurante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o nome do restaurante")]
        public string Nome { get; set; }
    }
}
