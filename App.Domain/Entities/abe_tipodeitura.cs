using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class abe_tipodeitura
    {
        [Key]
        public Guid tip_codigo { get; set; }
        public string tip_descricao { get; set; }
        [ForeignKey("abe_unidademedida")]
        public Guid uni_codigo { get; set; }
        public virtual abe_unidademedida abe_unidademedida { get; set; }
    }
}
