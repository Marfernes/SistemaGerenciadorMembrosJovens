using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgmj.Modelos.Models
{
    public class Congregacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int SetorId { get; set; }         
        public virtual Setor Setor { get; set; } 
    }
}
