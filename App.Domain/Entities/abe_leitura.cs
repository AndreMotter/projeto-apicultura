using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class abe_leitura
    {
        [Key]
        public Guid lei_codigo { get; set; }

        [ForeignKey("abe_colmeia")] 
        public Guid col_codigo { get; set; }
        public virtual abe_colmeia abe_colmeia { get; set; }

        [ForeignKey("abe_tipodeitura")] 
        public Guid tip_codigo { get; set; }
        public virtual abe_tipodeitura abe_tipodeitura { get; set; }
        public DateTime lei_data { get; set; }
        public decimal lei_valor { get; set; }
    }
}
