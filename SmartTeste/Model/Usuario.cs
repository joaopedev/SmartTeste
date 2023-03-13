using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartTeste.Model
{
    [Table("usuarios")]
    public class Usuario
    {
        [Column("id")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        [Column("nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }
        [Column("rg")]
        [Display(Name = "RG")]
        public int? Rg { get; set; }
        [Column("estado")]
        [Display(Name = "Estado")]
        public string? Estado { get; set; }
        [Column("nascimento")]
        [Display(Name = "Nascimento")]
        public DateTime? Nascimento { get; set; }
        [Column("dataCadastro")]
        [Display(Name = "DataCadastro")]
        public DateTime? DataCadastro { get; set; }
        [Column("telefone")]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }
    }
}
