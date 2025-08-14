namespace SGMJ.API.Dtos
{
    public class JovemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CongregacaoId { get; set; }
        public string Congregacao { get; set; }
        public string Setor { get; set; }
        public int Idade {  get; set; }
    }
}
