using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_tipodeitura
    {
        [Key]
        public Guid tip_codigo { get; set; }
        public string tip_descricao { get; set; }
        public Guid uni_codigo { get; set; }
        public abe_unidademedida abe_unidademedida { get; set; }
    }
}
