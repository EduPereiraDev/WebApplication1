using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1
{
    public class Contato
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("apelido")]
        public string Apelido { get; set; } = string.Empty;

        [Column("cpf")]
        public string Cpf { get; set; } = string.Empty;

        [Column("telefone")]
        public string Telefone { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("data_ultima_alteracao")]
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}