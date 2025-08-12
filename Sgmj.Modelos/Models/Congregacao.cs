using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sgmj.Modelos.Models
{
    public class Congregacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int SetorId { get; set; }

        [JsonIgnore]
        public virtual Setor Setor { get; set; }
        public virtual ICollection<Jovem> Jovens { get; set; } = new List<Jovem>();
    }
}
