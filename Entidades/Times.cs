using Campeonato.Entidades.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    [Table("tbl_time")]
    public class Times
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public Categoria Categoria { get; set; }
        
        [StringLength(100)]
        [Required]
        public string Nome { get; set; }

        [StringLength(100)]
        [Required]
        public string Escudo { get; set; }

        public Times()
        {

        }

        public Times(int id, Categoria categoria, string nome, string escudo)
        {

            this.Id = id;
            this.Categoria = categoria;
            this.Nome = nome;
            this.Escudo = escudo;

        }

        public Times(int id, string nome, string escudo)
        {

            this.Id = id;
            this.Nome = nome;
            this.Escudo = escudo;

        }

    }
}
