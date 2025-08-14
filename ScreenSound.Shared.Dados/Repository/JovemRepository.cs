using Sgmj.Modelos.Models;
using SGMJ.Dados.Banco.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGMJ.Dados.Repository
{
    public class JovemRepository : IJovemRepository
    {
        private readonly DAL<Jovem> _dalJovem;
        private readonly DAL<Congregacao> _dalCongregacao;

        public JovemRepository(DAL<Jovem> dal, DAL<Congregacao> dalCongregãcao)
        {
            _dalJovem = dal;
            _dalCongregacao = dalCongregãcao;
        }
        public Task AdicionarAsync(Jovem jovem)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Jovem jovem)
        {
            throw new NotImplementedException();
        }

        public Task<Jovem?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAsync(Jovem jovem)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Jovem>> ListarAsync()
        {
            var jovens = (await _dalJovem.ListarAsync()).ToList();
            var congregacoes = (await _dalCongregacao.ListarAsync()).ToList();
            var setores = congregacoes.Select(c => c.Setor).Distinct().ToList();

            // Faz o "join" em memória
            foreach (var jovem in jovens)
            {
                var congregacao = congregacoes.FirstOrDefault(c => c.Id == jovem.CongregacaoId);
                jovem.Congregacao = congregacao;
                // Atribuir o setor à propriedade de navegação da congregação (se existir)
                if (congregacao != null)
                {
                    jovem.Congregacao.Setor = setores.FirstOrDefault(s => s.Id == congregacao.SetorId);
                }
            }

            return jovens;
        }
    }
}
