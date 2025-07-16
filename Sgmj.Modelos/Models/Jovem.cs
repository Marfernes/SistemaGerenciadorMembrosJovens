using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgmj.Modelos.Models
{
    public class Jovem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string  Telefone { get; set; }
        public string Email { get; set; }

        // Chave estrangeira para o Setor
        public int SetorId { get; set; }

        // Propriedade de navegação: um Jovem pertence a um Setor
        public virtual Setor Setor { get; set; }

    }
}
