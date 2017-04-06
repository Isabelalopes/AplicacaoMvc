using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication1.Dominio
{
    public class Prato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o nome do restaurante")]
        [DisplayName("Nome do Restaurante")]
        public string NomeRestaurante { get; set; }
        [Required(ErrorMessage = "Preencha o nome do prato")]
        [DisplayName("Nome do Prato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o preço do prato")]
        [DisplayName("Preço")]
        public Decimal Preco { get; set; }
    }
}
